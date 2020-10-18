using System;
using System.Text.RegularExpressions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class WildcardToRegular
    {
        private readonly string _input;

        public WildcardToRegular(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }

            _input = input;
        }

        public static implicit operator string(WildcardToRegular obj)
        {
            return obj.Convert();
        }

        private string Convert()
        {
            return "^" + Regex.Escape(_input).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }
    }
}