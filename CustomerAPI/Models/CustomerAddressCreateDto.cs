using CustomerAPI.ValidationAttirbutes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    
    public class CustomerAddressCreateDto
    {
      //  [Required(ErrorMessage = "Zipcode cannot be empty")]
      //  //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
      //  [MinLength(4, ErrorMessage = "Min length should be 4")]
      //  [MaxLength(5, ErrorMessage = "Max length should be 5")]
      //  public int ZipCode { get; set; }

      //  [Required(ErrorMessage = "Country cannot be empty")]

      ////  [Remote(action: "IsValidCountry", controller: "Validation")]
      //  public string Country { get; set; }


        [Required(ErrorMessage = "Zipcode cannot be empty")]        
        public int ZipCode { get; set; }

        public string Country { get; set; }
    }
}
