using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Valor { get; set; }

        public string Codigo { get; set; }

        public string Fornecedor { get; set; }

        public string Unidade { get; set; }

        public DateTime? DataFilme { get; set; }
    }
}
