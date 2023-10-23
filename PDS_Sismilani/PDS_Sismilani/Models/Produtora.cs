 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
namespace PDS_Sismilani.Models
{
    internal class Produtora
    {
     
        public string id { get; set; }
        public string atores { get; set; }
        public string sinopse { get; set; }
        public string elenco { get; set; }
        public string fornecedor { get; set; }
        public string titulo { get; set; }
        public DateTime datafilm { get; set; }
        public DateTime datalancamento { get; set; }
        public string categoria { get; set; }
        public string diretor { get; set; }
       

    }
}
