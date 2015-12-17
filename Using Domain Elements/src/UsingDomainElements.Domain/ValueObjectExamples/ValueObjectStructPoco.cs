using Mendham;
using Mendham.Domain;
using Mendham.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.ValueObjectExamples
{
    public struct ValueObjectStructPoco : IValueObject<ValueObjectStructPoco>
    {
        public string Value1 { get; private set; }
        public int Value2 { get; private set; }

        public ValueObjectStructPoco(string value1, int value2)
        {
            this.Value1 = value1
                .VerifyArgumentNotNullOrEmpty("Value 1 is required");
            this.Value2 = value2
                .VerifyArgumentNotDefaultValue("Value 2 is required");
        }

        public IEnumerable<object> EqualityComponents
        {
            get
            {
                yield return Value1;
                yield return Value2;
            }
        }

        public override bool Equals(object obj)
        {
            return this.IsEqualToValueObject(obj);
        }

        public override int GetHashCode()
        {
            return this.GetValueObjectHashCode();
        }

        public bool Equals(ValueObjectStructPoco other)
        {
            return this.IsEqualToValueObject(other);
        }

        public static bool operator ==(ValueObjectStructPoco a, ValueObjectStructPoco b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(ValueObjectStructPoco a, ValueObjectStructPoco b)
        {
            return !(a == b);
        }
    }
}
