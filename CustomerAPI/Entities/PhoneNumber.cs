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

        [Required]
        [MinLength(8, ErrorMessage = "Minimum 8 digits should be entered")]
        [MaxLength(15, ErrorMessage = "Maximum 15 digits should be entered")]
        public string Phone { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
    }
}
