using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class SplitText
    {
        private readonly string _input;
        private readonly StringSplitOptions _options;
        private readonly string _separator;

        public SplitText(string input, StringSplitOptions options = StringSplitOptions.None, string separator = " ")
        {
            _separator = separator;
            _options   = options;
            _input     = input ?? "";
        }

        public static implicit operator string[](SplitText obj)
        {
            return obj.GetValue();
        }

        public string[] GetValue()
        {
            return _input.Split(new[] { _separator }, _options);
        }
    }
}