using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Local
{
        [Authorize]
        public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }
        public IEnumerable<Bairro> ListaBairro{ get; set; }


        private readonly IDenunciaRepository _dbDenuncia;
        private readonly IBairroRepository _dbBairro;

        private readonly ILogradouroRepository _dbLogradouro;

        public IndexModel
        (
            IDenunciaRepository dbDenuncia,
            IBairroRepository dbBairro,
            ILogradouroRepository dbLogradouro
        )
        {
            _dbDenuncia = dbDenuncia;
            _dbBairro = dbBairro;
            _dbLogradouro = dbLogradouro;
        }



        protected IndexModel()
        {

        }

        public void OnGet(Denuncia denuncia)
        {
           ListaBairro = _dbBairro.ObterTodos().OrderBy(x => x.Nome);
            
        }
                      
        public JsonResult OnGetJson(String param){

            return new JsonResult(_dbLogradouro.Buscar(x => x.IdBairro.Equals(param)).OrderBy(x => x.Nome));
            
        }

        public JsonResult OnGetJsonLocais(String bairro, long logradouro){

            var strbairro = _dbBairro.ObterPorIdString(bairro).Nome;
            var strLogradouro = _dbLogradouro.ObterPorIdLong(logradouro).Nome;

            return new JsonResult(_dbDenuncia.Buscar(x => x.bairro.Equals(strbairro) && x.logradouro.Equals(strLogradouro)));
        
        }

        public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }                
    }
}
