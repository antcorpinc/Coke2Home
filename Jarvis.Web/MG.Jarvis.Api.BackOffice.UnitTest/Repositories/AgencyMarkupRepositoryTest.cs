using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Markup;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture, Category("backOffice")]
    public class AgencyMarkupRepositoryTest
    {
        private AgencyMarkupRepository agencyMarkupRepository;
        private Mock<IConnection<Core.Model.MasterData.AgencyMarkup>> iAgencyMarkupMock;
        
        public AgencyMarkupRepositoryTest()
        {
            iAgencyMarkupMock = new Mock<IConnection<Core.Model.MasterData.AgencyMarkup>>();
            agencyMarkupRepository = new AgencyMarkupRepository(iAgencyMarkupMock.Object);
        }

        [Test]
        public void TestAgencyMarkupRepositoryGetSuccess()
        {
            iAgencyMarkupMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null, IsError = false }));
            var result = agencyMarkupRepository.Get();
            Assert.IsFalse(result.Result.IsError);
        }

        [Test]
        public void TestAgencyMarkupRepositoryGetFail()
        {
            iAgencyMarkupMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null, IsError = true }));
            var result = agencyMarkupRepository.Get();
            Assert.IsTrue(result.Result.IsError);
        }
    }
}
