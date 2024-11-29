using BookStore.Models.Entities;
using BookStore.Models.Interfaces;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_id", userId);

                return await connection.QueryFirstOrDefaultAsync<User>("sp_GetUser", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<User>("SELECT * FROM tblUser");
            }
        }

        public async Task<int> CreateUserAsync(User user)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@username", user.username);
                parameters.Add("@first_name", user.first_name);
                parameters.Add("@last_name", user.last_name);
                parameters.Add("@email", user.email);
                parameters.Add("@password_hash", user.password_hash);
                parameters.Add("@password_salt", user.password_salt);
                parameters.Add("@user_type_id", user.user_type_id);

                return await connection.ExecuteAsync("sp_CreateUser", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_id", user.user_id);
                parameters.Add("@username", user.username);
                parameters.Add("@first_name", user.first_name);
                parameters.Add("@last_name", user.last_name);
                parameters.Add("@email", user.email); 
                parameters.Add("@password_hash", user.password_hash);
                parameters.Add("@password_salt", user.password_salt);
                parameters.Add("@user_type_id", user.user_type_id);

                await connection.ExecuteAsync("sp_UpdateUser", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_id", userId);

                await connection.ExecuteAsync("sp_DeleteUser", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>($"SELECT * FROM tblUser where username = '{username}'");
            }
        }


    }
}
