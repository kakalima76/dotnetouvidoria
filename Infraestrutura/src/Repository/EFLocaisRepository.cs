using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
   
    public class EFLocaisRepository<T> : IRepository<T> where T : class
    {

        protected readonly locaisContext _dbContext;

        public EFLocaisRepository(locaisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Adicionar(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Atualizar(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();


        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _dbContext.Set<T>().Where(predicado).AsEnumerable();
        }

        public T ObterPorId(int id)
        {
            //Método Find específico para a chave primaria
            return _dbContext.Set<T>().Find(id);
        }

        public List<T> ObterTodos()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Remover(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}