using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerAPI.Entities
{
    class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
