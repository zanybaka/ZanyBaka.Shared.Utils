using System.Text.RegularExpressions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class IsMatchWildcard
    {
        private readonly string _input;
        private readonly string _wildcard;

        public IsMatchWildcard(string input, string wildcard)
        {
            _input    = input;
            _wildcard = wildcard;
        }

        public static implicit operator bool(IsMatchWildcard obj)
        {
            return obj.GetValue();
        }

        public bool GetValue()
        {
            return Regex.IsMatch(_input, new WildcardToRegular(_wildcard));
        }
    }
}