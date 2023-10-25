using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Filme
    {
        public string id {  get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public string Fornecedorn { get; set; }

        public int Codigo { get; set; }
        public int Unidade { get; set; }    
        public double Valor { get; set; }   
        public DateTime Data { get; set; }


    }
}
