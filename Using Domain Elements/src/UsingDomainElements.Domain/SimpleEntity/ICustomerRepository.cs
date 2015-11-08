using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(CustomerId id);
        Task<Customer> SaveAsync(Customer customer);
    }
}
