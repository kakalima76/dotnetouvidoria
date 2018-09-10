using System.Collections.Generic;
using System.Linq;

namespace Rio.SMF.CCU.Ouvidoria.Dominio.Models
{
    public class Categoria
    {
        public Categoria()
        {
            
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public IEnumerable<Categoria> Listar(){
            var lista = new List<Categoria>(){
                new Categoria(){Name = "ATUAÇÃO SOBRE IRREGULARIDADES COM MEDIDA EFETIVA", Value = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA"},
                new Categoria(){Name = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA", Value = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA"},
                new Categoria(){Name = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA", Value = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA"},
                new Categoria(){Name = "PROCESSO ABERTO APÓS VISTORIA COM MEDIDAS INICIAIS", Value = "PROCESSO ABERTO APÓS VISTORIA COM MEDIDAS INICIAIS"},
                new Categoria(){Name = "PROCESSO ABERTO APÓS VISTORIA SEM MEDIDAS INICIAIS", Value = "PROCESSO ABERTO APÓS VISTORIA SEM MEDIDAS INICIAIS"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA POR RISCO A INTEGRIDADE", Value = "PROCESSO ABERTO ANTES DA VISTORIA POR RISCO A INTEGRIDADE"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA PARA OPERAÇÃO", Value = "PROCESSO ABERTO ANTES DA VISTORIA PARA OPERAÇÃO"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA PARA POLIS", Value = "PROCESSO ABERTO ANTES DA VISTORIA PARA POLIS"},
                new Categoria(){Name = "RESPOSTA COM OPERAÇÃO DE ORDENAMENTO URBANO", Value = "RESPOSTA COM OPERAÇÃO DE ORDENAMENTO URBANO"},
                new Categoria(){Name = "DEMANDA ATÍPICA", Value = "DEMANDA ATÍPICA"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR LOCAL VAZIO", Value = "SEM POSSIBILIDADE ATENDIMENTO POR LOCAL VAZIO"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR AUSÊNCIA DE INFRAÇÕES", Value = "SEM POSSIBILIDADE ATENDIMENTO POR AUSÊNCIA DE INFRAÇÕES"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM ANÁLISE", Value = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM ANÁLISE"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM VISTORIA", Value = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM VISTORIA"},
                new Categoria(){Name = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM ANÁLISE", Value = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM ANÁLISE"},
                new Categoria(){Name = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM VISTORIA", Value = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM VISTORIA"},
            }.AsEnumerable();

            return lista;
        }
    }
}

