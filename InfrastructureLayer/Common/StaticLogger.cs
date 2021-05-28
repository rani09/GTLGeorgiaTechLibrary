using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace InfrastructureLayer.Common
{
    public static class StaticLogger
    {
        public static void LogInfo(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Info(text);
        }

        public static void LogWarn(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Warn(text);
        }

        public static void LogDebug(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Debug(text);
        }

        public static void LogTrace(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Trace(text);
        }

        public static void LogError(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Error(text);
        }

        public static void LogFatal(Type declareingType, string text)
        {
            LogManager.GetLogger(declareingType.FullName).Fatal(text);
        }
    }
}
