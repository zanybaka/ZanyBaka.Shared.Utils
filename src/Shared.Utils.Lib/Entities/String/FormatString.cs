using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class FormatString
    {
        private readonly object[] _args;
        private readonly string _input;

        public FormatString(string input, params object[] args)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            _input = input;
            _args  = args;
        }

        public static implicit operator string(FormatString obj)
        {
            return obj.ToString();
        }

        public override string ToString()
        {
            return string.Format(_input, _args);
        }
    }
}