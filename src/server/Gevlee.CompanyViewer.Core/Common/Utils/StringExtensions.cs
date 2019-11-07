using System;
using System.Text.RegularExpressions;

namespace Gevlee.CompanyViewer.Core.Common.Utils
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var noLeadingUndescore = Regex.Replace(input, @"^_", "");
            return Regex.Replace(noLeadingUndescore, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
