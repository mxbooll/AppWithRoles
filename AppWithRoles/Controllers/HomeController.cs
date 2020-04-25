using AppWithRoles.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppWithRoles.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "group1, group2")]
        public IActionResult Index()
        {
            var role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            switch (role)
            {
                case "group1":
                    ViewBag.UserRole = UserRole.Group1;
                    return View(UserRole.Group1);
                case "group2":
                    ViewBag.UserRole = UserRole.Group2;
                    return View(UserRole.Group2);
                default:
                    break;
            }   
            
            return View(UserRole.Unknown);
        }

        [Authorize(Roles = "group1")]
        public IActionResult About()
        {
            return Content("Вход только для пользователей группы 1");
        }
    }
}
