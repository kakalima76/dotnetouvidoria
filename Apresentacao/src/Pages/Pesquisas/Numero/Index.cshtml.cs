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

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Numero
{
        [Authorize]
        public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }
       


        private readonly IDenunciaRepository _dbDenuncia;


        public IndexModel
        (
            IDenunciaRepository dbDenuncia
   
        )
        {
            _dbDenuncia = dbDenuncia;
            
        }
       
        public void OnGet()
        {
           
            
        }
                      
        public JsonResult OnGetJson(String numero){

            return new JsonResult(_dbDenuncia.Buscar(x => x.numero.Equals(numero)));
            
        }

        public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }

                      
    }
}
