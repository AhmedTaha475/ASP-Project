using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_DAL.Entities
{
    [Table("District")]
  public  class District
    {
        public District()
        {
            Employee = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
