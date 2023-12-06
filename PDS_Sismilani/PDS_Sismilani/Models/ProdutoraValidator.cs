using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;


namespace PDS_Sismilani.Models
{
    internal class ProdutoraValidator
    {
        private static readonly Regex CnpjRegex = new Regex(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", RegexOptions.Compiled);

        public static bool ValidarCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Apenas para verificar o formato. Para validação completa, adicione a verificação dos dígitos verificadores.
            return CnpjRegex.IsMatch(cnpj);
        }


    }
}
