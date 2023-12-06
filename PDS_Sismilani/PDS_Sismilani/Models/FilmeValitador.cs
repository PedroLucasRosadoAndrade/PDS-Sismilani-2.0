using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PDS_Sismilani.Models
{
    internal class FilmeValitador : AbstractValidator <Filme>
    {

        public FilmeValitador()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("O campo `TÍTULO` é OBRIGATÓRIO.Por favor preencha");
            RuleFor(x => x.Sinopse).NotEmpty().WithMessage("O campo `SINOPSE` é OBRIGATÓRIO.Por favor preencha");

        }

    }
}
