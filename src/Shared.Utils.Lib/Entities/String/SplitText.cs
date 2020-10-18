using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class SplitText
    {
        private readonly Lazy<string[]> _lazyValue;

        public SplitText(string input, StringSplitOptions options = StringSplitOptions.None, string separator = " ")
        {
            _lazyValue = new Lazy<string[]>(() => Split(input ?? "", options, separator));
        }

        public static implicit operator string[](SplitText obj)
        {
            return obj.GetValue();
        }

        public string[] GetValue()
        {
            return _lazyValue.Value;
        }

        private string[] Split(string input, StringSplitOptions options, string separator)
        {
            return input.Split(new[] { separator }, options);
        }
    }
}