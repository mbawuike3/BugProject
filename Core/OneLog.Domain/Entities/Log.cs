
using System.ComponentModel.DataAnnotations.Schema;

namespace OneLog.Domain.Entities
{
    public class Log : BaseEntity
    {
        public long ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public BusinessApplication? Application { get; set; }
        public long BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business? Business { get; set; }
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
    }
}
