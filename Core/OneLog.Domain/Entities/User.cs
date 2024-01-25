using Microsoft.AspNetCore.Identity;
namespace OneLog.Domain.Entities
{
    public class User : IdentityUser
    {
        public bool IsDeleted { get; set; } // querying strictly in database(not returned to the frontend)
        public bool Status { get; set; } // status will be returned to know who is active or not
        public Guid ProfileKey { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
    }
}
