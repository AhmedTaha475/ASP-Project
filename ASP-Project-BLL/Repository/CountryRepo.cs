using ASP_Project_BLL.Interface;
using ASP_Project_DAL.DataBase;
using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Repository
{
    public class CountryRepo : ICountryRepo
    {
        private readonly DbContainer db;

        public CountryRepo(DbContainer db)
        {
            this.db = db;
        }
        public Country GetCountryById(int id)
        {
            var data = db.Country.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            return data;
            
        }

        public IEnumerable<Country> GetData()
        {
            var data = db.Country.Select(x => x);
            return data;
        }
    }
}
