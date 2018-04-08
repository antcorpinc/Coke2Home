using Dapper;
using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Markup;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RevenueMarkUpResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.RevenueMarkupRule;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class RevenueMarkupControllerTest
    {
        #region Private Variables
        private RevenueMarkupController revenueMarkupControllerMock;
        private Mock<ILogger> loggerMock;
        private Mock<IRevenueMarkup> _iRevenueMarkupRepositoryMock;
        private Mock<ILogger> _iLoggerMock;
        private Mock<IMasterData<RevenueMarkupRule, int>> _iMarkupDataRevenueMarkupRuleMock;
        private Mock<IMasterData<RevenueMarkup, int>> _iMasterDataRevenueMarkupMock;
        private Mock<IMasterData<Models.Request.RevenueMarkup, int>> _iMasterDataMock;
        #endregion Private Variables

        public RevenueMarkupControllerTest()
        {
            _iMarkupDataRevenueMarkupRuleMock = new Mock<IMasterData<RevenueMarkupRule, int>>();
            _iMasterDataRevenueMarkupMock = new Mock<IMasterData<RevenueMarkup, int>>();
            _iRevenueMarkupRepositoryMock = new Mock<IRevenueMarkup>();
            _iMasterDataMock = new Mock<IMasterData<Models.Request.RevenueMarkup, int>>();
            _iLoggerMock = new Mock<ILogger>();

            revenueMarkupControllerMock = new RevenueMarkupController(_iMasterDataMock.Object,
                                                                 _iLoggerMock.Object,
                                                                 _iRevenueMarkupRepositoryMock.Object,
                                                                 _iMarkupDataRevenueMarkupRuleMock.Object,
                                                                 _iMasterDataRevenueMarkupMock.Object);
        }

        [Test]
        public void TestGetAllRevenueMarkUpNullObjectReturnsNoContentFail()
        {
            _iRevenueMarkupRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()));

            var result = revenueMarkupControllerMock.Get().Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestGetAllRevenueMarkUpReturnsAnErrorOrExceptionFail()
        {
            _iRevenueMarkupRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = revenueMarkupControllerMock.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllRevenueMarkUpReturnOkSuccess()
        {
            IEnumerable<dynamic> fakeRevenueMarkUpResponseList = new List<RevenueMarkUpResponseModel>();
            fakeRevenueMarkUpResponseList = this.GetFakeListOfRevenueMarkUpResponseModel();

            _iRevenueMarkupRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeRevenueMarkUpResponseList, IsError = false }));

            var result = revenueMarkupControllerMock.Get().Result;
            BaseResult<List<RevenueMarkUpResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<RevenueMarkUpResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestGetAllRevenueMarkUpThrowsException()
        {
            _iRevenueMarkupRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = revenueMarkupControllerMock.Get().Result;
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestCreateRevenueMarkUpReturnsBadRequestObjectWhenModelIsNullFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.InsertOrUpdateByProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>()))
                .Returns(Task.FromResult(new BaseResult<bool>()));

            var result = revenueMarkupControllerMock.Create(null).Result;

            Assert.That(result is BadRequestObjectResult);
        }
                
        [Test]
        public void TestCreateRevenueMarkUpReturnsExistingListThrowsException()
        {
            Models.Request.RevenueMarkup revenueMarkup = new Models.Request.RevenueMarkup
            {
                MGRevenueMarkup = new RevenueMarkup
                {

                    Name = "RM1",
                    IsActive = true,
                    IsDeleted = false
                },
                RevenueMarkupRules = new List<RevenueMarkupRule>
                {
                    new RevenueMarkupRule
                    {
                        CityId = 1,
                        CountryId=1,
                        ChargeTypeId=1,
                        HotelId=1,
                        HotelRoomTypeId=1,
                        Markup = 11,
                        MarkupId =1,
                        SupplierId=1
                    }
                }
            };

            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList())
                .Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>>() { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = revenueMarkupControllerMock.Create(revenueMarkup).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }
        
        [Test]
        public void TestRevenueMarkUpCreateThrowsException()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.InsertOrUpdateByProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>()))
               .Throws(Common.GetMockException());

            var result = revenueMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestRevenueMarkUpGetMarkupRuleListFail()
        {
            _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = ExistingMarkupRules(), IsError = true }));

            var result = revenueMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }
        
        [Test]
        public void TestRevenueMarkUpGetMasterMarkupListFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = true }));

            var result = revenueMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestRevenueMarkUpDuplicateMarkupNameFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));

            Models.Request.RevenueMarkup model = RequestModel();
            model.MGRevenueMarkup.Name = "Markup";

            var result = revenueMarkupControllerMock.Create(model).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestRevenueMarkupNoExistingRevenueMarkupFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = new List<RevenueMarkupRule>(), IsError = false }));

            Models.Request.RevenueMarkup model = RequestModel();
            model.RevenueMarkupRules.Add(new RevenueMarkupRule()
            {
                ChargeTypeId = 1,
                CityId = 1,
                CountryId = 1,
                FromDatekey = 20180106,
                HotelId = 1,
                Markup = 11,
                HotelRoomTypeId = 1,
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                MarkupId = 1,
                NationalityId = 1,
                SupplierId = 1,
                ToDatekey = 20180107
            });

            var result = revenueMarkupControllerMock.Create(model).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestRevenueMarkUpExisitingDateRangeFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));
            
            var result = revenueMarkupControllerMock.Create(RequestModel()).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        public void TestUpdateRevenueMarkUpNullRequestObjectFail()
        {
            var result = revenueMarkupControllerMock.Update(null).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestRevenueMarkUpUpdateGetMarkupRuleListFail()
        {
            _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = ExistingMarkupRules(), IsError = true }));

            var result = revenueMarkupControllerMock.Update(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestRevenueMarkUpUpdateGetMasterMarkupListFail()
        {
            _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = true }));

            var result = revenueMarkupControllerMock.Update(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }
        
        //[Test]
        //public void TestRevenueMarkUpCreateMarkupSuccess()
        //{
        //    _iMasterDataRevenueMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
        //    _iMarkupDataRevenueMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<RevenueMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));

        //    Models.Request.RevenueMarkup model = new Models.Request.RevenueMarkup
        //    {
        //        MGRevenueMarkup = new RevenueMarkup
        //        {
        //            Name = "RM1",
        //            IsActive = true,
        //            IsDeleted = false
        //        },
        //        RevenueMarkupRules = new List<RevenueMarkupRule>
        //        {
        //            new RevenueMarkupRule
        //            {
        //                //CityId = 1,
        //                //CountryId=1,
        //                //ChargeTypeId=1,
        //                //HotelId=1,
        //                //HotelRoomTypeId=1,
        //                //Markup = 11,
        //                //MarkupId =1,
        //                //SupplierId=1

        //                ChargeTypeId = 1,
        //                CityId = 1,
        //                CountryId = 2,
        //                FromDatekey = 20180105,
        //                HotelId = 1,
        //                Markup = 11,
        //                HotelRoomTypeId =1,
        //                Id = 1,
        //                IsActive = true,
        //                IsDeleted = false,
        //                MarkupId = 1,
        //                NationalityId = 1,
        //                SupplierId =1,
        //                ToDatekey = 20180107
        //            }
        //        }
        //    };

        //    var result = revenueMarkupControllerMock.Create(model).Result;

        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        private IEnumerable<dynamic> GetFakeListOfRevenueMarkUpResponseModel()
        {
            List<RevenueMarkUpResponseModel> list = new List<RevenueMarkUpResponseModel>();
            list.Add(new RevenueMarkUpResponseModel
            {
                Id = 1,
                ChargeType = "CH1",
                ChargeTypeId = 1,
                City = "PUNE",
                CityId = 1,
                Country = "INDIA",
                CountryId = 1,
                Hotel = "H1",
                HotelId = 1,
                HotelRoomTypeId = 1,
                Markup = 12,
                MarkupId = 1,
                MarkupName = "MU1",
                RoomType = "RM1",
                Supplier = "SU1",
                SupplierId = 1,
                FromDatekey = 1,
                ToDatekey = 2
            });

            return list;

        }

        private List<Core.Model.MasterData.RevenueMarkup> ExistingMasterDataMarkup()
        {
            return new List<RevenueMarkup>()
            {
                new RevenueMarkup()
                {
                    IsDeleted = false,
                    Id = 1,
                    Name = "Markup"
                }
            };
        }

        private List<RevenueMarkupRule> ExistingMarkupRules()
        {
            return new List<RevenueMarkupRule>()
            {
                new RevenueMarkupRule()
                {
                    ChargeTypeId = 1,
                    CityId = 1,
                    CountryId = 1,
                    FromDatekey = 20180101,
                    HotelId = 1,
                    Markup = 20,
                    HotelRoomTypeId =1,
                    Id = 1,
                    IsActive = true,
                    IsDeleted = false,
                    MarkupId = 1,
                    NationalityId = 1,
                    SupplierId =1,
                    ToDatekey = 20180202
                }
            };
        }

        private Models.Request.RevenueMarkup RequestModel()
        {
            return new Models.Request.RevenueMarkup
            {
                MGRevenueMarkup = new RevenueMarkup
                {
                    Name = "RM1",
                    IsActive = true,
                    IsDeleted = false
                },
                RevenueMarkupRules = new List<RevenueMarkupRule>
                {
                    new RevenueMarkupRule
                    {
                        //CityId = 1,
                        //CountryId=1,
                        //ChargeTypeId=1,
                        //HotelId=1,
                        //HotelRoomTypeId=1,
                        //Markup = 11,
                        //MarkupId =1,
                        //SupplierId=1

                        ChargeTypeId = 1,
                        CityId = 1,
                        CountryId = 1,
                        FromDatekey = 20180105,
                        HotelId = 1,
                        Markup = 11,
                        HotelRoomTypeId =1,
                        Id = 1,
                        IsActive = true,
                        IsDeleted = false,
                        MarkupId = 1,
                        NationalityId = 1,
                        SupplierId =1,
                        ToDatekey = 20180107
                    }
                }
            };
        }

    }
}
