namespace BookStore.Models.DataTransferObjects
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerMonth { get; set; }
        public int CategoryId { get; set; }

        public string Img { get; set; } = string.Empty;
    }
}
