using System;

namespace banqsoft_api.LoanCalculators
{
    public class FixedInterestLoanCalculator : LoanCalculator
    {
        private readonly decimal _interest;
        public FixedInterestLoanCalculator(decimal interest)
        {
            _interest = interest;
        }

        public override decimal CalculateMonthPaymentValue(int monthNumber, decimal loanAmount, int loanYearsDuration)
        {
            var loanMonthsDuration = loanYearsDuration * 12;
            var monthLoanAmount = loanAmount / loanMonthsDuration;

            var loanLeftAmount = loanAmount - ((monthNumber - 1) * monthLoanAmount);

            var monthInterest = loanLeftAmount * (_interest / 1200);

            var monthPaymentValue = Math.Round(monthLoanAmount + monthInterest, 2);
            return monthPaymentValue;
        }
    }
}
