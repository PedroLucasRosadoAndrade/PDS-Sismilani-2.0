using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public int QuantidadesDeprodutos { get; set; }
        public double valorTotal { get; set; }
        public string situaca { get; set; }
    }
}
