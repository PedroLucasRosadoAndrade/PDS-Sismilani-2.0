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
            public int Id { get; set; }
            public string Nome { get; set; }
            public string CNPJ { get; set; }
            public string Telefone { get; set; }
            public string RazaoSocial { get; set; }
            public string Tipo { get; set; }
            public string Historico { get; set; }
        


    }
}
