using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<int> CreateSubscriptionAsync(Subscription subscription);
        Task DeleteSubscriptionAsync(int subscriptionId);
        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId);
        Task UpdateSubscriptionAsync(Subscription subscription);
    }
}