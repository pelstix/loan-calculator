using System;
using banqsoft_api.Models;

namespace banqsoft_api.ExtensionMethods
{
    public static class LoanExtensions
    {
        public static LoanExtract ToLoanExtract(this Loan loan)
        {
            return new LoanExtract()
            {
                Id = loan.Id,
                Name = loan.Name,
            };
        }
    }
}
