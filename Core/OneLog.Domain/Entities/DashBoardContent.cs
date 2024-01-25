

using System.ComponentModel.DataAnnotations.Schema;

namespace OneLog.Domain.Entities
{
    public class DashBoardContent
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public BusinessApplication? Application { get; set; }
    }
}
