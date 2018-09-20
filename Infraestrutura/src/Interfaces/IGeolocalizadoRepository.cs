using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IGeolocalizadoRepository : IRepository<Geolocalizado>
    {
         Geolocalizado ObterPorIdString(string id);
    }
}