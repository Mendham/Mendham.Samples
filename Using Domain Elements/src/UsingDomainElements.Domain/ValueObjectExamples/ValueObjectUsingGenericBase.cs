using Mendham;
using Mendham.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.ValueObjectExamples
{
    public class ValueObjectUsingGenericBase : ValueObject<ValueObjectUsingGenericBase> 
    {
        public string Value1 { get; private set; }
        public int Value2 { get; private set; }

        public ValueObjectUsingGenericBase(string value1, int value2)
        {
            this.Value1 = value1
                .VerifyArgumentNotNullOrEmpty("Value 1 is required");
            this.Value2 = value2
                .VerifyArgumentNotDefaultValue("Value 2 is required");
        }
    }
}
