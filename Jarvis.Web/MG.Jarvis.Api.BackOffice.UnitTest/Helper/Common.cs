using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Helper
{
    public static class Common
    {
        #region Helper Methods
        public static Exception GetMockException()
        {
            try
            {
                throw new MyException("Mock Exception");

            }
            catch (Exception e)
            {

                return e;
            }
        }
        #endregion Helper MEthods
    }

    public class MyException : Exception
    {
        public MyException()
        { }
        public MyException(string errorMsg) : base(errorMsg) { }
        public MyException(string errorMsg, Exception ex) { }
    }
}

