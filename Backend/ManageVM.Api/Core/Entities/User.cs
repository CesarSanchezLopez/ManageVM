using ManageVM.Api.Core.Enums;

namespace ManageVM.Api.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } // enum "Admin" o "User"
    }
}
