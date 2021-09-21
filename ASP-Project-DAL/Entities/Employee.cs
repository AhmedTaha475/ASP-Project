using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_DAL.Entities
{
    [Table("Employee")]
 public   class Employee
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public int salary { get; set; }

        public string Address { get; set; }
        public DateTime HireDate { get; set; }

        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
