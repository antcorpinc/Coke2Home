using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class AllocationsRepositoryTest : BaseTestFixture
    {
        #region private variables
        private IAllocations allocationsRepository;
        private Mock<IConnection<Calendar>> iCalendarLibrary;
        private Mock<IConfiguration> iConfiguration;
        #endregion
        #region settings
        public AllocationsRepositoryTest()
        {
            this.iCalendarLibrary = new Mock<IConnection<Calendar>>();
            this.iConfiguration = new Mock<IConfiguration>();
            this.allocationsRepository = new AllocationsRepository(iCalendarLibrary.Object, iConfiguration.Object);
        }
        #endregion
        [Test]
        public void TestGetDates_ListOfDates_Success()
        {
            var request = new DateViewModel()
            {
                EndDate = DateTime.Now.AddDays(7),
                StartDate = DateTime.Now
            };
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);
            var dates = new Calendar() { DateKey = 20180101, EnglishDayNameOfWeek = "Saturday", EnglishMonthName = "August" };
            var baseResult = new BaseResult<List<Calendar>>() { Result = new List<Calendar>() { dates } };
            var pred = new Func<Calendar, bool>(x => x.FullDateAlternatekey.Date >= startDate
                                                                     && x.FullDateAlternatekey.Date <= endDate && !x.IsDeleted);
            iCalendarLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Calendar, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));

            var dateList = allocationsRepository.GetDates(request);
            Assert.IsTrue(dateList != null);
            Assert.IsTrue(dateList.Result is BaseResult<List<Calendar>>);
        }
        [Test]
        public void TestGetDates_ListOfDates_Failed_BadRequest()
        {
            var request = new DateViewModel()
            {
                EndDate = DateTime.Now.AddDays(7),
                StartDate = DateTime.Now
            };
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);
            //var dates = new Calendar() { DateKey = 20180101, EnglishDayNameOfWeek = "Saturday", EnglishMonthName = "August" };
            var baseResult = new BaseResult<List<Calendar>>() { IsError=true,Message=Core.Model.Helper.Constants.ErrorMessage.StartDateEndDateViolation };
            var pred = new Func<Calendar, bool>(x => x.FullDateAlternatekey.Date >= startDate
                                                                     && x.FullDateAlternatekey.Date <= endDate && !x.IsDeleted);
            iCalendarLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Calendar, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));

            var dateList = allocationsRepository.GetDates(request);
            Assert.IsTrue(dateList != null);
            Assert.IsTrue(dateList.Result is BaseResult<List<Calendar>>);
        }

    }
}
