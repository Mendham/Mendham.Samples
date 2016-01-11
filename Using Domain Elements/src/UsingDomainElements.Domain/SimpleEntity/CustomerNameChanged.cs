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

        public void SomeMethod(object objValue, int intVal, string strValue)
        {
            objValue.VerifyArgumentNotNull(nameof(objValue));
            intVal.VerifyArgumentMeetsCriteria(nameof(intVal), num => num > 0, "intVal must be greater than zero");
            strValue.VerifyArgumentNotNullOrWhiteSpace(nameof(strValue));

            // Do Something
        }

        public void SomeMethod(string strValue)
        {
            strValue.VerifyArgumentNotNull(nameof(strValue))
                .VerifyArgumentLength(nameof(strValue), 2, 5)
                .VerifyArgumentMeetsCriteria(nameof(strValue), str => !str.Contains("$"), "strValue cannot contain a $");
        }
    }

    public class MyClass
    {
        private readonly int _intVal;
        private readonly string _strVal;

        public MyClass(int intVal, string strValue)
        {
            _intVal = intVal
                .VerifyArgumentMeetsCriteria(nameof(intVal), num => num > 0, "intVal must be greater than zero");
            _strVal = strValue
                .VerifyArgumentNotNullOrWhiteSpace(nameof(strValue));
        }
    }
}
