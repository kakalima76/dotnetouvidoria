using System;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IDenunciaRepository : IRepository<Denuncia>
    {
        DateTime ConverteStringData(string data);

    }
}