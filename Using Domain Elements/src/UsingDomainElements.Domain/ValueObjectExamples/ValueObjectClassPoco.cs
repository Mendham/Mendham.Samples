using Mendham;
using Mendham.Domain;
using Mendham.Domain.Extensions;
using System.Collections.Generic;

namespace MendhamSamples.UsingDomainElements.Domain.ValueObjectExamples
{
    public class ValueObjectClassPoco : IValueObject<ValueObjectClassPoco>
    {
        public string Value1 { get; private set; }
        public int Value2 { get; private set; }       

        public ValueObjectClassPoco(string value1, int value2)
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

        public bool Equals(ValueObjectClassPoco other)
        {
            return this.IsEqualToValueObject(other);
        }

        public static bool operator ==(ValueObjectClassPoco a, ValueObjectClassPoco b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(ValueObjectClassPoco a, ValueObjectClassPoco b)
        {
            return !(a == b);
        }
    }
}
