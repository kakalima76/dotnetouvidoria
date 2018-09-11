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

        [Required(ErrorMessage = "Informe um número para a denúcia.")]
        [Display(Name = "NUMERO DA DENÚNCIA")]
        public string numero { get; set; }

        [Required(ErrorMessage = "Escolha um tipo de denúncia.")]
        [Display(Name = "TIPO DE DENÚNCIA")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Escolha uma categoria.")]
        [Display(Name = "CATEGORIA DA DENÚNCIA")]
        public string categoria { get; set; }

       
        [Display(Name = "DATA DA VISITA")]
        [Required(ErrorMessage = "Defina uma data.")]
        public DateTime data { get; set; }
        
        public string agente { get; set; }

        [Display(Name = "NÚMERO DO PROCESSO")]
        public string processo { get; set; }

        [Display(Name = "LOGRADOURO")]
        [Required(ErrorMessage = "Selecione um logradouro.")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "Selecione um bairro.")]
        [Display(Name = "BAIRRO")]
        public string bairro { get; set; }

        public string cep { get; set; }

        public string lat { get; set; }
        
        public string lng { get; set; }
        
        [Display(Name = "RESPOSTA PADRÃO")]
        public string respostaPadrao { get; set; }

        [Display(Name = "COMPLEMENTO")]
        public string complemento { get; set; }
    }

   

    
    
}