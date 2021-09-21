using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Interface
{
  public  interface IDepartmentRepo
    {

        void Create(Department obj);

        void Edit(Department obj);

        void Delete(Department obj);

        IEnumerable<Department> GetDepartments();

        Department GetDepartmentById(int id);

        IEnumerable<Department> SearchByDepartmentName(string name);
    }
}
