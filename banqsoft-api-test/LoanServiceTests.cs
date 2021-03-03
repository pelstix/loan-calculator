using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using banqsoft_api.Services;
using banqsoft_api;
using banqsoft_api.Exceptions;
using banqsoft_api.Models;
using banqsoft_api.LoanCalculators;
using System.Linq;

namespace banqsoft_api_test
{
    public class LoanServiceTests
    {
        private ILoanService _loanService;
        private Mock<ILogger<LoanService>> _loggerMock;
        private Mock<IContext> _contextMock;
        private Loan _defaultLoan;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<LoanService>>();
            _contextMock = new Mock<IContext>();

            _defaultLoan = new Loan() { Id = 1, Name = "Test loan", LoanCalculator = new FixedInterestLoanCalculator(1.0M) };
            var loans = new List<Loan>
            {
                _defaultLoan,
            };

            _contextMock.SetupGet(x => x.Loans).Returns(loans);

            _loanService = new LoanService(_loggerMock.Object, _contextMock.Object);
        }

        [Test]
        public void ShouldValidateLoanAmountArgument()
        {
            var amount = 0.0M;

            Assert.That(
                () => this._loanService.CalculateLoanPayments(_defaultLoan.Id, amount, 1), 
                Throws.TypeOf<ArgumentException>()
            );

            _loggerMock.Verify(x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
                ),
                Times.Once()
            );
        }

        [Test]
        public void ShouldValidateLoanYearsDuration()
        {
            var yearsDuration = -1;

            Assert.That(
                () => this._loanService.CalculateLoanPayments(_defaultLoan.Id, 10000.0M, yearsDuration), 
                Throws.TypeOf<ArgumentException>()
            );

            _loggerMock.Verify(x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
                ),
                Times.Once()
            );
        }

        [Test]
        public void ShouldThrowExceptionWhenAccesingNotExistingLoan()
        {
            var notExistingLoanId = 10;

            Assert.That(
                () => this._loanService.CalculateLoanPayments(notExistingLoanId, 10000.0M, 1), 
                Throws.TypeOf<NotFoundException>()
            );
        }

        [Test]
        public void ShouldCorrectlyCalculatePaymentsPlan()
        {
            var loanAmount = 120000M;
            var loanYearsDuration = 10;

            var payments = _loanService.CalculateLoanPayments(_defaultLoan.Id, loanAmount, loanYearsDuration);

            Assert.AreEqual(1100M, payments.First().Value);
            Assert.AreEqual(1, payments.First().MonthNumber);
            Assert.AreEqual(1090M, payments.Skip(12).First().Value);
            Assert.AreEqual(13, payments.Skip(12).First().MonthNumber);
            Assert.AreEqual(1000.83M, payments.Last().Value);
            Assert.AreEqual(120, payments.Count());
        }
    }
}