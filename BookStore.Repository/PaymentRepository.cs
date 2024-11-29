using BookStore.Models.Entities;
using BookStore.Models.Interfaces;
using Dapper;
using System.Data;

namespace BookStore.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DbContext _dbContext;

        public PaymentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@payment_id", paymentId);

                return await connection.QueryFirstOrDefaultAsync<Payment>("sp_GetPayment", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Payment>("SELECT * FROM tblPayment");
            }
        }

        public async Task<int> CreatePaymentAsync(Payment payment)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@@subscription_id", payment.subscription_id);
                parameters.Add("@payment_gateway_response", payment.payment_gateway_response);
                parameters.Add("@amount", payment.amount);
                parameters.Add("@payment_date", payment.payment_date);
                parameters.Add("@payment_method", payment.payment_method);
                parameters.Add("@payment_status", payment.payment_status);

                return await connection.ExecuteAsync("sp_CreatePayment", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@payment_id", payment.payment_id);
                parameters.Add("@@subscription_id", payment.subscription_id);
                parameters.Add("@payment_gateway_response", payment.payment_gateway_response);
                parameters.Add("@amount", payment.amount);
                parameters.Add("@payment_date", payment.payment_date);
                parameters.Add("@payment_method", payment.payment_method);
                parameters.Add("@payment_status", payment.payment_status);

                await connection.ExecuteAsync("sp_UpdatePayment", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@payment_id", paymentId);

                await connection.ExecuteAsync("sp_DeletePayment", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
