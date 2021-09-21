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
    public class DistrictRepo : IDistrictRepo
    {
        private readonly DbContainer db;

        public DistrictRepo(DbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<District> GetData()
        {
            var data = db.District.Select(x => x);
            return data;
        }

        public District GetDistrictById(int id)
        {
            var data = db.District.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
    }
}
