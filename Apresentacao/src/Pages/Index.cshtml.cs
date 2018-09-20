using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Usuario Usuario { get; set; }
        private readonly IUsuarioRepository _db;

        public IndexModel(IUsuarioRepository db)
        {
            _db = db;            
        }

        public void OnGet()
        {
                                               
       
            
        }

         public async Task<IActionResult> OnPostAsync(Usuario usuario)
        {

            if(!ModelState.IsValid){
                return  Page();
            }

            

            if(_db.loginIsAuthenticated(usuario.Nome, usuario.Password) ){

                var status = _db.Buscar(x => x.Nome.Equals(usuario.Nome)).FirstOrDefault().Status;
                

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, status)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToPage("/Formulario/index");
            }


           return Page();

        }

    }
}
