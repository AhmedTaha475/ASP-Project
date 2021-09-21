using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_DAL.Entities
{
    [Table("City")]
    public   class City
    {
        public City()
        {
            District = new HashSet<District>();
        }
        public int Id { get; set; }
        public string   CityName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country country { get; set; }

        public ICollection<District> District { get; set; }
    }
}
