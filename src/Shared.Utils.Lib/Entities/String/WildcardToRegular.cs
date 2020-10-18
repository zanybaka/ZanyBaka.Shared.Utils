using System.Text.RegularExpressions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class WildcardToRegular
    {
        private readonly string _input;

        public WildcardToRegular(string input)
        {
            _input = input;
        }

        public static implicit operator string(WildcardToRegular obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return "^" + Regex.Escape(_input).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }
    }
}