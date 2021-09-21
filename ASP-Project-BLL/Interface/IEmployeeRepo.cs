using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Interface
{
    public interface IEmployeeRepo
    {


        void Create(Employee obj);

        void Edit(Employee obj);

        void Delete(Employee obj);

        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        IEnumerable<Employee> SearchByEmployeeName(string name);
    }
}
