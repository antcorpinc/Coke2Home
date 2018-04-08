using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.CacheBuilder;
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
    public class OccupancyCombinationsControllerTest
    {
        #region Private Variables
        private Mock<IMasterData<OccupancyCombinations, int>> _iOccupancyCombinationMock;
        private Mock<ILogger> _iLoggerMock;
        private OccupancyCombinationsController occupancyCombinationsControllerMock;
        #endregion Private Variables

        public OccupancyCombinationsControllerTest()
        {
            _iOccupancyCombinationMock = new Mock<IMasterData<OccupancyCombinations, int>>();
            _iLoggerMock = new Mock<ILogger>();
            occupancyCombinationsControllerMock = new OccupancyCombinationsController(_iOccupancyCombinationMock.Object, _iLoggerMock.Object);
        }

        [Test]
        public void TestOccupancyCombinationUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            OccupancyCombinations occupancyCombinations = new OccupancyCombinations
            {   
                Combination = 1,
                Description = "Occupancy Combination"
            };

            _iOccupancyCombinationMock.Setup(x => x.UpdateEntity(occupancyCombinations)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = occupancyCombinationsControllerMock.Update(occupancyCombinations).Result;
            Assert.That(result is BadRequestObjectResult);
        }
    }
}
