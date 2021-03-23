using Gastos.Core.Models.DTO;
using Gastos.Core.Services;
using Gastos.Infrastructure.Models;
using Gastos.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovimentacaoService _movimentacaoService;
        private readonly TagsService _tagsService;
        private UserManager<Usuarios> _userManager;

        public HomeController(ILogger<HomeController> logger,
           UserManager<Usuarios> userManager,
           MovimentacaoService movimentacaoService,
           TagsService tagsService)
        {
            _userManager = userManager;
            _movimentacaoService = movimentacaoService;
            _tagsService = tagsService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(DateTime? dataInicial, DateTime? dataFinal, List<long> tags)
        {
            var resumoHome = new ResumoHomeDTO();

            var modelError = TempData["modelError"] as string;
            if (!string.IsNullOrEmpty(modelError))
                ViewBag.Message(modelError);

            try
            {
                var user = await _userManager.GetUserAsync(User);
                var tag = await _tagsService.GetTagsByUsuario(user.Id);
                ViewBag.Tags = tag;

                ViewBag.TagsSelecionadas = tag.Where(x => tags.Contains(x.Id)).ToList();
                resumoHome = _movimentacaoService.GetResumoHome(user.Id, dataInicial, dataFinal, tags);
            }
            catch (Exception ex)
            {
                ViewBag.Message( ex.Message);
            }

            ViewBag.DataInicial = dataInicial != null ? dataInicial : new DateTime(DateTime.Now.Year, 01, 01, 00, 00, 00);
            ViewBag.DataFinal = dataFinal != null ? dataInicial : DateTime.Now;
            return View(resumoHome);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
