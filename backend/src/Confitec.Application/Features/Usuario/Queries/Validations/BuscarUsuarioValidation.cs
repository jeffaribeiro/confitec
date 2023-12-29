using FluentValidation;

namespace Confitec.Application.Features.Usuario.Queries.Validations
{
    public class BuscarUsuarioValidation : AbstractValidator<BuscarUsuarioQuery>
    {
        public BuscarUsuarioValidation()
        {
            RuleFor(query => query.Nome)
                .MaximumLength(20)
                .When(query => !string.IsNullOrWhiteSpace(query.Nome))
                .WithMessage("O campo Nome deve ter no máximo 20 caracteres.");

            RuleFor(query => query.Sobrenome)
                .MaximumLength(100)
                .When(query => !string.IsNullOrWhiteSpace(query.Sobrenome))
                .WithMessage("O campo Sobrenome deve ter no máximo 100 caracteres.");
        }
    }
}
