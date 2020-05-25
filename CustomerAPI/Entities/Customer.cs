using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerAPI.Entities
{
    class Customer
    {
        [Key]
        [Required(ErrorMessage ="Personal Number can't be empty")]
        [MaxLength(12)]
        public long PersonalNumber { get; set; }
        
        [Required(ErrorMessage ="Email cannot be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Invalid Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Address cannot be empty")]
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
       
        public Guid AddressId { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage ="Minimum 8 digits should be entered")]
        [MaxLength(15, ErrorMessage ="Maximum 15 digits should be entered")]
        [ForeignKey("PhoneId")]
        public PhoneNumber Phone { get; set; }

        public Guid PhoneId { get; set; }
    }
}
