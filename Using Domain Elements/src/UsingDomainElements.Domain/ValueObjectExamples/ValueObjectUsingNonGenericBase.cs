using Mendham;
using Mendham.Domain;

namespace MendhamSamples.UsingDomainElements.Domain.BaseValueObject
{
    public class ValueObjectUsingNonGenericBase : ValueObject
    {
        public string Value1 { get; private set; }
        public int Value2 { get; private set; }

        public ValueObjectUsingNonGenericBase(string value1, int value2)
        {
            this.Value1 = value1
                .VerifyArgumentNotNullOrEmpty("Value 1 is required");
            this.Value2 = value2
                .VerifyArgumentNotDefaultValue("Value 2 is required");
        }
    }
}
