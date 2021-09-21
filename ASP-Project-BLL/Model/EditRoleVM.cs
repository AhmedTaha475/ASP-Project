using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
  public  class EditRoleVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Enter Role Name")]
        public string RoleName { get; set; }
    }
}
