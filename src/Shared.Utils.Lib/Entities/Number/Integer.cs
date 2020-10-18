using System;
using System.Globalization;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Number
{
    public class Integer
    {
        private readonly Lazy<int> _lazyValue;
        private readonly string _value;

        public Integer(string value, int defaultValue = 0)
        {
            _lazyValue = new Lazy<int>(() => Convert(value, defaultValue));
            _value     = value;
        }

        public Integer(string value, NumberStyles numberStyles, IFormatProvider formatProvider, int defaultValue = 0)
        {
            _lazyValue = new Lazy<int>(() => Convert(value, defaultValue, numberStyles, formatProvider));
            _value     = value;
        }

        public static implicit operator int(Integer obj)
        {
            return obj.GetValue();
        }

        public int GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return _value;
        }

        private int Convert(string value, int defaultValue)
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
            {
                return defaultValue;
            }

            return result;
        }

        private int Convert(string value, int defaultValue, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, numberStyles, formatProvider, out int result))
            {
                return defaultValue;
            }

            return result;
        }
    }
}