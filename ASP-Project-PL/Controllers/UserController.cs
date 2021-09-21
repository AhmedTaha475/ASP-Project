using ASP_Project_BLL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {

            var data = userManager.Users;


            return View(data);
        }

        public async Task< IActionResult> AssignRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var data = new UserVM() { 
            
                Id=user.Id,
                UserName=user.UserName
            };

            ViewBag.Roles = new SelectList( roleManager.Roles, "Name","Name");
            ViewBag.MyRoles = await userManager.GetRolesAsync(user);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> AssignRole(UserVM model)
        {
            try
            {
                var data = await  userManager.FindByIdAsync(model.Id);
                var result = await userManager.AddToRoleAsync(data, model.RoleName);
                
                    return RedirectToAction("Index");
             
                
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
         
        }



        public async Task<IActionResult> RemoveRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var data = new UserVM()
            {

                Id = user.Id,
                UserName = user.UserName
            };

            ViewBag.Roles = await userManager.GetRolesAsync(user);
           
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveRole(UserVM model)
        {
            try
            {
                var data = await userManager.FindByIdAsync(model.Id);
                var result = await userManager.RemoveFromRoleAsync(data, model.RoleName);
           

                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }

        }
    }
}
