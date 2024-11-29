using BookStore.Models.Entities;

namespace BookStore.Utility.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}