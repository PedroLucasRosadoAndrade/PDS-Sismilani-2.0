using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime dataNasc { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public string endereco { get; set; }

    }
}
