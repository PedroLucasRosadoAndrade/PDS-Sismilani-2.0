using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PDS_Sismilani.Models
{
    internal class FuncionarioValitador : AbstractValidator<Funcionario>
    {
        public FuncionarioValitador()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo `Nome` é Obrigatório. Favor Preencher");
            RuleFor(x => x.CPF).NotEqual("___.___.___-__").WithMessage("O campo `CPF` é obrigatório. Favor Preencher");
            RuleFor(x => x.CPF).Must(CPFValidator).WithMessage("CPF inválido");
            RuleFor(x => x.Celular).NotEqual("(__)_____-____").WithMessage("O campo `Celular` é obrigatório. Favor Preencher");
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
