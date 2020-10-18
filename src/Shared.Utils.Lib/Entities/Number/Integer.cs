namespace ZanyBaka.Shared.Utils.Lib.Entities.Number
{
    public class Integer
    {
        private readonly int _defaultValue;
        private readonly string _value;

        public Integer(string value, int defaultValue = 0)
        {
            _value        = value;
            _defaultValue = defaultValue;
        }

        public static implicit operator int(Integer obj)
        {
            return obj.Value();
        }

        public int Value()
        {
            if (string.IsNullOrEmpty(_value) || !int.TryParse(_value, out int result))
            {
                return _defaultValue;
            }

            return result;
        }
    }
}