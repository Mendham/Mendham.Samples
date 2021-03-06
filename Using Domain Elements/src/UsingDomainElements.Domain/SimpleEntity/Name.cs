﻿using Mendham;
using Mendham.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class Name : ValueObject<Name>, IEquatable<Name>
    {
        public Name(string firstName, string lastName)
        {
            firstName.VerifyArgumentNotNullOrWhiteSpace("First name is required");
            lastName.VerifyArgumentNotNullOrWhiteSpace("Last name is required");

            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
