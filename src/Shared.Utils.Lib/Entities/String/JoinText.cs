using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class JoinText
    {
        private readonly Lazy<string> _lazyValue;

        public JoinText(string[] input, string separator = " ")
        {
            _lazyValue = new Lazy<string>(() => string.Join(separator, input ?? new string[0]));
        }

        public static implicit operator string(JoinText obj)
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