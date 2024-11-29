using BookStore.Models.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BookStore.Repository
{
    public class DbContext(IConfiguration config) : IDdContext
    {

        private readonly string sqlConnectionString = config.GetConnectionString("SqlConnection") ?? string.Empty;

        public IDbConnection CreateConnection() => new SqlConnection(sqlConnectionString);
    }
}
