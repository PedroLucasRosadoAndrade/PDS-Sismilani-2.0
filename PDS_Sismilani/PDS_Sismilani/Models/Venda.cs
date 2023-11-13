using Org.BouncyCastle.Asn1.Cms;
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
        public DateTime DataVen { get; set; }
        public Time Hora { get; set; }
        public int QuantidadesDeprodutos { get; set; }
        public string Descricao { get; set; }
        public int IdRec { get; set; }
        public int IdFun { get; set; }
    }
}
