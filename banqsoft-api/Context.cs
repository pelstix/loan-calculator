using System.Collections.Generic;
using banqsoft_api.LoanCalculators;
using banqsoft_api.Models;

namespace banqsoft_api
{
    public interface IContext
    {
        IEnumerable<Loan> Loans { get; set; }
    }

    public class Context : IContext
    {
        public IEnumerable<Loan> Loans { get; set; }

        public Context()
        {
            Loans = new List<Loan>
            {
                new Loan() { Id = 1, Name = "Housing loan - 3.5%", LoanCalculator = new FixedInterestLoanCalculator(3.5M) },
            };
        }
    }
}
