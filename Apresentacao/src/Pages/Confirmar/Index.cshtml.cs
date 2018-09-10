using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Confirmar
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }

        public Bairro Bairro { get; set; }

        public Itens Itens { get; set; }
        public IList<Itens> ListaTipos{ get; set; }

        public IList<Bairro> ListaBairro { get; set; }

        private readonly IBairroRepository _dbBairro;

        public IndexModel(IBairroRepository dbBairro)
        {
            _dbBairro = dbBairro;
        }

        protected IndexModel()
        {
        }

        public void OnGet()
        {
                                               
           Itens = new Itens();
           ListaTipos = Itens.Listar().ToList();
           ListaBairro = _dbBairro.ObterTodos().ToList();
            
        }

         public IActionResult OnPostEnviar(Denuncia denuncia)
        {

            if(ModelState.IsValid){
                return  RedirectToPage("/Resposta/", denuncia);
            }else

                                                     
            Itens = new Itens();
            ListaTipos = Itens.Listar().ToList();
            ListaBairro = _dbBairro.ObterTodos().ToList();

            return RedirectToAction("Index");

        }
    }
}
