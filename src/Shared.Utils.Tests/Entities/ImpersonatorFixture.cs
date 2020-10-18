#if NETFRAMEWORK
using System.Security.Principal;
using FluentAssertions;
using NUnit.Framework;
using ZanyBaka.Shared.Utils.Lib.Entities.Security;

namespace ZanyBaka.Shared.Utils.Tests.Entities
{
    [TestFixture]
    public class ImpersonatorFixture
    {
        [Test]
        public void LoginLogoffTest()
        {
            WindowsImpersonationContext context = Impersonator.LogOn("login", "passw", "domain");
            context.Should().NotBeNull();

            bool logOff = Impersonator.LogOff(context);
            logOff.Should().BeTrue();
        }
    }
}
#endif