using Mendham;
using Mendham.Domain;
using Mendham.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class Customer : Entity
    {
        private readonly IFacade facade;

        public Customer(CustomerId id, Name name, IFacade facade)
        {
            id.VerifyArgumentNotDefaultValue("CustomerId is required");
            name.VerifyArgumentNotDefaultValue("Name is required");
            facade.VerifyArgumentNotDefaultValue("Facade is requird");

            this.Id = id;
            this.Name = name;
            this.facade = facade;
        }

        public CustomerId Id { get; private set; }
        public Name Name { get; private set; }

        public async Task<Name> UpdateNameAsync(Name name)
        {
            name.VerifyArgumentNotDefaultValue("Name is required");

            var originalName = this.Name;
            this.Name = name;

            await facade.SaveCustomerAsync(this);
            await facade.RaiseEventAsync(new CustomerNameChanged(this.Id, originalName, this.Name));

            return this.Name;
        }

        protected override IEnumerable<object> EqualityComponents
        {
            get
            {
                yield return Id;
            }
        }

        public override string ToString()
        {
            return string.Format("Customer [Id: {0}, Name: {1}]", Id.Value, Name);
        }

        public interface IFacade : IDomainFacade
        {
            Task<Customer> SaveCustomerAsync(Customer customer);
        }

        public class Facade : DomainFacade, IFacade
        {
            private readonly ICustomerRepository customerRepo;

            public Facade(ICustomerRepository customerRepo,
                IDomainEventPublisherProvider domainEventPublisherProvider) : base(domainEventPublisherProvider)
            {
                this.customerRepo = customerRepo;
            }

            public Task<Customer> SaveCustomerAsync(Customer customer)
            {
                return customerRepo.SaveAsync(customer);
            }
        }
    }
}
