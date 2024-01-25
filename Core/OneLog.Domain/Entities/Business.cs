
using System.ComponentModel.DataAnnotations.Schema;

namespace OneLog.Domain.Entities
{
    public class Business : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? Users { get; set; }
        public bool IsActive { get; set; }
    }
}
