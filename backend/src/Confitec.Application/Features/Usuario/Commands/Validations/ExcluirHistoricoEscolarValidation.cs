using FluentValidation;

namespace Confitec.Application.Features.Usuario.Commands.Validations
{
    public class ExcluirHistoricoEscolarValidation : AbstractValidator<ExcluirHistoricoEscolarCommand>
    {
        public ExcluirHistoricoEscolarValidation()
        {
            RuleFor(command => command.IdHistoricoEscolar)
                .GreaterThan(0)
                .WithMessage("O campo IdHistoricoEscolar deve ser maior que zero.");
        }
    }
}
