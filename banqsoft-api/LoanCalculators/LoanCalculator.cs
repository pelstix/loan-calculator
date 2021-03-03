using System.Collections.Generic;
using System.Linq;
using banqsoft_api.Models;

namespace banqsoft_api.LoanCalculators
{
    public abstract class LoanCalculator
    {
        public IEnumerable<LoanPayment> CalculatePayments(decimal loanAmount, int loanYearsDuration)
        {
            var payments = System.Linq.Enumerable
                .Range(1, loanYearsDuration * 12)
                .Select(monthNumber =>
                    new LoanPayment
                    {
                        MonthNumber = monthNumber,
                        Value = CalculateMonthPaymentValue(monthNumber, loanAmount, loanYearsDuration)
                    }
                );

            return payments;
        }

        public abstract decimal CalculateMonthPaymentValue(int monthNumber, decimal loanAmount, int loanYearsDuration);
    }
}
