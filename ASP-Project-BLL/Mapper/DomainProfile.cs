using ASP_Project_BLL.Model;
using ASP_Project_DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Mapper
{
 public   class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();

            CreateMap<CountryVM, Country>();
            CreateMap<Country, CountryVM>();

            CreateMap<CityVM, City>();
            CreateMap<City, CityVM>();

            CreateMap<DistrictVM, District>();
            CreateMap<District, DistrictVM>();
        }

        
    }
}
