using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
 public   class CountryVM
    {
       

        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<City> City { get; set; }
    }
}
