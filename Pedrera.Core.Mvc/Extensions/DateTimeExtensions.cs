using System;
using System.Data.SqlTypes;

namespace Pedrera.Core.Mvc.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime VerifyWithinSqlBounds(this DateTime value)
        {
            if (value < SqlDateTime.MinValue.Value)
                return SqlDateTime.MinValue.Value;
            if (value > SqlDateTime.MaxValue.Value)
                return SqlDateTime.MaxValue.Value;
            return value;
        }
    }
}
