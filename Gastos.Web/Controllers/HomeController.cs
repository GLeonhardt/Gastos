using Gastos.Infrastructure.Models;
using Gastos.Web.Models;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                using (var context = new GastosContext())
                {
                    var users = context.Usuarios.ToList();
                    var a = 0;
                    //var tag = context.Tags.Where(x => x.UsuarioId == 1).ToList();

                    //var mov = context.Movimentacoes.Where(x => x.UsuarioId == 1).Include(x => x.Detalhes).FirstOrDefault();

                    //mov.Tags = tag;
                    //mov.Detalhes.FirstOrDefault().Tags = tag;
                    //context.Update(mov);
                    //context.SaveChanges();
                    //var usuario = new Usuarios()
                    //{
                    //    Nome = "Guilherme",
                    //    Email = "guileonhardt2@gmail.com",
                    //    Senha = "123456",
                    //    Tags = new List<Tags>() { new Tags() { Tag = "Netflix" } },
                    //    Movimentacoes = new List<Movimentacoes>() {
                    //    new Movimentacoes() {
                    //        Nome = "Cartão",
                    //        Data = DateTime.Now,
                    //        TipoMovimentacaoId = 1,
                    //        Valor = 300,
                    //        //Tags = new List<Tags>() { new Tags() { Tag = "Amazon" } },
                    //        Detalhes = new List<Detalhes>()
                    //        {
                    //            new Detalhes()
                    //            {
                    //                Nome = "Netflix",
                    //                Valor = 30,
                    //                //Tags = new List<Tags>() { new Tags() { Tag = "twitch" } },
                    //            }
                    //        }
                    //    }
                    //}
                    //};

                    //context.Usuarios.Add(usuario);
                    //context.SaveChanges();
                }
            }catch(Exception e)
            {
                var a = 0;
            }
            return View();

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
