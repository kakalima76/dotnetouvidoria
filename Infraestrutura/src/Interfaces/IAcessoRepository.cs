using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IAcessoRepository<T> : IRepository<T> where T : class
    {
         
    }
}