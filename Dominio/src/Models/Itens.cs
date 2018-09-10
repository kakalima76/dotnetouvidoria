using System.Collections.Generic;
using System.Linq;

namespace Rio.SMF.CCU.Ouvidoria.Dominio.Models
{
    public class Itens
    {
        public string Name { get; set; }
        public string Value { get; set; }
       
        public IEnumerable<Itens> Listar(){
            var lista = new List<Itens>(){
                new Itens(){Name = "1746", Value = "0"},
                new Itens(){Name = "Ouvidoria", Value = "1"}
            }.AsEnumerable();

            return lista;
        }

        
    }

   
}