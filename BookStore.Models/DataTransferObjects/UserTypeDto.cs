namespace BookStore.Models.DataTransferObjects
{
    public class UserTypeDto
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public bool IsThirdParty { get; set; }
    }
}
