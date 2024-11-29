namespace BookStore.Models.Entities
{
    public class Book
    {
        public int book_id { get; set; }

        public string title { get; set; } = string.Empty;

        public string author { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public decimal price_per_month { get; set; }

        public int category_id { get; set; }

        public string img { get; set; } = string.Empty;
    }
}
