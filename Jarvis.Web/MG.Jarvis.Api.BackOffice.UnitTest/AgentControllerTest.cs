using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgentRequest = MG.Jarvis.Api.BackOffice.Models.Request.Agent;
using AgentResponse = MG.Jarvis.Api.BackOffice.Models.Response.Agent;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class AgentControllerTest
    {
        #region Private Variables
        private AgentsController agentController;
        private Mock<IMasterData<AgentRequest, int>> iMasterDataMock;
        private Mock<ILogger> iLoggerMock;
        private Mock<IAgent> iAgentRepositoryMock;
        #endregion Private Variables

        public AgentControllerTest()
        {   
            iLoggerMock = new Mock<ILogger>();
            iMasterDataMock = new Mock<IMasterData<AgentRequest, int>>();
            iAgentRepositoryMock = new Mock<IAgent>();
            agentController = new AgentsController(iMasterDataMock.Object, iLoggerMock.Object, iAgentRepositoryMock.Object);
        }

        [Test]
        public void TestGetAllAgentsNullObjectReturnsNoContentFail()
        {
            iAgentRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<List<AgentResponse>>()));

            var result = agentController.Get().Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestGetAllAgentsReturnsAnErrorOrExceptionFail()
        {
            iAgentRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<AgentResponse>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = agentController.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllAgentsReturnOkSuccess()
        {
            List<AgentResponse> fakeAgentResponseList = new List<AgentResponse>();
            fakeAgentResponseList = this.GetFakeListOfAgentResponseModel();

            iAgentRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<AgentResponse>> { Result = fakeAgentResponseList, IsError = false }));

            var result = agentController.Get().Result;
            BaseResult<List<AgentResponse>> resultList = (result as OkObjectResult).Value as BaseResult<List<AgentResponse>>;
            
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestGetAllAgentsThrowsException()
        {
            iAgentRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = agentController.Get().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        private List<AgentResponse> GetFakeListOfAgentResponseModel()
        {
            List<AgentResponse> fakeAgentResponseList = new List<AgentResponse>();

            fakeAgentResponseList.Add(new AgentResponse
            {
                MGAgent = new Core.Model.Agency.Agents
                {
                    Id = 1,
                    Name = "Thomas",
                    Address1 = "Address1",
                    Address2 = "Address2",
                    AgencyId =1,
                    AgencyBranchId =1,
                    EmailAddress ="thomas@gta.com",
                    PhoneNumber = "3423424"
                }
            });

            return fakeAgentResponseList;
        }
    }
}
