using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class DenunciaRepository : EFRepository<Denuncia>, IDenunciaRepository
    {
        public DenunciaRepository(SGOContext dbContext) : base(dbContext)
        {

        }

        public DateTime ConverteStringData(string data)
        {
            int ano = Convert.ToInt16(data.Substring(6,4));
            int mes = Convert.ToInt16(data.Substring(3,2));
            int dia = Convert.ToInt16(data.Substring(0,2));
            int hor = Convert.ToInt16(data.Substring(11,2));
            int min = Convert.ToInt16(data.Substring(14,2));
            int seg = 0;

            DateTime dt = new DateTime(ano, mes, dia, hor, min, seg);

            return  dt;
        }
    }
}