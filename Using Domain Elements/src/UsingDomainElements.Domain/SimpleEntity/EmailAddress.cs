using Mendham;
using Mendham.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MendhamSamples.UsingDomainElements.Domain.SimpleEntity
{
    public class EmailAddress : SingleFieldValueObject<string, EmailAddress>
    {
        public EmailAddress (string emailAddress)
            :base(emailAddress)
        {
            emailAddress.VerifyArgumentNotDefaultValue("Email address is required")
                .VerifyArgumentMeetsCriteria(IsValid, "Email address is not valid");
        }

        #region Email Validation Object
        // Logic from https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx

        public static bool IsValid(string emailAddress)
        {
            bool invalid = false;
            if (string.IsNullOrEmpty(emailAddress))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(emailAddress,
                      @"^.+@.+$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            domainName = idn.GetAscii(domainName);

            return match.Groups[1].Value + domainName;
        } 
        #endregion
    }
}
