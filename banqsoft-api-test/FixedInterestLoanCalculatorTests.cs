using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using banqsoft_api.Services;
using banqsoft_api;
using banqsoft_api.Exceptions;
using banqsoft_api.Models;
using banqsoft_api.LoanCalculators;

namespace banqsoft_api_test
{
    public class FixedInterestLoanCalculatorTests
    {
        [TestCase("3.5", 1, "1200.0", 1, "103.5")]
        [TestCase("3.5", 2, "1200.0", 1, "103.21")]
        [TestCase("3.5", 3, "1200.0", 1, "102.92")]
        [TestCase("10", 12, "3600.0", 3, "120.83")]
        public void ShouldThrowExceptionWhenAccesingNotExistingLoan(string interestRate, int monthNumber, string loanAmout, int loanYearsDuration, string expectedPayment)
        {
            var decimalInterestRate = Convert.ToDecimal(interestRate, NumberFormatInfo.InvariantInfo);
            var decimalLoanAmout = Convert.ToDecimal(loanAmout, NumberFormatInfo.InvariantInfo);
            var decimalExpectedPayment = Convert.ToDecimal(expectedPayment, NumberFormatInfo.InvariantInfo);

            var calculator = new FixedInterestLoanCalculator(decimalInterestRate);

            var payment = calculator.CalculateMonthPaymentValue(monthNumber, decimalLoanAmout, loanYearsDuration);

            Assert.AreEqual(decimalExpectedPayment, payment);
        }
    }
}
