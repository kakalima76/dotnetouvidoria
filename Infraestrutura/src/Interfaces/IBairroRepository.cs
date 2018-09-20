using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface  IBairroRepository : IRepository<Bairro>
    {
       Bairro ObterPorIdString(string id);
    }
}