using ASP_Project_BLL.Interface;
using ASP_Project_BLL.Model;
using ASP_Project_DAL.Entities;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Areas.Admin.Controllers
{ 

    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo department;
        private readonly IMapper mapper;
        private readonly static List<DepartmentVM> Contacts = new List<DepartmentVM>();
        public DepartmentController(IDepartmentRepo department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {

          var data = department.GetDepartments();
          var result=  mapper.Map<IEnumerable< DepartmentVM>>(data);



            return View(result);
        }

        public IActionResult CreateDepartment()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateDepartment(DepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var data = mapper.Map<Department>(model);
                department.Create(data);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
            
        }


        public IActionResult Edit(int id)
        {

           var data= department.GetDepartmentById(id);
           var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {


            if (ModelState.IsValid)
            {
                var data = mapper.Map<Department>(model);
                department.Edit(data);
                return RedirectToAction("Index");
            }
            return View(model);
         
        }

        public IActionResult Delete(int id)
        {

            var data = department.GetDepartmentById(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {

            var data = mapper.Map<Department>(model);
            department.Delete(data);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            var data = department.GetDepartmentById(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Details(DepartmentVM model)
        {

            var data = mapper.Map<Department>(model);
            department.Delete(data);
            return RedirectToAction("Index");
        }




    }
}
