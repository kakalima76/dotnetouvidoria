using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class UsuarioRepository : EFAcessoRepository, IUsuarioRepository
    {
       public UsuarioRepository(UserContext dbContext) :  base(dbContext)
       {
           
       }
    }
}