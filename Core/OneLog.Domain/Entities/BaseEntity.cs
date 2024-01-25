﻿

namespace OneLog.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
