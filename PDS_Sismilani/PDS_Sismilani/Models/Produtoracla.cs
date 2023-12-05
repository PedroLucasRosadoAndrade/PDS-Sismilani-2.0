 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
namespace PDS_Sismilani.Models
{
    internal class Produtoracla
    {
     
        public int id { get; set; }
        public string nome  { get; set; }
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public string rasao_social { get; set; }
        public string tipo { get; set; }
        public string historico { get; set; }
       

    }
}
