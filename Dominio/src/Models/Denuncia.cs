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
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Required(ErrorMessage = "Escolha um tipo de denúncia.")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Escolha uma categoria.")]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }

       
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Defina uma data.")]
        public DateTime data { get; set; }
        
        public string agente { get; set; }

        [Display(Name = "Número do processo")]
        public string processo { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "Selecione um logradouro.")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "Selecione um bairro.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        public string cep { get; set; }

        public string lat { get; set; }
        
        public string lng { get; set; }
        
        [Required(ErrorMessage = "Gere uma resposta padrão.")]
        [Display(Name = "Resposta padrão")]
        public string respostaPadrao { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }
    }

       
}