
namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IUsuarioAutentica 
    {
        bool loginIsAuthenticated(string usuario, string senha);
       
    }
}