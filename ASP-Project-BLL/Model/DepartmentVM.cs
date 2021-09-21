using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
 public   class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter departmentName")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please enter departmentCode")]
        public string DepartmentCode { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
