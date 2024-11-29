namespace BookStore.Models.Entities
{
    public class UserType
    {
        public int user_type_id { get; set; }
        public string user_type_name { get; set; } = string.Empty;
        public bool is_admin { get; set; }
        public bool is_third_party { get; set; }
    }
}
