using Gastos.Core.Services;
using Gastos.Infrastructure.Models;
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
    public class MovimentacaoController : Controller
    {
        private readonly MovimentacaoService _movimentacaoService;
        private readonly TagsService _tagsService;
        private UserManager<Usuarios> _userManager;

        public MovimentacaoController(UserManager<Usuarios> userManager,
            MovimentacaoService movimentacaoService,
            TagsService tagsService)
        {
            _userManager = userManager;
            _movimentacaoService = movimentacaoService;
            _tagsService = tagsService;
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var tags = await _tagsService.GetTagsByUsuario(user.Id);
                ViewBag.Tags = tags;
                return View();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
