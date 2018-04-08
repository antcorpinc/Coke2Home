using Dapper;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture]
    public class AgentRepositoryTest
    {
        #region Private Variable
        private AgentRepository agentRepositoryMock;
        private Mock<IConnection<Agents>> iAgentsMock;

        #endregion Private Variable

        public AgentRepositoryTest()
        {

            iAgentsMock = new Mock<IConnection<Agents>>();

            agentRepositoryMock = new AgentRepository(iAgentsMock.Object);
        }

        [Test]
        public void TestAgentRepositoryGetSuccess()
        {
            List<Agents> list = new List<Agents>()
            {
                new Agents()
                {
                    Address1 = "danv",
                    AgencyId = 1,
                    AgencyBranchId = 1,
                    Id = 1
                }
            };
            
            Func<Agents, bool> func = s => s.IsActive && !s.IsDeleted;            
            iAgentsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agents, bool>>(y => y.GetType() == func.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agents>> { Result = list, IsError = false }));

            var result = agentRepositoryMock.Get();
            Assert.AreEqual(result.Result.Result.Count, 1);
        }

        [Test]
        public void TestAgentRepositoryGetFailure()
        {
            List<Agents> list = new List<Agents>()
            {
                new Agents()
                {
                    Address1 = "danv",
                    AgencyId = 1,
                    AgencyBranchId = 1,
                    Id = 1
                }
            };
            Func<Agents, bool> func = s => s.IsActive && !s.IsDeleted;
            
            iAgentsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agents, bool>>(y => y.GetType() == func.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agents>> { Result = list, IsError = true }));

            var result = agentRepositoryMock.Get();
            Assert.IsTrue(result.Result.IsError);
        }

        [Test]
        public void TestAgentRepositoryGetEmptyListFail()
        {
            Func<Agents, bool> func = s => s.IsActive && !s.IsDeleted;
            iAgentsMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Agents>> { Result = null, IsError = true }));
            iAgentsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agents, bool>>(y => y.GetType() == func.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agents>> { Result = null, IsError = false }));

            var result = agentRepositoryMock.Get();
            Assert.AreEqual(result.Result.Message, "List is Empty");
        }
    }
}