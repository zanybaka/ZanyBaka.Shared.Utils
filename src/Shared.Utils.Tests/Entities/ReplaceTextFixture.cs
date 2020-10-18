using System;
using FluentAssertions;
using NUnit.Framework;
using ZanyBaka.Shared.Utils.Lib.Entities.String;

namespace ZanyBaka.Shared.Utils.Tests.Entities
{
    [TestFixture]
    public class ReplaceTextFixture
    {
        [Test]
        public void ACharToACharTest()
        {
            new ReplaceText("1", "1", "2").GetValue().Should().Be("2");
        }

        [Test]
        public void ACharToEmptyTest()
        {
            new ReplaceText("1", "1", "").GetValue().Should().Be("");
        }

        [Test]
        public void CaseInsensitiveTest()
        {
            new ReplaceText("1 AbC 2 ABC abc", "abc", "_", StringComparison.CurrentCultureIgnoreCase).GetValue().Should().Be("1 _ 2 _ _");
        }

        [Test]
        public void CaseSensitiveTest()
        {
            new ReplaceText("1 AbC 2 ABC abc", "abc", "_").GetValue().Should().Be("1 AbC 2 ABC _");
        }

        [Test]
        public void EmptyTest()
        {
            new ReplaceText("", "", "").GetValue().Should().Be("");
        }

        [Test]
        public void SimpleTest()
        {
            new ReplaceText("1 abc 2", "b", " ").GetValue().Should().Be("1 a c 2");
        }
    }
}