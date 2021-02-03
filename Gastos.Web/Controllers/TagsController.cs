using Gastos.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Web.Controllers
{
    public class TagsController : Controller
    {
        private UserManager<Usuarios> _userManager;
        public TagsController(UserManager<Usuarios> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync(long? id)
        {
            //var tags = new 
            var user = await _userManager.GetUserAsync(User);
            try
            {
                
            }
            catch (Exception e)
            {

            }
            return View();
        }
    }
}
