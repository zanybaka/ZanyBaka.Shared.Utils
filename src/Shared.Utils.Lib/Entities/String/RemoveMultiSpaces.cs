using System;
using System.Text.RegularExpressions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class RemoveMultiSpaces
    {
        private readonly Lazy<string> _lazyValue;

        public RemoveMultiSpaces(string input)
        {
            _lazyValue = new Lazy<string>(() => Regex.Replace(input ?? "", @"\s+", " "));
        }

        public static implicit operator string(RemoveMultiSpaces obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return GetValue();
        }
    }
}