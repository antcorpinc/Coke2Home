using MG.Jarvis.Api.Extranet.Helper;
using NUnit.Framework;
using System;

namespace MG.Jarvis.Api.Extranet.Test
{
    [TestFixture]
    public class CommonTest
    {
        #region Public Variables
        #endregion Public Variables
        [Test]
        public void Test_JakartaOffset()
        {
            DateTime currentDate = DateTime.Now;
            DateTime date = currentDate.JakartaOffset();
            Assert.AreEqual(date, currentDate.ToUniversalTime().AddHours(7));
        }

        [Test]
        public void Test_JakartaOffset2()
        {
            string currentDate = DateTime.Now.ToLongDateString();
            DateTime date = currentDate.JakartaOffset();
            Assert.AreEqual(date, Convert.ToDateTime(currentDate).ToUniversalTime().AddHours(7));
        }
    }
}
