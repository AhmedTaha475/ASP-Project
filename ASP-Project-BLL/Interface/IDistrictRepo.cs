
using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Interface
{
public      interface IDistrictRepo
    {
        IEnumerable<District> GetData();
        District GetDistrictById(int id);
    }
}
