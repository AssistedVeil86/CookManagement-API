using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Shared.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRecords = new List<UserRecord>();
        }

        public string Name { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserRole Role { get; set; }
        public List<UserRecord> UserRecords { get; set; }
    }
}
