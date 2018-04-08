using MG.Jarvis.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Helper
{
    public static class LogHelper
    {
        public static void LogInformation(ILogger logger, string module, string methodName, string message, string ClassName)
        {
            JarvisLog log = new JarvisLog
            {
                ApplicationName = "BackOfficeAPI-" + module,
                ClassName = ClassName,
                Message = message,
                MethodName = methodName,
            };
            logger.LogInformation(log);
        }

        public static void LogError(ILogger logger, string module, string methodName, string message, string ClassName, Exception exception, string statusCode, Dictionary<string, string> inputParameters)
        {
            JarvisErrorLog log = new JarvisErrorLog
            {
                ApplicationName = "BackOfficeAPI-" + module,
                ClassName = ClassName,
                Message = message,
                MethodName = methodName,
                Exception = exception,
                InputParameters = inputParameters,
                StatusCode = statusCode
            };
            logger.LogError(log);
        }

        public static void LogDebug(ILogger logger, string module, string methodName, string message, string ClassName)
        {

            JarvisLog log = new JarvisLog
            {
                ApplicationName = "BackOfficeAPI-" + module,
                ClassName = ClassName,
                Message = message,
                MethodName = methodName,
            };

            logger.LogDebug(log);
        }
    }
}
