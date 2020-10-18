using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class JoinText
    {
        private readonly Lazy<string> _lazyValue;

        public JoinText(string[] input, string separator = " ")
        {
            _lazyValue = new Lazy<string>(() => string.Join(separator, input));
        }

        public static implicit operator string(JoinText obj)
        {
            return obj.Value();
        }

        public string Value()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return Value();
        }
    }
}