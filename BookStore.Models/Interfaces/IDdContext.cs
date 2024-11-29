using System.Data;

namespace BookStore.Models.Interfaces
{
    public interface IDdContext
    {
        public IDbConnection CreateConnection();
    }
}
