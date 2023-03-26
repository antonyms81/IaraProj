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
                    return RedirectToAction(nameof(Cotacao));
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
            Cotacao cotacao = new Cotacao();
            if (id != Guid.Empty)
            {
                var _cotacao = await _service.BuscarPorId(id);
                var _cotacaoItem = await _service.BuscarItem();
                var listaItem = _cotacaoItem.Where(x => x.IdCotacao == id).ToList();

                cotacao = _cotacao;
                cotacao.CotacaoItens = listaItem.ToList();

            }
            return View(cotacao);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cotacao cotacao)
        {
            string cnpjComprador = Regex.Replace(cotacao.CnpjComprador, "[^0-9]", "");
            string cnpjfornecedor = Regex.Replace(cotacao.CNPJFornecedor, "[^0-9]", "");

            cotacao.CnpjComprador = cnpjComprador;
            cotacao.CNPJFornecedor = cnpjfornecedor;

            if (Request.Form["TipoAcao"] == "Editar")
            {
                var _cotacaoItem = await _service.BuscarItem();
                var listaItem = _cotacaoItem.Where(x => x.IdCotacao == cotacao.Id).ToList();

                int cont = 0;
              
                foreach (var item in listaItem)
                    {

                    cotacao.CotacaoItens[cont].Id=item.Id;
                    cotacao.CotacaoItens[cont].IdCotacao=item.IdCotacao;
                    var _linhasAfetadas = await _service.AtualizarItem(item.Id, cotacao.CotacaoItens[cont]);
                    cont++;
                }
                
                var linhasAfetadas = await _service.Atualizar(cotacao.Id, cotacao);

                if (linhasAfetadas > 0)
                {
                    return RedirectToAction(nameof(Cotacao));
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

            var _cotacaoItem = await _service.BuscarItem();
            var listaItem = _cotacaoItem.Where(x => x.IdCotacao == cotacao.Id).ToList();
            cotacao.CotacaoItens = listaItem;
            if (listaItem.Count() > 0)
            {
                foreach (var item in listaItem)
                {
                   
                    var _linhasAfetadas = await _service.ExcluirItem(item.Id, cotacao.CotacaoItens[0]);

                }
            }

            var linhasAfetadas = await _service.Excluir(cotacao.Id);

            if (linhasAfetadas > 0)
            {
                return RedirectToAction(nameof(Cotacao));
            }

            return View();
        }

        public IActionResult ExercicioSoma()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExercicioSoma(ExercicioSoma exercicioSoma)
        {

            if (exercicioSoma.ValorEntrada != 0)
            {
                for (int i = 0; i <= exercicioSoma.ValorEntrada; i++)
                {
                    exercicioSoma.Soma = i + exercicioSoma.Soma;
                }
            }
            else
            {
                exercicioSoma.ValorEntrada = 0;
                exercicioSoma.Soma = 0;
            }

            return View(exercicioSoma);
        }

        public IActionResult Duplicadas()
        {
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