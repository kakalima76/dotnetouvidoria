using System;
using System.ComponentModel.DataAnnotations;


namespace Rio.SMF.CCU.Ouvidoria.Dominio.Models
{
    public class  Denuncia
    
    {
        public Denuncia()
        {
            
        }


        public int idDenuncia { get; set; }

        [Required(ErrorMessage = "Escolha um tipo de denúncia.")]
        [Display(Name = "TIPO DE DENÚNCIA")]
        public Tipos tipo { get; set; }
        public ListaCategoria categoria { get; set; }

       
        [Display(Name = "DATA DA VISITA")]
        public DateTime data { get; set; }
        
        public string agente { get; set; }
        public string processo { get; set; }
        public string logradouro { get; set; }

        [Required(ErrorMessage = "Selecione um bairro.")]
        [Display(Name = "BAIRRO")]
        public string bairro { get; set; }
        public string cep { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string respostaPadrao { get; set; }
    }

    public enum ListaCategoria{
        tipo1,
        tipo2,
        tipo3
    }

    public enum Tipos {
        tipo_1746,
        tipo_ouvidoria
    }

    
}