using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class LogradouroRepository : EFLocaisRepository<Logradouro>, ILogradouroRepository
    {
        public LogradouroRepository(locaisContext dbContext) : base(dbContext)
        {

        }

    }
}