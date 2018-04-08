using Dapper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture]
    public class BranchRepositoryTest
    {
        #region Private Variables
        private IBranch branchRepositoryMock;
        private Mock<IConnection<Branch>> iBranchMock;
        private Mock<IConnection<BranchContacts>> iBranchContactsMock;
        private Mock<IConfiguration> iConfigurationMock;
        #endregion Private Variables

        public BranchRepositoryTest()
        {
            iConfigurationMock = new Mock<IConfiguration>();
            iBranchMock = new Mock<IConnection<Branch>>();
            iBranchContactsMock = new Mock<IConnection<BranchContacts>>();
            branchRepositoryMock = new BranchRepository(iBranchMock.Object,iBranchContactsMock.Object);
        }

        //[Test]
        //public void TestCreateBranchReturnsSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    iBranchMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = branchRepositoryMock.CreateBranch(fakeBranchRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestCreateBranchReturnsBranchContactsCountIsZeroSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    fakeBranchRequest.BranchContacts = new List<BranchContacts> { };

        //    iBranchMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = branchRepositoryMock.CreateBranch(fakeBranchRequest).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        [Test]
        public void TestGetAllBranchesReturnsBranchListSuccess()
        {
            this.MockGetAllBranchesResponseTables(true);

            var result = branchRepositoryMock.Get(5).Result;
            Assert.IsTrue(result.Result.Count > 0);
            Assert.IsTrue(result.Result[0].MGBranch != null);
            //Assert.Equals(fakeLsitAgencyResponse, result.Result);

        }

        [Test]
        public void TestGetAllBranchesReturnsNullBranchListFail()
        {
            this.MockGetAllBranchesResponseTables(false);

            var result = branchRepositoryMock.Get(5).Result;
            Assert.IsNull(result.Result);
        }

        [Test]
        public void TestGetBranchByIdReturnsBranchSuccess()
        {   
            this.MockGetAllBranchesResponseTables(true);

            var result = branchRepositoryMock.Get(1).Result;
            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result != null);
        }

        [Test]
        public void TestGetBranchByIdReturnsNullFail()
        {
            this.MockGetAllBranchesResponseTables(false);

            var result = branchRepositoryMock.Get(1).Result;
            Assert.IsNull(result.Result);
        }

        //[Test]
        //public void TestUpdateBranchReturnsSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    iBranchMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = branchRepositoryMock.UpdateBranch(fakeBranchRequest, true, false).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestUpdateBranchReturnsBranchContactsCountIsZeroSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();
        //    fakeBranchRequest.BranchContacts = new List<BranchContacts> { };

        //    iBranchMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = branchRepositoryMock.UpdateBranch(fakeBranchRequest, true, false).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestDeleteBranchReturnsSuccess()
        //{
        //    BranchRequestModel fakeBranchRequest = this.GetFakeBranchRequestModel();

        //    iBranchMock.Setup(x => x.UpdateEntityByDapper(fakeBranchRequest.Branch)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = branchRepositoryMock.UpdateBranch(fakeBranchRequest, false, true).Result;

        //    Assert.IsTrue(result.Result);
        //}

        private void MockGetAllBranchesResponseTables(bool ifSuccess)
        {
            Models.Response.Branch fakeBranchResponse = this.GetFakeBranchResponseModel();

            var branchContacts = new BranchContacts
            {
                Id = 1,
                ContactPerson = "Jon Doe",
                DesignationId = 1,
                Email = "john@gta.com",
                ContactNumber = "1234567890",
                IsPrimary = true,
                CreatedBy = "sa",
                UpdatedBy = "sa",
                IsActive = true,
                IsDeleted = false
            };

            var agencyId = 5;
            var branchPred = new Func<Branch, bool>(x => x.IsActive && !x.IsDeleted && x.AgencyId == (agencyId != 0 ? agencyId : x.AgencyId));

            if (ifSuccess)
            {

                iBranchMock.Setup(x => x.GetListByPredicate(It.Is<Func<Branch, bool>>(a => a.GetType() == branchPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Branch>> { Result = new List<Branch>() { fakeBranchResponse.MGBranch }, IsError = false }));
            }
            else
            {
                iBranchMock.Setup(x => x.GetListByPredicate(It.Is<Func<Branch, bool>>(a => a.GetType() == branchPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Branch>> { Result = new List<Branch>(), IsError = false }));
            }

            var agencyContactsPred = new Func<BranchContacts, bool>(a => a.IsActive && !a.IsDeleted && a.BranchId == fakeBranchResponse.MGBranch.Id);
            iBranchContactsMock.Setup(x => x.GetListByPredicate(It.Is<Func<BranchContacts, bool>>(a => a.GetType() == agencyContactsPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<BranchContacts>> { Result = new List<BranchContacts>() { branchContacts }, IsError = false }));
            
        }

        private Models.Request.Branch GetFakeBranchRequestModel()
        {
            Models.Request.Branch mockBranchRequest = new Models.Request.Branch
            {
                MGBranch = new Branch
                {

                    Name = "Insert Test",
                    AgencyId = 6,
                    Address1 = "Test Address Insert",
                    Address2 = "Add2",
                    CityId = 2,
                    CountryId = 4,
                    NameItemId = 1,
                    ZipCode = "13455",
                    CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"
                },

                BranchContacts = new List<BranchContacts>
                    {
                        new BranchContacts
                        {
                            ContactPerson = "Test Contact Insert",Email ="abc@abc.com",ContactNumber = "213242343",DesignationId = 1, CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"

                        },
                        new BranchContacts
                        {
                            ContactPerson = "Test Contact2 Insert",Email ="test@abc.com",ContactNumber = "45646546",DesignationId = 1, CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"

                        },
                         new BranchContacts
                        {
                            ContactPerson = "Test Contact3 Insert",Email ="test3@abc.com",ContactNumber = "45646546",
                             IsPrimary = true,DesignationId = 1, CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"
                        }
                    }

            };

            return mockBranchRequest;
        }

        private Models.Response.Branch GetFakeBranchResponseModel()
        {
            Models.Response.Branch fakeBranchResponseModel = new Models.Response.Branch()
            {
                MGBranch = new Branch
                {
                    Id= 1,
                    Name = "Insert Test",
                    AgencyId = 6,
                    Address1 = "Test Address Insert",
                    Address2 = "Add2",
                    CityId = 2,
                    CountryId = 4,
                    NameItemId = 1,
                    ZipCode = "13455",
                    CreatedBy = "MGIT",
                    UpdatedBy = "MGIT"
                },

                BranchContacts = new List<BranchContacts>
                    {
                        new BranchContacts
                        {
                            ContactPerson = "Test Contact Insert",Email ="abc@abc.com",ContactNumber = "213242343",DesignationId = 1, CreatedBy = "MGIT",
                    UpdatedBy = "MGIT",BranchId = 1

                        },
                        new BranchContacts
                        {
                            ContactPerson = "Test Contact2 Insert",Email ="test@abc.com",ContactNumber = "45646546",DesignationId = 1, CreatedBy = "MGIT",
                    UpdatedBy = "MGIT",BranchId = 1

                        },
                         new BranchContacts
                        {
                            ContactPerson = "Test Contact3 Insert",Email ="test3@abc.com",ContactNumber = "45646546",
                             IsPrimary = true,DesignationId = 1, CreatedBy = "MGIT",BranchId = 1,UpdatedBy = "MGIT"
                        }
                    }
            };

            return fakeBranchResponseModel;
        }
    }
}
