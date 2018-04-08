using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Markup;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgencyMarkupRequestModel = MG.Jarvis.Api.BackOffice.Models.Request.AgencyMarkup;
using AgencyMarkupResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.AgencyMarkup;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class AgencyMarkupControllerTest
    {
        #region Private Variables
        private AgencyMarkupController agencyMarkupControllerMock;
        private Mock<IMasterData<AgencyMarkupRule, int>> _iMarkupDataAgencyMarkupRuleMock;
        private Mock<IMasterData<Core.Model.MasterData.AgencyMarkup,int>> _iMasterDataAgencyMarkupMock;
        private Mock<ILogger> _iLoggerMock;
        private Mock<IMasterData<AgencyMarkupRequestModel, int>> _iMasterData;
        private Mock<IAgencyMarkup> _iAgencyMarkUpRepositoryMock;
        #endregion Private Variables

        public AgencyMarkupControllerTest()
        {
            _iMasterData = new Mock<IMasterData<AgencyMarkupRequestModel, int>>();
            _iLoggerMock = new Mock<ILogger>();
            _iMarkupDataAgencyMarkupRuleMock = new Mock<IMasterData<AgencyMarkupRule,int>>();
            _iMasterDataAgencyMarkupMock = new Mock<IMasterData<Core.Model.MasterData.AgencyMarkup,int>>();
            _iAgencyMarkUpRepositoryMock = new Mock<IAgencyMarkup>();
            agencyMarkupControllerMock = new AgencyMarkupController(_iMasterData.Object, 
                                                                _iLoggerMock.Object,
                                                                _iAgencyMarkUpRepositoryMock.Object,
                                                                _iMarkupDataAgencyMarkupRuleMock.Object,
                                                                _iMasterDataAgencyMarkupMock.Object);
        }

        [Test]
        public void TestGetAllAgencyMarkUpNullObjectReturnsNoContentFail()
        {
            _iAgencyMarkUpRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()));

            var result = agencyMarkupControllerMock.Get().Result;

            Assert.IsTrue(result is NoContentResult);
            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        }

        [Test]
        public void TestGetAllAgencyMarkUpReturnsAnErrorOrExceptionFail()
        {
            _iAgencyMarkUpRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = agencyMarkupControllerMock.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllAgencyMarkUpReturnOkSuccess()
        {
            List<AgencyMarkupResponseModel> fakeAgencyMarkUpResponseList = new List<AgencyMarkupResponseModel>();
            fakeAgencyMarkUpResponseList = this.GetFakeListOfAgencyMarkUpResponseModel();

            _iAgencyMarkUpRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeAgencyMarkUpResponseList, IsError = false }));

            var result = agencyMarkupControllerMock.Get().Result;
            BaseResult<List<AgencyMarkupResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<AgencyMarkupResponseModel>>;

            Assert.That(result is OkObjectResult);
           
        }

        [Test]
        public void TestGetAllAgenciesThrowsException()
        {
            _iAgencyMarkUpRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = agencyMarkupControllerMock.Get().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestAgencyMarkupCreateNullRequestModel()
        {
            var result = agencyMarkupControllerMock.Create(null).Result;
            Assert.IsTrue(result is BadRequestObjectResult);
        }

        [Test]
        public void TestAgencyMarkUpCreateThrowsException()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.InsertOrUpdateByProcedure(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>()))
               .Throws(Common.GetMockException());

            var result = agencyMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestAgencyMarkUpGetMarkupRuleListFail()
        {
            _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = ExistingMarkupRules(), IsError = true }));

            var result = agencyMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestAgencyMarkUpGetMasterMarkupListFail()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = true }));

            var result = agencyMarkupControllerMock.Create(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestAgencyMarkUpDuplicateMarkupNameFail()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));

            Models.Request.AgencyMarkup model = RequestModel();
            model.MGAgencyMarkup.Name = "Markup";

            var result = agencyMarkupControllerMock.Create(model).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestAgencyMarkupNoExistingAgencyMarkupFail()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = new List<AgencyMarkupRule>(), IsError = false }));

            Models.Request.AgencyMarkup model = RequestModel();
            model.AgencyMarkupRule.Add(new AgencyMarkupRule()
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
                AgencyId = 1,
                ToDatekey = 20180107
            });

            var result = agencyMarkupControllerMock.Create(model).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestAgencyMarkUpExisitingDateRangeFail()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
            _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));

            var result = agencyMarkupControllerMock.Create(RequestModel()).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        public void TestUpdateAgencyMarkUpNullRequestObjectFail()
        {
            var result = agencyMarkupControllerMock.Update(null).Result;

            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public void TestAgencyMarkUpUpdateGetMarkupRuleListFail()
        {
            _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = ExistingMarkupRules(), IsError = true }));

            var result = agencyMarkupControllerMock.Update(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestAgencyMarkUpUpdateGetMasterMarkupListFail()
        {
            _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = true }));

            var result = agencyMarkupControllerMock.Update(RequestModel()).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        //[Test]
        //public void TestAgencyMarkUpCreateMarkupSuccess()
        //{
        //    _iMasterDataAgencyMarkupMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkup>> { Result = ExistingMasterDataMarkup(), IsError = false }));
        //    _iMarkupDataAgencyMarkupRuleMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<AgencyMarkupRule>> { Result = ExistingMarkupRules(), IsError = false }));

        //    Models.Request.AgencyMarkup model = new Models.Request.AgencyMarkup
        //    {
        //        MGAgencyMarkup = new AgencyMarkup
        //        {
        //            Name = "RM1",
        //            IsActive = true,
        //            IsDeleted = false
        //        },
        //        AgencyMarkupRules = new List<AgencyMarkupRule>
        //        {
        //            new AgencyMarkupRule
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

        //    var result = agencyMarkupControllerMock.Create(model).Result;

        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

      
        private List<Core.Model.MasterData.AgencyMarkup> ExistingMasterDataMarkup()
        {
            return new List<Core.Model.MasterData.AgencyMarkup>()
            {
                new Core.Model.MasterData.AgencyMarkup()
                {
                    IsDeleted = false,
                    Id = 1,
                    Name = "Markup"
                }
            };
        }

        private List<AgencyMarkupRule> ExistingMarkupRules()
        {
            return new List<AgencyMarkupRule>()
            {
                new AgencyMarkupRule()
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
                    AgencyId =1,
                    ToDatekey = 20180202
                }
            };
        }

        private Models.Request.AgencyMarkup RequestModel()
        {
            return new Models.Request.AgencyMarkup
            {
                MGAgencyMarkup = new Core.Model.MasterData.AgencyMarkup
                {
                    Name = "RM1",
                    IsActive = true,
                    IsDeleted = false
                },
                AgencyMarkupRule = new List<AgencyMarkupRule>
                {
                    new AgencyMarkupRule
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
                        AgencyId =1,
                        ToDatekey = 20180107
                    }
                }
            };
        }

        private List<AgencyMarkupResponseModel> GetFakeListOfAgencyMarkUpResponseModel()
        {
            List<AgencyMarkupResponseModel> fakeAgencyMarkUpResponseModel = new List<AgencyMarkupResponseModel>();

            fakeAgencyMarkUpResponseModel.Add(new AgencyMarkupResponseModel
            {
                MGAgencyMarkup = new AgencyMarkupResponseModel
                {
                   
                },
                AgencyMarkupRuleResponse = new List<AgencyMarkupRuleResponse>
                {
                    new AgencyMarkupRuleResponse
                    {
                        Id = 1,
                        Hotel = "Test",
                        RoomType= "RM1",
                        MarkupId= 1,
                        Markup = 10,
                        AgencyId =1,
                        Agency = "GTA",
                        ChargeTypeId =1,
                        ChargeType = "CH1"
                    }
                }
            });

            return fakeAgencyMarkUpResponseModel;
        }
    }
}
