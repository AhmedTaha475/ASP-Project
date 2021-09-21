using ASP_Project_BLL.Interface;
using ASP_Project_DAL.DataBase;
using ASP_Project_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DbContainer db;

        public EmployeeRepo(DbContainer db)
        {
            this.db = db;
        }
        public void Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var data = db.Employee.Where(x => x.id == id).Include("Department").Include("District").FirstOrDefault();
            return data;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var data = db.Employee.Include("Department").Include("District").Select(x => x);
            return data;
        }

        public IEnumerable<Employee> SearchByEmployeeName(string name)
        {
            var data = db.Employee.Where(x => x.Name == name).Include("Department").Include("District").Select(x => x);
            return data;
        }

        
    }
}
