using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_DAL.Entities
{
    [Table("Department")]
  public  class Department
    {
        public int Id { get; set; }
        public string  DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
