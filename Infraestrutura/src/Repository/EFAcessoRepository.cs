using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository
{
    public class EFAcessoRepository : IUsuarioCripto, IRepository<Usuario>, IUsuarioAutentica
    {

        private readonly UserContext _dbContext;
        private readonly HashAlgorithm _algoritmo;

        public EFAcessoRepository()
        {
        }

        public EFAcessoRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

         public EFAcessoRepository(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }



        public Usuario Adicionar(Usuario entity)
        {

            var t = new EFAcessoRepository(SHA512.Create());

            entity.Password = t.GerarHash(entity.Password);
            entity.ConfirmPassword = null;

            _dbContext.Set<Usuario>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Atualizar(Usuario entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicado)
        {
            return _dbContext.Set<Usuario>().Where(predicado).AsEnumerable();
        }

        public string GerarHash(string senha)
        {
            var valorCodificado = Encoding.UTF8.GetBytes(senha);
            var senhaCifrada = _algoritmo.ComputeHash(valorCodificado);
            var sb = new StringBuilder();
                foreach (var caractere in senhaCifrada)
                {
                    sb.Append(caractere.ToString("X2"));
                }
            return sb.ToString();
        }

        public bool loginIsAuthenticated(string usuario, string senha)
        {
            var user = _dbContext.Set<Usuario>().Where(x => x.Nome.Equals(usuario)).FirstOrDefault();

            if(user == null){
                return false;
            }

            var t = new EFAcessoRepository(SHA512.Create());


            if(!t.VerificarHash(senha, user.Password)){
                return false;
            }


            return true;

        }

      
        public Usuario ObterPorId(int id)
        {
            return _dbContext.Set<Usuario>().Find(id);
        }

        public List<Usuario> ObterTodos()
        {
            return _dbContext.Set<Usuario>().ToList();
        }

        public void Remover(Usuario entity)
        {
            _dbContext.Set<Usuario>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public bool VerificarHash(string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");
            var senhaCifrada = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));
            var sb = new StringBuilder();
            foreach (var caractere in senhaCifrada)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString() == senhaCadastrada;
        }
    }
}