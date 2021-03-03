using System;
using System.Collections.Generic;
using banqsoft_api.Models;
using banqsoft_api.Services;
using banqsoft_api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banqsoft_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService _loanService;

        public LoanController(
            ILogger<LoanController> logger,
            ILoanService loanService
        ) {
            _logger = logger;
            _loanService = loanService;
        }

        [HttpGet]
        public IEnumerable<LoanExtract> GetAvailableLoans()
        {
            var loans = _loanService.GetAvailableLoans();
            return loans;
        }

        [HttpPost("calculate")]
        public ActionResult<IEnumerable<LoanPayment>> CalculateLoan(LoanCalculateRequest request)
        {
            _logger.LogInformation($"Received request to calculate loan payments");
            IEnumerable<LoanPayment> payments;

            try
            {
                payments = _loanService.CalculateLoanPayments(request.LoanId, request.LoanAmount, request.LoanYearsDuration);
            }
            catch(ArgumentException) 
            {
                return BadRequest();
            }
            catch(NotFoundException)
            {
                return NotFound();
            }

            return Ok(payments);
        }
    }
}
