namespace TransactionApplication.Responses
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public StatusType Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public Decimal Amount { get; set; }
        public String Description { get; set; }
        public Guid OwnerAccountId { get; set; }
        public Guid? DestinationAccountId { get; set; }


        // Custom Type 
        public enum StatusType { SUCESSFUL, PENDING, DENIED }
        public enum TransactionType { AMONG_ACCOUNTS, INCOME, EXPENSE }
    }
}
