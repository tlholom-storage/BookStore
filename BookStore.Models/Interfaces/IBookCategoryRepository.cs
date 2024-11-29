using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface IBookCategoryRepository
    {
        Task<int> CreateBookCategoryAsync(BookCategory category);
        Task DeleteBookCategoryAsync(int categoryId);
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync();
        Task<BookCategory> GetBookCategoryByIdAsync(int categoryId);
        Task UpdateBookCategoryAsync(BookCategory category);
    }
}