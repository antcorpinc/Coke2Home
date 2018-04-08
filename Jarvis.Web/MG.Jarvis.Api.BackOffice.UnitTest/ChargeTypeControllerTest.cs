using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class ChargeTypeControllerTest
    {
        #region private variable
        private ChargeTypeController mockChargeTypeController;
        private Mock<IMasterData<ChargeTypes, int>> ChargeTypeMock;
        private Mock<ILogger> loggerMock;
        #endregion Private Variables

        public ChargeTypeControllerTest()
        {
            ChargeTypeMock = new Mock<IMasterData<ChargeTypes, int>>();
            loggerMock = new Mock<ILogger>();
            mockChargeTypeController = new ChargeTypeController(ChargeTypeMock.Object, loggerMock.Object);
        }

        [Test]

        public void TestChargeTypeControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            ChargeTypes chargeType = new ChargeTypes
            {
                ChargeType = "Percentage",
                IsDeleted = false
            };

            ChargeTypeMock.Setup(x => x.UpdateEntity(chargeType)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = mockChargeTypeController.Update(chargeType).Result;
            Assert.That(result is BadRequestObjectResult);
        }
    }
}
