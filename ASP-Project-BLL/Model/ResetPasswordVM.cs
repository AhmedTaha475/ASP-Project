using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
 public   class ResetPasswordVM
    {


        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = " Confirm Password Required")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matching")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
