using FluentValidation;

namespace Confitec.Application.Features.Usuario.Commands.Validations
{
    public class CadastrarHistoricoEscolarValidation : AbstractValidator<CadastrarHistoricoEscolarCommand>
    {
        public CadastrarHistoricoEscolarValidation()
        {
            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome deve ser informado.");

            RuleFor(command => command.Nome)
                .MaximumLength(200)
                .WithMessage("O campo Nome deve ter no máximo 200 caracteres.");

            RuleFor(command => command.IdUsuario)
                .GreaterThan(0)
                .WithMessage("O campo IdUsuario deve ser maior que zero.");
        }
    }
}
