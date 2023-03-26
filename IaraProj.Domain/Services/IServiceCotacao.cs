using IaraProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Services
{
    public interface IServiceCotacao
    {
        Task<int> Criar(Guid id, Cotacao cotacao);
        Task<int> Atualizar(Guid id, Cotacao cotacao);
        Task<int> AtualizarItem(Guid id, CotacaoItem cotacaoItem);
        Task<int> Excluir(Guid id);
        Task<List<Cotacao>> BuscarTodos();
        Task<Cotacao> BuscarPorId(Guid id);
        Task<List<CotacaoItem>> BuscarItem();
    }
}
