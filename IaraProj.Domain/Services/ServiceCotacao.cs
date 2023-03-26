using IaraProj.Domain.Entities;
using IaraProj.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Services
{
    public class ServiceCotacao : IServiceCotacao
    {
        private readonly IBase<Cotacao> _repositorio;

        public ServiceCotacao(IBase<Cotacao> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> Criar(Guid id, Cotacao cotacao)
        {
            cotacao.Id = id;

            if (cotacao.CotacaoItens != null)
            {
                cotacao.CotacaoItens.ForEach(x => x.IdCotacao = id);
            }

            return await _repositorio.Criar(cotacao);
        }

        public async Task<int> Atualizar(Guid id, Cotacao cotacao)
        {
            cotacao.Id = id;
            return await _repositorio.Atualizar(cotacao);
        }

        public async Task<int> AtualizarItem(Guid id, CotacaoItem cotacaoItem)
        {
            cotacaoItem.Id = id;
            return await _repositorio.AtualizarItem(cotacaoItem);
        }

        public async Task<int> Excluir(Guid id)
        {
            return await _repositorio.Excluir(id);
        }

        public async Task<List<Cotacao>> BuscarTodos()
        {
            return await _repositorio.BuscarTodos();
        }

        public async Task<Cotacao> BuscarPorId(Guid id)
        {
            return await _repositorio.BuscarPeloId(id);
        }

        public async Task<List<CotacaoItem>> BuscarItem()
        {
            return await _repositorio.BuscarItem();
        }
    }
}
