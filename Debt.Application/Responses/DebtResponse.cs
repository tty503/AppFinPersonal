namespace DebtApplication.Responses
{
    class DebtResponses
    {
        public Guid Id { get; set; }
        public TypeDebt Type { get; set; }
        public string CreditorName { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MonthlyFee { get; set; }
        public StatusDebt Status { get; set; }

        // Custom 
        public enum TypeDebt { CREDIT_CARD, MORTGAGE, PERSONAL_LOAN }
        public enum StatusDebt { ACTIVE, PAY, DELAY }
    }
}
