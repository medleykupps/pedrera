using System;
using NLog;

namespace Pedrera.Core.Logger
{
    public class PedreraLogger : ILogger
    {
        private readonly GetContext _preSetTags;
        private readonly NLog.Logger _logger;

        public PedreraLogger(Type type, GetContext preSetTags = null)
        {
            _preSetTags = preSetTags;
            _logger = LogManager.GetLogger(type.FullName);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        public void Trace(string message, params object[] args)
        {
            _logger.Trace(message, args);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            var temp = String.Format(message, args);
            _logger.ErrorException(temp, exception);
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            var temp = String.Format(message, args);
            _logger.FatalException(temp, exception);
        }
    }
}
