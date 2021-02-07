using Gastos.Core.DTO;
using Gastos.Core.Services;
using Gastos.Infrastructure.Models;
using Gastos.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Web.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly TagsService _TagsService;
        private UserManager<Usuarios> _userManager;
        public TagsController(UserManager<Usuarios> userManager, TagsService tagsService)
        {
            _userManager = userManager;
            _TagsService = tagsService;
        }

        public async Task<IActionResult> Index(long? id)
        {
            var tags = new List<TagsDTO>();
            try
            {
                var user = await _userManager.GetUserAsync(User);

                tags = await _TagsService.GetTagsByUsuario(user.Id);
            }
            catch (Exception e)
            {

            }
            return View(tags.OrderByDescending(x => x.Id).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(string tag)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                _ = await _TagsService.CreateTagUsuario(user.Id, tag);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(tag, ex.Message);
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Criar(TagPostViewModel tag)
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                _ = await _TagsService.DeleteTagUsuario(user.Id, id);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(id.ToString(), ex.Message);
            }

            return RedirectToAction("Index");

        }
    }
}
