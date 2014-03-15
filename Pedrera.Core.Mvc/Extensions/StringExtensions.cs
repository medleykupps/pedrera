using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pedrera.Core.Mvc.Extensions
{
    public static class StringExtensions
    {
        public static string[] FromCsv(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new string[0];
            }

            var split = from piece in value.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;

            return split.ToArray();
        }
    }
}
