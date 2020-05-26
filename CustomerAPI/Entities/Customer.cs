using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace CustomerAPI.Entities
{
   public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Personal Number can't be empty")]
        [MaxLength(12, ErrorMessage = "Max length should be 12")]
        [MinLength(10, ErrorMessage = "Min length should be 10")]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email ID")]
        public string Email { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

    }
}
