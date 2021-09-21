using ASP_Project_DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
  public  class EmployeeVM
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Enter the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage =" Enter Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        [Range(2000, 10000, ErrorMessage = "Range In 2000:10000")]
        public int salary { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        [RegularExpression("[0-9]{1,6}-[a-zA-Z]{1,20}-[a-zA-Z]{1,20}-[a-zA-Z]{1,20}", ErrorMessage = "Ex 12-street-city-country")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Enter Hire Date")]
        public DateTime HireDate { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }
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
