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
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"ваша группа: {role}");
        }

        [Authorize(Roles = "group1")]
        public IActionResult About()
        {
            return Content("Вход только для пользователей группы 1");
        }
    }
}
