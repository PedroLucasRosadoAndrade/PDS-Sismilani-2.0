using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PDS_Sismilani.Models
{
    internal class FilmeValitator : AbstractValidator<Filme>
    {
        public FilmeValitator()
        {
            
            //RuleFor(x => x.Endereco.Rua).NotEmpty();
            //RuleFor(x => x.Endereco.Numero).NotEmpty();
            //RuleFor(x => x.Endereco.Bairro).NotEmpty();
            //RuleFor(x => x.Endereco.Cidade).NotEmpty();
            //RuleFor(x => x.Endereco.Estado).NotEmpty();
        }

        public bool CPFValidator(string cpf)
        {
            return true;
        }
    }
}
