using banqsoft_api.LoanCalculators;

namespace banqsoft_api.Models
{
    public class Loan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public LoanCalculator LoanCalculator { get; set; }
    }
}
