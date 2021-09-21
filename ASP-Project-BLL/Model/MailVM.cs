using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
    public class MailVM
    {
        [Required(ErrorMessage ="Enter the Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Enter Your message")]
        public string Message { get; set; }
        [Required(ErrorMessage ="Enter Your Email")]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }

    }
}
