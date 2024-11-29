using BookStore.Models.Entities;

namespace BookStore.Models.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<int> CreateUserTypeAsync(UserType userType);
        Task DeleteUserTypeAsync(int userTypeId);
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int userTypeId);
        Task UpdateUserTypeAsync(UserType userType);
    }
}