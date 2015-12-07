using Mendham;
using Mendham.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class CustomerId : SingleFieldValueObject<int, CustomerId>
    {
        public CustomerId(int value) : base(value)
        {
        }

        public override string ToString()
        {
            return string.Format("CustomerId [{0}]", base.Value);
        }
    }
}
