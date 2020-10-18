namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class FormatString
    {
        private readonly object[] _args;
        private readonly string _input;

        public FormatString(string input, params object[] args)
        {
            _input = input;
            _args  = args;
        }

        public static implicit operator string(FormatString obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return string.Format(_input, _args);
        }
    }
}