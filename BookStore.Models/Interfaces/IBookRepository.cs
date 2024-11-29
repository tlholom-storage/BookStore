using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface IBookRepository
    {
        Task<int> CreateBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task UpdateBookAsync(Book book);
    }
}