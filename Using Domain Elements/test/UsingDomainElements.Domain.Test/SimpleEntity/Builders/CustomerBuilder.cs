using Mendham.Testing;
using Mendham.Testing.Moq;
using MendhamSamples.UsingDomainElements.Domain.SimpleEntity;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Builders
{
    public class CustomerBuilder : Builder<Customer>, IEntityBuilder<Customer, Customer.IFacade, CustomerBuilder>
    {
        private CustomerId id;
        private Name name;
        private EmailAddress emailAddress;

        private Customer.IFacade facade;

        public CustomerBuilder()
        {
            this.id = CreateAnonymous<CustomerId>();
            this.name = CreateAnonymous<Name>();
            this.emailAddress = new EmailAddressBuilder().Build();

            this.facade = DomainFacadeMock.Of<Customer.IFacade>();
        }

        public CustomerBuilder WithId(CustomerId id)
        {
            this.id = id;
            return this;
        }

        public CustomerBuilder WithName(Name name)
        {
            this.name = name;
            return this;
        }

        public CustomerBuilder WithEmailAddress(EmailAddress emailAddress)
        {
            this.emailAddress = emailAddress;
            return this;
        }

        public CustomerBuilder WithFacade(Customer.IFacade facade)
        {
            this.facade = facade;
            return this;
        }

        protected override Customer BuildObject()
        {
            return new Customer(id, name, emailAddress, facade);
        }
    }
}
