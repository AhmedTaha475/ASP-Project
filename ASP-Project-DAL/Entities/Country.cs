using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_DAL.Entities
{
    [Table("Country")]
 public   class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<City> City { get; set; }
    }
}
