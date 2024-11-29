using BookStore.Models.Entities;
using BookStore.Models.Interfaces;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly DbContext _dbContext;

        public UserTypeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserType> GetUserTypeByIdAsync(int userTypeId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_type_id", userTypeId);

                return await connection.QueryFirstOrDefaultAsync<UserType>("sp_GetUserType", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<UserType>("SELECT * FROM tblUserType");
            }
        }

        public async Task<int> CreateUserTypeAsync(UserType userType)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_type_name", userType.user_type_name);
                parameters.Add("@is_admin", userType.is_admin);
                parameters.Add("@is_third_party", userType.is_third_party);

                return await connection.ExecuteAsync("sp_CreateUserType", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUserTypeAsync(UserType userType)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_type_id", userType.user_type_id);
                parameters.Add("@user_type_name", userType.user_type_name);
                parameters.Add("@is_admin", userType.is_admin);
                parameters.Add("@is_third_party", userType.is_third_party);

                await connection.ExecuteAsync("sp_UpdateUserType", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUserTypeAsync(int userTypeId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_type_id", userTypeId);

                await connection.ExecuteAsync("sp_DeleteUserType", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
