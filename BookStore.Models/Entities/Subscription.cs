namespace BookStore.Models.Entities
{
    public class Subscription
    {
        public int subscription_id { get; set; }
        public int user_id { get; set; }
        public int book_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string status { get; set; } = string.Empty;
    }
}
