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
        [InlineData("jon.doe@test.com")]
        [InlineData("j.d@server1.test.com")]
        [InlineData("doe@aa1.test.com")]
        [InlineData("j@test.com9")]
        [InlineData("jd#internal@test.com")]
        [InlineData("j_9@[108.121.101.1]")]
        [InlineData("jd@test.com9")]
        [InlineData("j.d@server1.test.com")]
        [InlineData("\"j\\\"d\\\"\"@test.com")]
        [InlineData("jd@test.中国")]
        public void EmailAddress_Valid_Constructs(string address)
        {
            var sut = new EmailAddress(address);

            Assert.Equal(address, sut.Value);
        }

        [InlineData("hasNoAtSign")]
        [InlineData("@test")]
        [InlineData("test@")]
        [InlineData("")]
        [InlineData(null)]
        public void EmailAddress_Invalid_ArgumentException(string address)
        {
            Action sutAction = () => new EmailAddress(address);

            Assert.Throws<ArgumentException>(sutAction);
        }
    }
}
