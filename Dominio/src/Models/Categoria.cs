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
                new Categoria(){Name = "ATUAÇÃO SOBRE IRREGULARIDADES COM MEDIDA EFETIVA",                          Value = "0"},
                new Categoria(){Name = "ATUAÇÃO SOBRE IRREGULARIDADES SEM MEDIDA CONCLUSIVA",                       Value = "1"},
                new Categoria(){Name = "PROCESSO ABERTO APÓS VISTORIA COM MEDIDAS INICIAIS",                        Value = "2"},
                new Categoria(){Name = "PROCESSO ABERTO APÓS VISTORIA SEM MEDIDAS INICIAIS",                        Value = "3"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA POR RISCO A INTEGRIDADE",                 Value = "4"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA PARA OPERAÇÃO",                           Value = "5"},
                new Categoria(){Name = "PROCESSO ABERTO ANTES DA VISTORIA PARA POLIS",                              Value = "6"},
                new Categoria(){Name = "RESPOSTA COM OPERAÇÃO DE ORDENAMENTO URBANO",                               Value = "7"},
                new Categoria(){Name = "DEMANDA ATÍPICA",                                                           Value = "8"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR LOCAL VAZIO",                             Value = "9"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR AUSÊNCIA DE INFRAÇÕES",                   Value = "10"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM ANÁLISE",      Value = "11"},
                new Categoria(){Name = "SEM POSSIBILIDADE ATENDIMENTO POR INFORMAÇÕES INCORRETAS COM VISTORIA",     Value = "12"},
                new Categoria(){Name = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM ANÁLISE",                             Value = "13"},
                new Categoria(){Name = "TRANSFERÊNCIA DE CHAMADO INDEVIDO COM VISTORIA",                            Value = "14"},
            }.AsEnumerable();

            return lista;
        }
    }
}

