using BookStore.Models.Interfaces;
using BookStore.Models.Entities;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DbContext _dbContext;

        public SubscriptionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@subscription_id", subscriptionId);

                return await connection.QueryFirstOrDefaultAsync<Subscription>("sp_GetSubscription", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Subscription>("SELECT * FROM tblSubscription");
            }
        }

        public async Task<int> CreateSubscriptionAsync(Subscription subscription)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@start_date", subscription.start_date);
                parameters.Add("@end_date", subscription.end_date);
                parameters.Add("@user_id", subscription.user_id);
                parameters.Add("@book_id", subscription.book_id);
                parameters.Add("@status", subscription.status);

                return await connection.ExecuteAsync("sp_CreateSubscription", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateSubscriptionAsync(Subscription subscription)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@subscription_id", subscription.subscription_id);
                parameters.Add("@start_date", subscription.start_date);
                parameters.Add("@end_date", subscription.end_date);
                parameters.Add("@user_id", subscription.user_id);
                parameters.Add("@book_id", subscription.book_id);
                parameters.Add("@status", subscription.status);

                await connection.ExecuteAsync("sp_UpdateSubscription", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteSubscriptionAsync(int subscriptionId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@subscription_id", subscriptionId);

                await connection.ExecuteAsync("sp_DeleteSubscription", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
