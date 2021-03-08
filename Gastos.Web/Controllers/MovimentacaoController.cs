using Gastos.Core.Models;
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

        [Route("~/movimentacoes/criar")]
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

        public async Task<IActionResult> DetalhesView(int index)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var tags = await _tagsService.GetTagsByUsuario(user.Id);
                ViewBag.Tags = tags;
                ViewBag.Index = index;
                return PartialView("~/Views/Shared/Partials/Detalhes/Create_Partial.cshtml");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/movimentacoes/criar")]
        public async Task<IActionResult> Create(MovimentacaoPost movimentacao)
        {
            try
            {
                throw new Exception("teste");
                var user = await _userManager.GetUserAsync(User);

                var novoId = await _movimentacaoService.Create(movimentacao, user.Id);
                return RedirectToAction($"movimentacoes/{novoId}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Nome", ex.Message);
                return View("Create");
            }

        }

        [HttpGet]
        [Route("~/movimentacoes/{id}")]
        public async Task<IActionResult> GetMovimentacaoAsync(long id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                var movimentacao = _movimentacaoService.GetMovimentacao(user.Id, id);
                return View("Details", movimentacao);
            }
            catch (Exception e){
                TempData["modelError"] = "Falha ao buscar movimentação:" + e.Message;
                return RedirectToAction("", "Home");

            }
            return Ok();
        }


        [HttpGet]
        [Route("~/movimentacoes/relatorio/{mes}/{ano}")]
        public async Task<IActionResult> GetRelatorioMensal(int mes, int ano)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                var movimentacao = _movimentacaoService.GetRelatorioMovimentacoesMes(user.Id, mes, ano);
                return View("Mensal", movimentacao);
            }
            catch (Exception e)
            {
                TempData["modelError"] = "Falha ao buscar relatório de mensal:" + e.Message;
                return RedirectToAction("", "Home");
            }
            return Ok();
        }

        [HttpPost]
        [Route("~/movimentacoes/excluir/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                _ = await _movimentacaoService.ExcluirMovimentacao(user.Id, id);

            }
            catch (Exception e)
            {
                TempData["modelError"] = "Falha ao excluir movimentacao:" + e.Message;
            }

            return RedirectToAction("", "Home");

        }
    }
}
