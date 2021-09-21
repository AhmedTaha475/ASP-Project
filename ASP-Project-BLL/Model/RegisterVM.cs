using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
  public  class RegisterVM
    {
        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter Email")]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm your Password")]
        [Compare("Password",ErrorMessage ="Password Doesn't Match")]
        public string ConfirmPassword { get; set; }

    }
}
