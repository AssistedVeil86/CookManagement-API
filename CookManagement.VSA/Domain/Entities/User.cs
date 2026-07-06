using CookManagement.VSA.Domain.Enums;

namespace CookManagement.VSA.Domain.Entities
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
