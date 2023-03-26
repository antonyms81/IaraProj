using IaraProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Repositories
{
    public interface IBase<E> where E : class
    {
        Task<int> Criar(E entidade);
        Task<int> Atualizar(E entidade);
        Task<int> AtualizarItem(E entidade);
        Task<int> ExcluirItem(E entidade);
        Task<int> Excluir(Guid id);
        Task<List<E>> BuscarTodos();
        Task<E> BuscarPeloId(Guid id);
        Task<List<CotacaoItem>> BuscarItem();
        Task<int> AtualizarItem(CotacaoItem cotacaoItem);
        Task<int> ExcluirItem(CotacaoItem cotacaoItem);
    }
}
