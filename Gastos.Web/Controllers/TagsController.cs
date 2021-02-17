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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagPostViewModel tagPost)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                _ = await _TagsService.CreateTagUsuario(user.Id, tagPost.Tag);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(tagPost.Tag, ex.Message);
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [Route("~/tags/editar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                if (id is null)
                    return NotFound();

                var user = await _userManager.GetUserAsync(User);
                var tag = await _TagsService.BuscarTagById(user.Id, Convert.ToInt64(id));

                if (tag is null)
                    return NotFound();

                return View(tag);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        [Route("~/tags/editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTag(long id, TagPostViewModel tagPut)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                _ = await _TagsService.UpdateTagUsuario(user.Id, id, tagPut.Tag);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Edit", new TagsDTO{Id = id, Tag = tagPut.Tag});
            }

            return RedirectToAction("Index");
        }
    }
}
