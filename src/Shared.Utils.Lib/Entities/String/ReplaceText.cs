using System;
using ZanyBaka.Shared.Utils.Lib.Extensions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class ReplaceText
    {
        private readonly StringComparison _comparison;
        private readonly string _input;
        private readonly string _new;
        private readonly string _old;

        public ReplaceText(string input, string old, string @new, StringComparison comparison = StringComparison.CurrentCulture)
        {
            _old        = old;
            _new        = @new;
            _comparison = comparison;
            _input      = input ?? "";
        }

        public static implicit operator string(ReplaceText obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _input.Replace(_old, _new, _comparison);
        }
    }
}