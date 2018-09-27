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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Data
{
        [Authorize]
        public class IndexModel : PageModel
    {
        [BindProperty]
        public Denuncia Denuncia { get; set; }
        public IEnumerable<Denuncia> ListaDenuncia { get; set; }
        private readonly IDenunciaRepository _dbDenuncia;
        private IHostingEnvironment _hostingEnvironment;

        public IndexModel
        (
            IDenunciaRepository dbDenuncia,
            IHostingEnvironment hostingEnvironment
        )
        {
            _dbDenuncia = dbDenuncia;
            _hostingEnvironment = hostingEnvironment;
        }


        public void OnGet(Denuncia denuncia)
        {
           
            
        }
                      
        public JsonResult OnGetJson(String dataInicio, String dataFim){

            DateTime dtInicio = _dbDenuncia.ConverteStringData(dataInicio);
            DateTime dtFim = _dbDenuncia.ConverteStringData(dataFim);

            return new JsonResult(_dbDenuncia.ObterTodos().Where(x => x.data >= dtInicio && x.data <= dtFim));
            
        }

        public async Task<IActionResult> OnPostLogout(){
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostExport(string DataInicio, string DataFim)
        {

            if(!String.IsNullOrEmpty(DataInicio) && !String.IsNullOrEmpty(DataFim)){
           

                DateTime dtInicio = Convert.ToDateTime(DataInicio);
                DateTime dtFim = Convert.ToDateTime(DataFim);

                ListaDenuncia = _dbDenuncia.Buscar(x => x.data >= dtInicio && x.data <= dtFim);

                string sWebRootFolder = _hostingEnvironment.WebRootPath;
                string sFileName = @"consultaPorData.xlsx";
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
                        row.CreateCell(3).SetCellValue(list.data);
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
