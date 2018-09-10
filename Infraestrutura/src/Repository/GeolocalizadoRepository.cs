using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class GeolocalizadoRepository : EFLocaisRepository<Geolocalizado>, IGeolocalizadoRepository
    {
        public GeolocalizadoRepository(locaisContext dbContext) : base(dbContext)
        {

        }

    }
}