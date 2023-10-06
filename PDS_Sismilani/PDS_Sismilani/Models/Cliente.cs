using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Cliente
    {
        public string id {  get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public DateTime? dataNasc { get; set; }
        public string cpf { get; set; }
        public string rua { get; set; }
        public string senha { get; set;}
        public string sexo { get; set; }
        public string bairro { get; set; }
        public string id_log_fk { get; set; }
        public string id_ing_fk { get; set; }
        public string id_end_fk { get; set; }

    }
}
