namespace banqsoft_api.Models
{
    public class LoanCalculateRequest
    {
        public long LoanId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanYearsDuration { get; set; }
    }
}
