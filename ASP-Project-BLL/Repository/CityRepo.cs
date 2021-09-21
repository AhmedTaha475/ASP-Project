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
    public class CityRepo : ICityRep
    {
        private readonly DbContainer db;

        public CityRepo(DbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<City> GetCities()
        {
            var data = db.City.Select(x => x);
            return data;
        }

        public City GetCityById(int id)
        {
            var data = db.City.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }
    }
}
