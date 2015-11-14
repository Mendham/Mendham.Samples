using Mendham.Testing;
using MendhamSamples.UsingDomainElements.Domain.SimpleEntity;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Builders
{
    public class EmailAddressBuilder : DataBuilder<EmailAddress>
    {
        private EmailAddress emailAddress;
        public EmailAddressBuilder()
        {
            AutoFixture.Register<string, EmailAddress>(a =>
                new EmailAddress(string.Format("{0}@{1}.com", a.Substring(0, 8), a.Substring(9, 8))));

            this.emailAddress = AutoFixture.Create<EmailAddress>();
        }

        public EmailAddressBuilder WithAddress(string emailAddress)
        {
            this.emailAddress = new EmailAddress(emailAddress);
            return this;
        }

        protected override EmailAddress BuildObject()
        {
            return emailAddress;
        }
    }
}
