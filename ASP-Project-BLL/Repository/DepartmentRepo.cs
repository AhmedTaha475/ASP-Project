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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DbContainer db;

        public DepartmentRepo(DbContainer db)
        {
            this.db = db;
        }
        public void Create(Department obj)
        {
            db.Department.Add(obj);
            db.SaveChanges();
            
        }

        public void Delete(Department obj)
        {
            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Department GetDepartmentById(int id)
        {
            var data = db.Department.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var data = db.Department.Select(x => x);
            return data;
        }

        public IEnumerable<Department> SearchByDepartmentName(string name)
        {
            var data = db.Department.Where(x => x.DepartmentName == name).Select(x=>x);
            return data;
        }
    }
}
