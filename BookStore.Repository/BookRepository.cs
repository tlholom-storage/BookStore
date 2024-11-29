using BookStore.Models.Entities;
using BookStore.Models.Interfaces;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContext _dbContext;

        public BookRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@book_id", bookId);

                return await connection.QueryFirstOrDefaultAsync<Book>("sp_GetBook", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
          {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Book>("SELECT * FROM tblBook");
            }
        }

        public async Task<int> CreateBookAsync(Book book)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@title", book.title);
                parameters.Add("@author", book.author);
                parameters.Add("@description", book.description);
                parameters.Add("@price_per_month", book.price_per_month);
                parameters.Add("@category_id", book.category_id);
                parameters.Add("@img", book.img);

                return await connection.ExecuteAsync("sp_CreateBook", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@book_id", book.book_id);
                parameters.Add("@title", book.title);
                parameters.Add("@author", book.author);
                parameters.Add("@description", book.description);
                parameters.Add("@price_per_month", book.price_per_month);
                parameters.Add("@category_id", book.category_id);
                parameters.Add("@img", book.img);

                await connection.ExecuteAsync("sp_UpdateBook", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@book_id", bookId);

                await connection.ExecuteAsync("sp_DeleteBook", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
