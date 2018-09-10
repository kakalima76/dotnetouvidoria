using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Adicionar(T entity);

        T ObterPorId(int id);

        void Atualizar(T entity);

        void Remover(T entity);
         
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado);

        List<T> ObterTodos();

    }
}