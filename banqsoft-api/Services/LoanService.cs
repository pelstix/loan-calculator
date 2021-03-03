using System;
using System.Collections.Generic;
using System.Linq;
using banqsoft_api.LoanCalculators;
using banqsoft_api.Models;
using banqsoft_api.ExtensionMethods;
using Microsoft.Extensions.Logging;
using banqsoft_api.Exceptions;

namespace banqsoft_api.Services
{
    public interface ILoanService
    {
        IEnumerable<LoanExtract> GetAvailableLoans();
        IEnumerable<LoanPayment> CalculateLoanPayments(long loanId, decimal loanAmount, int loanYearsDuration);
    }

    public class LoanService : ILoanService
    {
        private readonly ILogger<LoanService> _logger;
        private readonly IContext _context;

        public LoanService(
            ILogger<LoanService> logger,
            IContext context
        ) {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<LoanExtract> GetAvailableLoans()
        {
            var loans = _context.Loans.Select(x => x.ToLoanExtract());
            return loans;
        }

        public IEnumerable<LoanPayment> CalculateLoanPayments(long loanId, decimal loanAmount, int loanYearsDuration)
        {
            if (loanAmount <= 0)
            {
                _logger.LogWarning($"{nameof(loanAmount)} must be positive");
                throw new ArgumentException();
            }

            if (loanYearsDuration <= 0)
            {
                _logger.LogWarning($"{nameof(loanYearsDuration)} must be positive");
                throw new ArgumentException();
            }

            var loan = _context.Loans.FirstOrDefault(x => x.Id == loanId);

            if (loan == null)
            {
                _logger.LogWarning($"Tried to calculate loan payments for not existing loan ({nameof(loanId)}={loanId})");
                throw new NotFoundException();
            }

            _logger.LogInformation($"Starting calculation of loan payments", new { loanId, loanAmount, loanYearsDuration });
            var payments = loan.LoanCalculator.CalculatePayments(loanAmount, loanYearsDuration);
            _logger.LogInformation($"Finished calculation of loan payments");

            return payments;
        }
    }
}
