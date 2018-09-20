namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces
{
    public interface IUsuarioCripto
    {
         string GerarHash(string senha);
         bool VerificarHash(string senhaDigitada, string senhaCadastrada);
    
    }
}