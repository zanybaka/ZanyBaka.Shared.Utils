using FluentAssertions;
using NUnit.Framework;
using ZanyBaka.Shared.Utils.Lib.Entities.String;

namespace ZanyBaka.Shared.Utils.Tests.Entities
{
    [TestFixture]
    public class CutStringFixture
    {
        [Test]
        [TestCase("1 2 3 4 5 abc def", 0, false, "")]
        [TestCase("1 2 3 4 5 abc def", 0, true, "...")]
        [TestCase("1 2 3 4 5 abc def", 1, false, "1")]
        [TestCase("1 2 3 4 5 abc def", 1, true, "...")]
        [TestCase("1 2 3 4 5 abc def", 3, false, "1 2")]
        [TestCase("1 2 3 4 5 abc def", 3, true, "...")]
        [TestCase("1 2 3 4 5 abc def", 4, false, "1 2 ")]
        [TestCase("1 2 3 4 5 abc def", 4, true, "1...")]
        [TestCase("1 2 3 4 5 abc def", 300, false, "1 2 3 4 5 abc def")]
        [TestCase("1 2 3 4 5 abc def", 300, true, "1 2 3 4 5 abc def")]
        public void FirstNCharsTest(string input, int count, bool addEllipsis, string result)
        {
            new CutString(input).FirstNChars(count, addEllipsis).Should().Be(result);
        }

        [Test]
        [TestCase(null, 0, "")]
        [TestCase("1 2 3 4 5 abc def", 0, "")]
        [TestCase("1 2 3 4 5 abc def", 1, "1")]
        [TestCase("1 2 3 4 5 abc def", 3, "1 2")]
        [TestCase("1 2 3 4 5 abc def", 4, "1 2")]
        [TestCase("1 2 3 4 5 abc def", 16, "1 2 3 4 5 abc")]
        [TestCase("1 2 3 4 5 abc def", 17, "1 2 3 4 5 abc def")]
        [TestCase("1 2 3 4 5 abc def", 18, "1 2 3 4 5 abc def")]
        [TestCase(" 1 2 3 4 5 abc def", 300, " 1 2 3 4 5 abc def")]
        [TestCase(" 1 2 3 4 5 abc def", 5, " 1 2")]
        public void FirstWordsButNotMoreThanNCharsTest(string input, int maxChars, string result)
        {
            new CutString(input).FirstWordsButNotMoreThanNChars(maxChars).Should().Be(result);
        }

        [Test]
        [TestCase(null, null, "")]
        [TestCase("abc def", ' ', "def")]
        [TestCase(" abc def", ' ', "abc def")]
        public void SkipFirstWordTest(string input, char delimeter, string result)
        {
            new CutString(input).WithoutFirstWord(delimeter).Should().Be(result);
        }
    }
}