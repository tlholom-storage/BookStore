namespace BookStore.Models.Entities
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int subscription_id { get; set; }
        public DateTime payment_date { get; set; }
        public decimal amount { get; set; }
        public string payment_status { get; set; } = string.Empty;
        public string payment_method { get; set; } = string.Empty;
        public string payment_gateway_response { get; set; } = string.Empty;
    }
}
