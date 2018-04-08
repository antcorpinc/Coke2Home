using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using BranchRequestModel = MG.Jarvis.Api.BackOffice.Models.Request.Branch;
using BranchResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.Branch;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class BranchControllerTest
    {
        #region Private Variables
        private BranchController branchController;
        private Mock<IBranch> branchMock;
        private Mock<IMasterData<BranchRequestModel, int>> iMasterDataMock;
        private Mock<ILogger> loggerMock;        
        #endregion Private Variables

        public BranchControllerTest()
        {
            branchMock = new Mock<IBranch>();           
            loggerMock = new Mock<ILogger>();
            iMasterDataMock = new Mock<IMasterData<BranchRequestModel, int>>();
            branchController = new BranchController(iMasterDataMock.Object, loggerMock.Object, branchMock.Object);
        }

        //create
        //[Test]
        //public void TestCreateBranchNullObjectBadRequestFail()
        //{
        //    var result = branchController.Create(null).Result;

        //    Assert.IsTrue(result is BadRequestResult);
        //    Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestCreateBranchReturnsAnErrorOrExceptionMessageFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.CreateBranch(fakeBranchRequest)).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Common.GetMockException() }));

        //    var result = branchController.Create(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCreateBranchReturnsOKSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.CreateBranch(fakeBranchRequest)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var controller = new BranchController(branchMock.Object, loggerMock.Object);
        //    var result = controller.Create(fakeBranchRequest).Result;

        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCreateBranchThrowsExceptionFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.CreateBranch(fakeBranchRequest)).Throws(Common.GetMockException());

        //    var result = branchController.Create(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        ////Update
        //[Test]
        //public void TestUpdateBranchNullObjectBadRequestFail()
        //{
        //    var result = branchController.Update(null).Result;

        //    Assert.IsTrue(result is BadRequestResult);
        //    Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestUpdateBranchReturnsAnErrorOrExceptionMessageFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, true, false)).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Common.GetMockException() }));

        //    var result = branchController.Update(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestUpdateBranchReturnsOKSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    fakeBranchRequest.Branch.Id = 1;            
        //    fakeBranchRequest.BranchContacts[0].Id = 1;

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, true, false)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var controller = new BranchController(branchMock.Object, loggerMock.Object);
        //    var result = controller.Update(fakeBranchRequest).Result;

        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestUpdateBranchThrowsExceptionFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, true, false)).Throws(Common.GetMockException());

        //    var result = branchController.Update(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        ////Delete

        //[Test]
        //public void TestDeleteBranchNullObjectBadRequestFail()
        //{
        //    var result = branchController.Delete(null).Result;

        //    Assert.IsTrue(result is BadRequestResult);
        //    Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestDeleteBranchReturnsAnErrorOrExceptionMessageFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, false, true)).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Common.GetMockException() }));

        //    var result = branchController.Delete(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestDeleteBranchReturnsOKSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    fakeBranchRequest.Branch.Id = 1;

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, false, true)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var controller = new BranchController(branchMock.Object, loggerMock.Object);
        //    var result = controller.Delete(fakeBranchRequest).Result;

        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestDeleteBranchThrowsExceptionFail()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    branchMock.Setup(x => x.UpdateBranch(fakeBranchRequest, false, true)).Throws(Common.GetMockException());

        //    var result = branchController.Delete(fakeBranchRequest).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //GetAll

        [Test]
        public void TestGetAllBranchesNullObjectReturnsNoContentFail()
        {
            branchMock.Setup(x => x.Get(null))
                .Returns(Task.FromResult(new BaseResult<List<BranchResponseModel>>()));

            var result = branchController.Get().Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestGetAllBranchesReturnsAnErrorOrExceptionFail()
        {
            branchMock.Setup(x => x.Get(null)).Returns(Task.FromResult(new BaseResult<List<BranchResponseModel>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = branchController.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllBranchesReturnOkSuccess()
        {
            List<BranchResponseModel> fakeBranchResponseList = new List<BranchResponseModel>();
            fakeBranchResponseList = this.GetFakeListOfBranchResponseModel();

            branchMock.Setup(x => x.Get(null)).Returns(Task.FromResult(new BaseResult<List<BranchResponseModel>> { Result = fakeBranchResponseList, IsError = false }));

            var result = branchController.Get().Result;
            BaseResult<List<BranchResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<BranchResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestGetBranchesByAgencyIdReturnOkSuccess()
        {
            List<BranchResponseModel> fakeBranchResponseList = new List<BranchResponseModel>();
            fakeBranchResponseList = this.GetFakeListOfBranchResponseModel();

            branchMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<List<BranchResponseModel>> { Result = fakeBranchResponseList, IsError = false }));

            var result = branchController.GetBranchByAgancyId(5).Result;
            BaseResult<List<BranchResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<BranchResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestGetAllBranchesThrowsException()
        {
            branchMock.Setup(x => x.Get(null)).Throws(Common.GetMockException());

            var result = branchController.Get().Result;
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }





        //[Test]
        //public void TestGetBranchReturnsNoContentFail()
        //{
        //    branchMock.Setup(x => x.GetBranch(1))
        //        .Returns(Task.FromResult(new BaseResult<BranchResponseModel>()));

        //    var result = branchController.GetById(1).Result;

        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestGetBranchReturnsAnErrorOrExceptionFail()
        //{
        //    branchMock.Setup(x => x.GetBranch(1)).Returns(Task.FromResult(new BaseResult<BranchResponseModel> { IsError = true, ExceptionMessage = Common.GetMockException() }));

        //    var result = branchController.GetById(1).Result;

        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestGetBranchReturnOkSuccess()
        //{
        //    BranchResponseModel fakeBranchResponse = new BranchResponseModel();
        //    fakeBranchResponse = this.GetFakeBranchResponseModel();

        //    branchMock.Setup(x => x.GetBranch(1)).Returns(Task.FromResult(new BaseResult<BranchResponseModel> { Result = fakeBranchResponse, IsError = false }));

        //    var result = branchController.GetById(1).Result;
        //    BaseResult<BranchResponseModel> responseResult = (result as OkObjectResult).Value as BaseResult<BranchResponseModel>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!responseResult.IsError);
        //    Assert.IsTrue(responseResult.Result != null);
        //}

        //[Test]
        //public void TestGetBranchThrowsExceptionFail()
        //{
        //    branchMock.Setup(x => x.GetBranch(1)).Throws(Common.GetMockException());

        //    var result = branchController.GetById(1).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        private BranchResponseModel GetFakeBranchResponseModel()
        {
            BranchResponseModel fakeAgencyResponseModel = new BranchResponseModel()
            {
                MGBranch = new Branch
                {
                    Name = "Test111",
                    AgencyId = 5,
                    CityId = 2,
                    CountryId = 4,
                    Address1 = "Address1",
                    Address2 = "Address2",
                    ZipCode = "13455",
                    Remarks = "Remark",
                    Notes = "Notes",
                    IsHeadOffice = false,
                    CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"
                },
                BranchContacts = new List<BranchContacts>
                        {
                            new BranchContacts{ ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                                IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false }
                        }
            };

            return fakeAgencyResponseModel;
        }
        private List<BranchResponseModel> GetFakeListOfBranchResponseModel()
        {
            List<BranchResponseModel> fakeBranchResponseList = new List<BranchResponseModel>();

            fakeBranchResponseList = new List<BranchResponseModel>();
            {
                fakeBranchResponseList.Add(new BranchResponseModel
                {

                    MGBranch = new Branch
                    {
                        Name = "Test111",
                        AgencyId = 5,
                        CityId = 2,
                        CountryId = 4,
                        Address1 = "Address1",
                        Address2 = "Address2",
                        ZipCode = "13455",
                        Remarks = "Remark",
                        Notes = "Notes",
                        IsHeadOffice = false,
                        CreatedBy = "MGIT",
                        UpdatedBy = "MGIT"
                    },
                    BranchContacts = new List<BranchContacts>
                        {
                            new BranchContacts{ ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                                IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false }
                        }
                });
                fakeBranchResponseList.Add(new BranchResponseModel
                {
                    MGBranch = new Branch
                    {
                        Name = "Test222",
                        AgencyId = 5,
                        CityId = 2,
                        CountryId = 4,
                        Address1 = "Address1",
                        Address2 = "Address2",
                        ZipCode = "13455",
                        Remarks = "Remark",
                        Notes = "Notes",
                        IsHeadOffice = false,
                        CreatedBy = "MGIT",
                        UpdatedBy = "MGIT"
                    },
                    BranchContacts = new List<BranchContacts>
                        {
                            new BranchContacts{ ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                                IsPrimary =false,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false }
                        }
                });
            }

            return fakeBranchResponseList;
        }
    }
}
