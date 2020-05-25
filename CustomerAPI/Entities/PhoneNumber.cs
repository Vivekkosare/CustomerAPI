using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerAPI.Entities
{
    class PhoneNumber
    {
        [Key]
        public Guid PhoneId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public Guid CountryId { get; set; }
        public string Phone { get; set; }
    }
}
