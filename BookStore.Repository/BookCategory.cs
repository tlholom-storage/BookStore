using BookStore.Models.Entities;
using BookStore.Models.Interfaces;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly DbContext _dbContext;

        public BookCategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookCategory> GetBookCategoryByIdAsync(int categoryId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@category_id", categoryId);

                return await connection.QueryFirstOrDefaultAsync<BookCategory>("sp_GetBookCategory", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<BookCategory>("SELECT * FROM tblBookCategory");
            }
        }

        public async Task<int> CreateBookCategoryAsync(BookCategory category)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@category_name", category.category_name);

                return await connection.ExecuteAsync("sp_CreateBookCategory", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateBookCategoryAsync(BookCategory category)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@category_id", category.category_id);
                parameters.Add("@category_name", category.category_name);

                await connection.ExecuteAsync("sp_UpdateBookCategory", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteBookCategoryAsync(int categoryId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@category_id", categoryId);

                await connection.ExecuteAsync("sp_DeleteBookCategory", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
