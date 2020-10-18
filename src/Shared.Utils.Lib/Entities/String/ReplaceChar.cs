namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class ReplaceChar
    {
        private readonly string _input;
        private readonly char _new;
        private readonly char _old;

        public ReplaceChar(string input, char old, char @new)
        {
            _old   = old;
            _new   = @new;
            _input = input ?? "";
        }

        public static implicit operator string(ReplaceChar obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _input.Replace(_old, _new);
        }
    }
}