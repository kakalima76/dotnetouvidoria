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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Local
{
        [Authorize]
        public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }
        public IEnumerable<Bairro> ListaBairro{ get; set; }
        public IEnumerable<Denuncia> ListaDenuncia { get; set; }
        private readonly IDenunciaRepository _dbDenuncia;
        private readonly IBairroRepository _dbBairro;

        private readonly ILogradouroRepository _dbLogradouro;
        private IHostingEnvironment _hostingEnvironment;

        public IndexModel
        (
            IDenunciaRepository dbDenuncia,
            IBairroRepository dbBairro,
            ILogradouroRepository dbLogradouro,
            IHostingEnvironment hostingEnvironment
        )
        {
            _dbDenuncia = dbDenuncia;
            _dbBairro = dbBairro;
            _dbLogradouro = dbLogradouro;
            _hostingEnvironment = hostingEnvironment;
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

        public JsonResult OnGetJsonLocais(String bairro, int logradouro){

            var strbairro = _dbBairro.ObterPorIdString(bairro).Nome;
            var strLogradouro = _dbLogradouro.ObterPorId(logradouro).Nome;

            return new JsonResult(_dbDenuncia.Buscar(x => x.bairro.Equals(strbairro) && x.logradouro.Equals(strLogradouro)));
        
        }

        public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }

         public async Task<IActionResult> OnPostExport(string bairro, int logradouro)
        {

            var strbairro = _dbBairro.ObterPorIdString(bairro).Nome;
            var strLogradouro = _dbLogradouro.ObterPorId(logradouro).Nome;

            if(!String.IsNullOrEmpty(strbairro) && !String.IsNullOrEmpty(strLogradouro)){
           
                ListaDenuncia = _dbDenuncia.Buscar(x => x.bairro.Equals(strbairro) && x.logradouro.Equals(strLogradouro));

                string sWebRootFolder = _hostingEnvironment.WebRootPath;
                string sFileName = @"consultaLocais.xlsx";
                string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
                FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                var memory = new MemoryStream();
                using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
                {
                
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Demo");
                    IRow row = excelSheet.CreateRow(0);

                    row.CreateCell(0).SetCellValue("idDenuncia");
                    row.CreateCell(1).SetCellValue("numero");
                    row.CreateCell(2).SetCellValue("categoria");
                    row.CreateCell(3).SetCellValue("data");
                    row.CreateCell(4).SetCellValue("agente");
                    row.CreateCell(5).SetCellValue("processo");
                    row.CreateCell(6).SetCellValue("logradouro");
                    row.CreateCell(7).SetCellValue("complemento");
                    row.CreateCell(8).SetCellValue("bairro");
                    row.CreateCell(9).SetCellValue("cep");
                    row.CreateCell(10).SetCellValue("lat");
                    row.CreateCell(11).SetCellValue("lng");
                    row.CreateCell(12).SetCellValue("respostaPadrao");
                    
                    int cont = 1;

                    foreach(var list in ListaDenuncia){
                        

                        row = excelSheet.CreateRow(cont);
                        row.CreateCell(0).SetCellValue(list.idDenuncia);
                        row.CreateCell(1).SetCellValue(list.numero);
                        row.CreateCell(2).SetCellValue(list.categoria);
                        row.CreateCell(3).SetCellValue(list.Getdata());
                        row.CreateCell(4).SetCellValue(list.agente);
                        row.CreateCell(5).SetCellValue(list.processo);
                        row.CreateCell(6).SetCellValue(list.logradouro);
                        row.CreateCell(7).SetCellValue(list.complemento);
                        row.CreateCell(8).SetCellValue(list.bairro);
                        row.CreateCell(9).SetCellValue(list.cep);
                        row.CreateCell(10).SetCellValue(list.lat);
                        row.CreateCell(11).SetCellValue(list.lng);
                        row.CreateCell(12).SetCellValue(list.respostaPadrao);

                        cont ++;

                    }

                    workbook.Write(fs);
                }
                using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
            }

            return Page();    
        }                
    }
}
