using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class ReplaceChar
    {
        private readonly Lazy<string> _lazyValue;

        public ReplaceChar(string input, char old, char @new)
        {
            _lazyValue = new Lazy<string>(() => Replace(input ?? "", old, @new));
        }

        public static implicit operator string(ReplaceChar obj)
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

        private string Replace(string input, char old, char @new)
        {
            return input.Replace(old, @new);
        }
    }
}