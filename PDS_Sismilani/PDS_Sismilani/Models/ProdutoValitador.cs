using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace PDS_Sismilani.Models
{
    internal class ProdutoValitador : AbstractValidator<Produto>
    {
        public ProdutoValitador()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo `NOME` é OBRIGATÓRIO.Por favor preencha");

        }
    }
}
