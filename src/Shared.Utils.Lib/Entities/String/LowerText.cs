using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class LowerText
    {
        private readonly Lazy<string> _lazyValue;

        public LowerText(string input)
        {
            _lazyValue = new Lazy<string>(() => (input ?? "").ToLower());
        }

        public static implicit operator string(LowerText obj)
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