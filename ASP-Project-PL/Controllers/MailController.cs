using ASP_Project_BLL.Helper;
using ASP_Project_BLL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Areas.Admin.Controllers
{

    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(MailVM obj)
        {
            if (ModelState.IsValid)
            {
                var result = SendMail.CreateMail(obj);
                TempData["Msg"] = result;
                return RedirectToAction("Index");
              
            }

            return View(obj);


        }
    }
}
