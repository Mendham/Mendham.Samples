using Mendham.Testing;
using MendhamSamples.UsingDomainElements.Domain.SimpleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Builders
{
    public class EmailAddressBuilder : Builder<EmailAddress>
    {
        private string emailAddress;
        public EmailAddressBuilder()
        {
            string baseString = CreateAnonymous("email");
            this.emailAddress = string.Format("{0}@{1}.com", baseString.Substring(0, 13), baseString.Substring(14, 8));
        }

        public EmailAddressBuilder WithAddress(string emailAddress)
        {
            this.emailAddress = new EmailAddress(emailAddress);
            return this;
        }

        protected override EmailAddress BuildObject()
        {
            return new EmailAddress(emailAddress);
        }
    }
}
