using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface ILogradouroRepository : IRepository<Logradouro>
    {
       Logradouro ObterPorIdLong(long id);
    }
}