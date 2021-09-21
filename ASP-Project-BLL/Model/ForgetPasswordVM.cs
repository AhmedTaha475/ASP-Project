using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
   public class ForgetPasswordVM
    {
        [Required(ErrorMessage ="Enter Email")]
        public string Email { get; set; }
    }
}
