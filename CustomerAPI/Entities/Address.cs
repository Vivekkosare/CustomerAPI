using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerAPI.Entities
{
    class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        [MinLength(4, ErrorMessage ="Min length should be 4")]
        [MaxLength(5, ErrorMessage ="Max length should be 5")]
        public int ZipCode { get; set; }
        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
