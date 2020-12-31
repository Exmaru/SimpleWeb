using NLog;
using NLog.Config;
using NLog.Targets;
using OctopusV3.Core;
using System;
using System.Text;
using System.Web.Script.Serialization;

namespace WebEngine
{
    public class Logger : ILogHelper
    {
        private static NLog.Logger logger;

        private static readonly Lazy<Logger> lazy = new Lazy<Logger>(() => new Logger());
        public static Logger Current { get { return lazy.Value; } }

        private JavaScriptSerializer jsonHandler = new JavaScriptSerializer();

        private const string LoggerLevel = "LogLevel";

        public Logger()
        {
            LoggingConfiguration config = new LoggingConfiguration();
            FileTarget fileTarget = new FileTarget();
            fileTarget.Encoding = Encoding.UTF8;
            fileTarget.FileName = String.Format("{0}/LogData/{1}/{2}/{3}.txt", "${basedir}", "${level}", @"${date:format=yyyyMM}", @"${date:format=yyyyMMdd}");
            fileTarget.Layout = String.Format("[{0}] : {1}", @"${date:format=yyyy-MM-dd HH\:mm\:ss.fff}", "${message}");
            fileTarget.ConcurrentWrites = true;
            fileTarget.ArchiveFileName = String.Format("{0}\\backup\\{1}\\{2}_{3}.txt", "${basedir}", "${logger}", "${level}", @"${date:format=yyyyMMdd}");
            fileTarget.ArchiveAboveSize = 1024 * 1024 * 4;
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.MaxArchiveFiles = 30;
            config.AddTarget("file", fileTarget);
            LoggingRule rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;
            logger = LogManager.GetLogger(SimpleConfig.Current.GetString("AppID"));
        }

        public void Debug(string msg)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 5)
            {
                logger.Debug(msg);
            }
        }

        public void Debug<T>(T target)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 5)
            {
                logger.Debug(jsonHandler.Serialize(target));
            }
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }

        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Warn(string msg)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 3)
            {
                logger.Warn(msg);
            }
        }

        public void Fatal(string msg)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 4)
            {
                logger.Fatal(msg);
            }
        }

        public void Info(string msg)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 2)
            {
                logger.Info(msg);
            }
        }

        public void Info<T>(T target)
        {
            if (SimpleConfig.Current.GetInt(LoggerLevel) >= 2)
            {
                logger.Info(jsonHandler.Serialize(target));
            }
        }
    }
}