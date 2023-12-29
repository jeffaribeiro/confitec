using FluentValidation;

namespace Confitec.Application.Features.Usuario.Queries.Validations
{
    public class BuscarUsuarioPorIdValidation : AbstractValidator<BuscarUsuarioPorIdQuery>
    {
        public BuscarUsuarioPorIdValidation()
        {
            RuleFor(query => query.IdUsuario)
                .GreaterThan(0)
                .WithMessage("O campo IdUsuario deve ser maior que zero.");
        }
    }
}
