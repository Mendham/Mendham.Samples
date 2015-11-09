using Mendham.Testing;
using Mendham.Testing.Moq;
using MendhamSamples.UsingDomainElements.Domain.SimpleEntity;
using MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Builders;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MendhamSamples.UsingDomainElements.Domain.Test.SimpleEntity.Tests
{
    public class CustomerTest : EntityUnitTest<Customer, Customer.IFacade, CustomerBuilder>
    {
        public CustomerTest(EntityFixture<Customer, Customer.IFacade, CustomerBuilder> fixture) : base(fixture)
        {
        }

        [Theory]
        [AutoData]
        public async Task UpdateName_ValidName_ChangesName(CustomerId customerId, Name originalName, Name currentName)
        {
            var sut = TestFixture.GetSutBuilder()
                .WithId(customerId)
                .WithName(originalName)
                .Build();
            TestFixture.Facade.AsMock()
                .Setup(a => a.SaveCustomerAsync(sut))
                .ReturnsAsync(sut);

            var result = await sut.UpdateNameAsync(currentName);

            Assert.Equal(currentName, result);
            TestFixture.Facade.AsMock()
                .Verify(a => a.SaveCustomerAsync(sut), Times.Once);
            TestFixture.DomainEventPublisherFixture
                .VerifyDomainEventRaised<CustomerNameChanged>(c =>
                    c.Customer == customerId &&
                    c.OriginalName == originalName &&
                    c.CurrentName == currentName);
        }
    }
}
