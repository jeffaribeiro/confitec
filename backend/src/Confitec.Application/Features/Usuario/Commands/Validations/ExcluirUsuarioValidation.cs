using FluentValidation;

namespace Confitec.Application.Features.Usuario.Commands.Validations
{
    public class ExcluirUsuarioValidation : AbstractValidator<ExcluirUsuarioCommand>
    {
        public ExcluirUsuarioValidation()
        {
            RuleFor(command => command.IdUsuario)
                .GreaterThan(0)
                .WithMessage("O campo IdUsuario deve ser maior que zero.");
        }
    }
}
