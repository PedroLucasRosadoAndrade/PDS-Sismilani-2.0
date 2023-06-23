using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Estoque
    {
       // public int Id { get; set; }
        public string Unidade { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
