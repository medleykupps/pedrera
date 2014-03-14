using System;

namespace Pedrera.Core.Logger
{
    public interface ILogger
    {
        void Debug(string message, params object[] args);
        void Trace(string message, params object[] args);
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Error(Exception exception, string message, params object[] args);
        void Fatal(Exception exception, string message, params object[] args);
    }

    public static class GetLogger
    {
        public static ILogger For<T>(GetContext ctxCallback = null)
        {
            return new PedreraLogger(typeof(T), ctxCallback);
        }

        public static ILogger For(Type type, GetContext ctx = null)
        {
            return new PedreraLogger(type, ctx);
        }
    }

    public delegate LogTags GetContext();

}
