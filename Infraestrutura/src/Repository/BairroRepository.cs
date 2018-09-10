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

    }
}