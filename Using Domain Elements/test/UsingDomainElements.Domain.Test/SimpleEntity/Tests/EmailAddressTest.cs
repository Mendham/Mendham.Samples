using MendhamSamples.UsingDomainElements.Domain.SimpleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Tests
{
    public class EmailAddressTest
    {
        // This is a simple test to verify the value object validation and does not require a fixture

        [Theory]
        [InlineData("david.jones@proseware.com")]
        [InlineData("d.j@server1.proseware.com")]
        [InlineData("jones@ms1.proseware.com")]
        [InlineData("j@proseware.com9")]
        [InlineData("js#internal@proseware.com")]
        [InlineData("j_9@[129.126.118.1]")]
        [InlineData("js@proseware.com9")]
        [InlineData("j.s@server1.proseware.com")]
        [InlineData("\"j\\\"s\\\"\"@proseware.com")]
        [InlineData("js@contoso.中国")]
        public void EmailAddress_Valid_Constructs(string address)
        {
            var sut = new EmailAddress(address);

            Assert.Equal(address, sut.Value);
        }

        [InlineData("j.@server1.proseware.com")]
        [InlineData("j..s@proseware.com")]
        [InlineData("js*@proseware.com")]
        [InlineData("js@proseware..com")]
        [InlineData("")]
        [InlineData(null)]
        public void EmailAddress_Invalid_ArgumentException(string address)
        {
            Action sutAction = () => new EmailAddress(address);

            Assert.Throws<ArgumentException>(sutAction);
        }
    }
}
