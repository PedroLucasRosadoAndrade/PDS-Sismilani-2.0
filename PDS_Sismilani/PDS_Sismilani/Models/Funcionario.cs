using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PDS_Sismilani.Models
{
    internal class Funcionario 
    {
        //public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string CPF { get; set; }
        public double Salario { get; set; }
        public string Funcao { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string RG { get; set; }

        
    }
}
