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

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Formulario
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }

        public Bairro Bairro { get; set; }

        public Itens Itens { get; set; }
        public IList<Itens> ListaTipos{ get; set; }

        public IList<Bairro> ListaBairro{ get; set; }

        public IList<Logradouro> ListaLogradouro { get; set; }
              
        private readonly IBairroRepository _dbBairro;
        private readonly ILogradouroRepository _dbLogradouro;

        public IndexModel(IBairroRepository dbBairro, ILogradouroRepository dbLogradouro)
        {
            _dbBairro = dbBairro;
            _dbLogradouro = dbLogradouro;
        }



        protected IndexModel()
        {
        }

        public void OnGet()
        {
                                               
           Itens = new Itens();
           ListaTipos = Itens.Listar().ToList();
           ListaBairro = _dbBairro.ObterTodos().ToList();
           ListaLogradouro = new List<Logradouro>();
            
        }

        public IActionResult OnPost(Denuncia denuncia)
        {

            if(ModelState.IsValid){
                return  RedirectToPage("/Resposta/", denuncia);
            }else

                                                     
            Itens = new Itens();
            ListaTipos = Itens.Listar().ToList();
            ListaBairro = _dbBairro.ObterTodos().ToList();
            ListaLogradouro = new List<Logradouro>();

            
            return RedirectToAction("Index");
 

        }

        // public void OnGetLogradouro(string param){
        //      ListaLogradouro = _dbLogradouro.Buscar(x => x.IdBairro == param).ToList();
        // }

        public JsonResult OnGetJson(String param){

            return new JsonResult(_dbLogradouro.Buscar(x => x.IdBairro == param));
            
        }

       

        

                
    }
}
