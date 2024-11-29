namespace BookStore.Models.DataTransferObjects
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentGatewayResponse { get; set; } = string.Empty;
    }
}
