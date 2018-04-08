using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture, Category("backOffice")]
    public class RevenueMarkupRepositoryTest
    {
        private RevenueMarkupRepository revenueMarkupRepository;
        private Mock<IConnection<Core.Model.MasterData.RevenueMarkup>> iRevenueMarkupMock;

        public RevenueMarkupRepositoryTest()
        {
            iRevenueMarkupMock = new Mock<IConnection<Core.Model.MasterData.RevenueMarkup>>();
            revenueMarkupRepository = new RevenueMarkupRepository(iRevenueMarkupMock.Object);
        }

        [Test]
        public void TestRevenueMarkupRepositoryGetSuccess()
        {
            iRevenueMarkupMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null, IsError = false }));
            var result = revenueMarkupRepository.Get();
            Assert.IsFalse(result.Result.IsError);
        }

        [Test]
        public void TestRevenueMarkupRepositoryGetFail()
        {
            iRevenueMarkupMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null, IsError = true }));
            var result = revenueMarkupRepository.Get();
            Assert.IsTrue(result.Result.IsError);
        }
    }
}
