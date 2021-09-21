using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
 public   class CreateRoleVM
    {
        [Required(ErrorMessage ="Enter Role Name")]
        public string RoleName { get; set; }
    }
}
