using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class BairroRepository : EFLocaisRepository<Bairro>, IBairroRepository
    {
        public BairroRepository(locaisContext dbContext) : base(dbContext)
        {

        }

        public Bairro ObterPorIdString(string id)
        {
            return _dbContext.Set<Bairro>().Find(id);
        }
    }
}