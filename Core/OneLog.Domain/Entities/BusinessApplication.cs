
using System.ComponentModel.DataAnnotations.Schema;

namespace OneLog.Domain.Entities
{
    public class BusinessApplication : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public Guid ApplicationKey { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; } // Change Users to User
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business? Business { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }

        //public bool IsDeactivated { get; set; }
    }
}
