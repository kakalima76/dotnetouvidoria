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

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Conta
{

    [Authorize(Roles="admin")]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UsuarioCadastro Usuario { get; set; }
        private readonly IUsuarioRepository _db;

        public IndexModel(IUsuarioRepository db)
        {
            _db = db;
        }

        public void OnGet()
        {
       
            
        }

        public IActionResult OnPost(Usuario usuario)
        {
           if(ModelState.IsValid){
               usuario.Status = "usuario";
               _db.Adicionar(usuario);
               return RedirectToAction("onGet");
           }

           return Page();
        }

        public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }   
         
    }
}
