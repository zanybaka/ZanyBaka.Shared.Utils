namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class Substring
    {
        private readonly string _input;

        public Substring(string input)
        {
            _input = input ?? "";
        }

        public string Left(int count)
        {
            return _input.Substring(0, count);
        }

        public string Right(int count)
        {
            return _input.Substring(_input.Length - count, count);
        }

        public string From(int position)
        {
            if (position >= _input.Length)
            {
                return _input;
            }

            return _input.Substring(position);
        }

        public string From(int position, int count)
        {
            if (position >= _input.Length)
            {
                return _input;
            }

            return _input.Substring(position, count);
        }
    }
}