using Mendham;
using Mendham.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class CustomerId : SingleFieldValueObject<int>, IEquatable<CustomerId>
    {
        public CustomerId(int value) : base(value)
        {
        }

        public bool Equals(CustomerId other)
        {
            return object.Equals(this, other);
        }

        public override string ToString()
        {
            return string.Format("CustomerId [{0}]", base.Value);
        }
    }
}
