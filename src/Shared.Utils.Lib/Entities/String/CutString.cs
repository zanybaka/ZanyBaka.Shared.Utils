using ZanyBaka.Shared.Utils.Lib.Extensions;

namespace ZanyBaka.Shared.Utils.Lib.Entities.String
{
    public class CutString
    {
        private readonly string _input;

        public CutString(string input)
        {
            _input = input ?? "";
        }

        public string FirstNChars(int count, bool addEllipses)
        {
            return _input.FirstNChars(count, addEllipses);
        }

        public string FirstWordsButNotMoreThanNChars(int maxChars)
        {
            return _input.FirstWordsButNotMoreThanNChars(maxChars);
        }

        public string WithoutFirstWord(char delimiter = ' ')
        {
            return _input.SkipFirstWord(delimiter);
        }

        public override string ToString()
        {
            return _input;
        }
    }
}