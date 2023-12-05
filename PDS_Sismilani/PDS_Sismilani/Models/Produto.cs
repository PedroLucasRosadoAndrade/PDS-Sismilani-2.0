using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Produto
    {

        public int Id { get; set; }

        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime? Validade { get; set; }
        public int Valor { get; set; }
    }
}
