using Gastos.Core.Services;
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
        private readonly TagsService _TagsService;
        private UserManager<Usuarios> _userManager;
        public TagsController(UserManager<Usuarios> userManager, TagsService tagsService)
        {
            _userManager = userManager;
            _TagsService = tagsService;
        }
        public async Task<IActionResult> IndexAsync(long? id)
        {
            var tags = new List<object>();
            try
            {
                var user = await _userManager.GetUserAsync(User);

                tags = await _TagsService.GetTagsByUsuario(user.Id);
            }
            catch (Exception e)
            {

            }
            return View(tags);
        }
    }
}
