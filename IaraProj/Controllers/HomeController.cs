using IaraProj.Domain.Entities;
using IaraProj.Domain.Services;
using IaraProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            string cnpjComprador = Regex.Replace(cotacao.CnpjComprador, "[^0-9]", "");
            string cnpjfornecedor = Regex.Replace(cotacao.CNPJFornecedor, "[^0-9]", "");

            cotacao.CnpjComprador = cnpjComprador;
            cotacao.CNPJFornecedor = cnpjfornecedor;

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

        public async Task<IActionResult> Cotacao()
        {
            ListaCotacao listaCotacao = new ListaCotacao();

            var result = await _service.BuscarTodos();

            listaCotacao.Cotacoes = result; 

            return View(listaCotacao);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            if (id != Guid.Empty)
            {
                var result = await _service.BuscarPorId(id);
                if (result != null)
                {
                    return View(result);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cotacao cotacao)
        {
            string cnpjComprador = Regex.Replace(cotacao.CnpjComprador, "[^0-9]", "");
            string cnpjfornecedor = Regex.Replace(cotacao.CNPJFornecedor, "[^0-9]", "");

            cotacao.CnpjComprador = cnpjComprador;
            cotacao.CNPJFornecedor = cnpjfornecedor;

            if (Request.Form["TipoAcao"] == "AdicionarItem")
                cotacao.CotacaoItens.Add(new CotacaoItem { Id = Guid.NewGuid(), Ordem = cotacao.CotacaoItens.Count });

            if (Request.Form["TipoAcao"] == "Editar")
            {
                var linhasAfetadas = await _service.Atualizar(cotacao.Id, cotacao);
                if (linhasAfetadas > 0)
                {
                    return RedirectToAction(nameof(Index));
                }


            }
            return View(cotacao);
        }


        public async Task<IActionResult> Deletar(Guid id)
        {
            if (id != Guid.Empty)
            {
                var result = await _service.BuscarPorId(id);
                if (result != null)
                {
                    return View(result);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Cotacao cotacao)
        {

            var linhasAfetadas = await _service.Excluir(cotacao.Id);

            if (linhasAfetadas > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
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