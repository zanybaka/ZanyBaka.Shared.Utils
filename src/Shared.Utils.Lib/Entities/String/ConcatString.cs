namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class ConcatString
    {
        private readonly string _a;
        private readonly string _b;

        public ConcatString(string a, string b)
        {
            _a = a;
            _b = b;
        }

        public static implicit operator string(ConcatString obj)
        {
            return obj.ToString();
        }

        public override string ToString()
        {
            return $"{_a}{_b}";
        }
    }
}