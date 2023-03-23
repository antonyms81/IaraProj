using IaraProj.Domain.Entities;
using IaraProj.Domain.Services;
using IaraProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IaraProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceCotacao _service;
        public HomeController(ILogger<HomeController> logger, IServiceCotacao service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Cotacao cotacao)
        {
            if (Request.Form["TipoAcao"] == "AdicionarItem")
                cotacao.CotacaoItens.Add(new CotacaoItem { Id = Guid.NewGuid(), Ordem = cotacao.CotacaoItens.Count });

            if (Request.Form["TipoAcao"] == "Cadastrar")
            {
                var linhasAfetadas = await _service.Criar(Guid.NewGuid(), cotacao);
                if (linhasAfetadas > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cotacao);
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