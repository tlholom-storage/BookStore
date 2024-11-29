using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task UpdateUserAsync(User user);
    }
}