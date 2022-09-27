using FluentValidation;
using UGDAT.Business.Models;
using UGDAT.Business.CustonValid;

namespace UGDAT.Business.Validations
{
    public class AberturaValidation : AbstractValidator<Abertura>
    {
       

        public AberturaValidation(string line)
        {
           
            RuleFor(res => res.Registro)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .NotNull().WithMessage("O campo {PropertyName} nao pode ser nulo");

            RuleFor(res => res.Versao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");

             RuleFor(res => res.CodFinalidade)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");

             RuleFor(res => res.IeSolicitante)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido"); 

            RuleFor(res => res.CnpjSolicitante)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Must(vl => vl.IsValidCnpj());

            RuleFor(res => res.RegimeTribultario)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(res => res.DtInicioPeriodo)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(res => res.Ambiente)
             .NotEmpty().WithMessage("O campo {PropertyName} Nao pode ser preenchido")
             .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }

        
    }
}
