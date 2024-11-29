using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> CreatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int paymentId);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int paymentId);
        Task UpdatePaymentAsync(Payment payment);
    }
}