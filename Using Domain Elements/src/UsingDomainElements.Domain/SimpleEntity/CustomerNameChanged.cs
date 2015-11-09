using Mendham;
using Mendham.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class CustomerNameChanged : DomainEvent
    {
        public CustomerId Customer { get; private set; }
        public Name OriginalName { get; private set; }
        public Name CurrentName { get; private set; }

        public CustomerNameChanged(CustomerId customer, Name originalName, Name currentName)
        {
            customer.VerifyArgumentNotDefaultValue("Customer is required");
            originalName.VerifyArgumentNotDefaultValue("Original name is required");
            currentName.VerifyArgumentNotDefaultValue("Current name is required");

            this.Customer = customer;
            this.OriginalName = originalName;
            this.CurrentName = currentName;
        }
    }
}
