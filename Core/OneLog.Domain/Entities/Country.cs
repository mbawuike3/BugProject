﻿
namespace OneLog.Domain.Entities
{
    public  class Country : BaseEntity
    {
      
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}
