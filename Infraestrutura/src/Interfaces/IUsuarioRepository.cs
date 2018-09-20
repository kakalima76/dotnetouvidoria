using System.Threading.Tasks;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>, IUsuarioAutentica , IUsuarioCripto
    {
       
    }
}