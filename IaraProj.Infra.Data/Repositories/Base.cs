using IaraProj.Domain.Repositories;
using IaraProj.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Infra.Data.Repositories
{
    public class Base<E> : IBase<E> where E : class
    {
        private readonly IaraContext _contexto;

        public Base(IaraContext contexto)
        {
            _contexto = contexto;
        }

        public virtual async Task<int> Criar(E entidade)
        {
            await _contexto.Set<E>().AddAsync(entidade);
            return await _contexto.SaveChangesAsync();
        }

        public virtual async Task<int> Atualizar(E entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync();
        }

        public virtual async Task<int> Excluir(Guid id)
        {
            try
            {
                _contexto.Set<E>().Remove(await BuscarPeloId(id));
                return await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public virtual async Task<List<E>> BuscarTodos()
        {
            return await _contexto.Set<E>().ToListAsync();
        }

        public virtual async Task<E> BuscarPeloId(Guid id)
        {
            return await _contexto.Set<E>().FindAsync(id);
        }
    }
}
