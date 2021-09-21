using ASP_Project_BLL.Helper;
using ASP_Project_BLL.Interface;
using ASP_Project_BLL.Model;
using ASP_Project_DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Areas.Admin.Controllers
{ 

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo employee;
        private readonly IMapper mapper;
        private readonly ICountryRepo country;
        private readonly ICityRep city;
        private readonly IDistrictRepo district;
        private readonly IDepartmentRepo department;

        public EmployeeController(IEmployeeRepo employee,IMapper Mapper,ICountryRepo country , ICityRep city,IDistrictRepo district , IDepartmentRepo department)
        {
            this.employee = employee;
            mapper = Mapper;
            this.country = country;
            this.city = city;
            this.district = district;
            this.department = department;
        }
        public IActionResult Index()
        {
            var data = employee.GetEmployees();
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);



            return View(result);
        }

        public IActionResult CreateEmployee()
        {

            ViewBag.Departments = new SelectList(department.GetDepartments(), "Id", "DepartmentName");
            ViewBag.Countries = new SelectList(country.GetData(), "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeVM model)
        {

            if (ModelState.IsValid)
            {
                var docName = FileControll.UploadFile("/wwwroot/Files/Docs", model.Cv);
                var phName = FileControll.UploadFile("/wwwroot/Files/Photos", model.Photo);
                var data = mapper.Map<Employee>(model);
                data.CvName = docName;
                data.PhotoName = phName;
                employee.Create(data);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
          
        }

        public IActionResult Details(int id)
        {
            var data = employee.GetEmployeeById(id);
            var result = mapper.Map<EmployeeVM>(data);

            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var data = employee.GetEmployeeById(id);
            var result = mapper.Map<EmployeeVM>(data);

            ViewBag.Departments = new SelectList(department.GetDepartments(), "Id", "DepartmentName");
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                
                var data = mapper.Map<Employee>(model);


                employee.Edit(data);


                return RedirectToAction("Index");
            }
          
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var data = employee.GetEmployeeById(id);
            var result = mapper.Map<EmployeeVM>(data);

            ViewBag.Departments = new SelectList(department.GetDepartments(), "Id", "DepartmentName");
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {

            if (ModelState.IsValid)
            {
                FileControll.RemoveFile("Files/Docs", model.CvName);
                FileControll.RemoveFile("Files/Photos", model.PhotoName);
                var OldData = employee.GetEmployeeById(model.id);
                employee.Delete(OldData);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult GetCityWithCountryId(int ctryId)
        {

            var data = city.GetCities().Where(x => x.CountryId == ctryId);

            return Json(data);
        }

        [HttpPost]
        public JsonResult GetDistrictWithCityId(int CtyId)
        {

            var data = district.GetData().Where(x => x.CityId == CtyId);

            return Json(data);
        }

    }
}
