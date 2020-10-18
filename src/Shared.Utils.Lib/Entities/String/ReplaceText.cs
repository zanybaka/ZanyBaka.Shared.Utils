using System;
using ZanyBaka.Shared.Utils.Lib.Extensions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class ReplaceText
    {
        private readonly Lazy<string> _lazyValue;

        public ReplaceText(string input, string old, string @new, StringComparison comparison = StringComparison.CurrentCulture)
        {
            _lazyValue = new Lazy<string>(() => Replace(input ?? "", old, @new, comparison));
        }

        public static implicit operator string(ReplaceText obj)
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

        // TODO: support NET5_0, NETCOREAPP symbols
        private string Replace(string input, string old, string @new, StringComparison comparison)
        {
            // NETSTANDARD2_0 || NETFRAMEWORK
            return input.Replace(old, @new, comparison);
        }
    }
}