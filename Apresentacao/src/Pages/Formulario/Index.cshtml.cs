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

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Formulario
{

    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }

        public Bairro Bairro { get; set; }

        public IEnumerable<Bairro> ListaBairro{ get; set; }

        public Categoria Categoria { get; set; }

        public IList<Categoria> ListaCategoria { get; set; }
              
        private readonly IBairroRepository _dbBairro;
        private readonly ILogradouroRepository _dbLogradouro;
        private readonly IDenunciaRepository _dbDenuncia;

        private readonly IGeolocalizadoRepository _dbGeolocalizado;


        public IndexModel
        (
            IBairroRepository dbBairro, 
            ILogradouroRepository dbLogradouro, 
            IDenunciaRepository dbDenuncia,
            IGeolocalizadoRepository dbGeolocalizado
        )
        {
            _dbBairro = dbBairro;
            _dbLogradouro = dbLogradouro;
            _dbDenuncia = dbDenuncia;
            _dbGeolocalizado = dbGeolocalizado;
        }



        protected IndexModel()
        {

        }

        public void OnGet(Denuncia denuncia)
        {
                                               
            ListaBairro = _dbBairro.ObterTodos().OrderBy(x => x.Nome);
            Categoria = new Categoria();
            ListaCategoria = Categoria.Listar().ToList();
            
        }

        public IActionResult OnPost(Denuncia denuncia)
        {

                              
           if(ModelState.IsValid){

                var logradouroId = Convert.ToInt32(denuncia.logradouro);
                Categoria = new Categoria();
                var lista = Categoria.Listar().ToList();
                var elemen  = lista.Where(x => x.Value == "0").ToArray();
                

                denuncia.lat =  _dbGeolocalizado.ObterPorIdString(denuncia.logradouro).Latitude;
                denuncia.lng =  _dbGeolocalizado.ObterPorIdString(denuncia.logradouro).Longitude;
                denuncia.cep =  _dbGeolocalizado.ObterPorIdString(denuncia.logradouro).GeolocalizadoId;
                denuncia.logradouro = _dbLogradouro.ObterPorId(logradouroId).Nome;
                denuncia.bairro = _dbBairro.ObterPorIdString(denuncia.bairro).Nome; 
                denuncia.categoria = elemen[0].Name.ToString();
                denuncia.agente = User.Identity.Name;

                _dbDenuncia.Adicionar(denuncia);

                             

            return  RedirectToPage("Index");

           } 

            ListaBairro = _dbBairro.ObterTodos().OrderBy(x => x.Nome);
            Categoria = new Categoria();
            ListaCategoria = Categoria.Listar().ToList();                        
                       
            return  Page();
        }

             
        public JsonResult OnGetJson(String param){

         
            return new JsonResult(_dbLogradouro.Buscar(x => x.IdBairro == param).OrderBy(x => x.Nome));
            
        }

         public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }                
    }
}
