using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; } = string.Empty;
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public byte[] password_hash { get; set; }
        public byte[] password_salt{ get; set; }
        public int user_type_id { get; set; }
    }
}
