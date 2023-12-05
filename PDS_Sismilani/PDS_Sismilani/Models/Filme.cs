using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Filme
    {
        public int Id {  get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Fornecedor { get; set; }
        public string Diretor { get; set; }
        public string Categoria { get; set; }
        public string Elenco { get; set; }    
        public DateTime? DataLancamento { get; set; }


    }
}
