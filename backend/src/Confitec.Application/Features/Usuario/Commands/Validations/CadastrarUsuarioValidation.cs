using FluentValidation;

namespace Confitec.Application.Features.Usuario.Commands.Validations
{
    public class CadastrarUsuarioValidation : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioValidation()
        {
            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome deve ser informado.");

            RuleFor(command => command.Nome)
                .MaximumLength(20)
                .When(command => !string.IsNullOrWhiteSpace(command.Nome))
                .WithMessage("O campo Nome deve ter no máximo 20 caracteres.");

            RuleFor(command => command.Sobrenome)
                .NotEmpty()
                .WithMessage("O campo Sobrenome deve ser informado.");

            RuleFor(command => command.Sobrenome)
                .MaximumLength(100)
                .When(command => !string.IsNullOrWhiteSpace(command.Sobrenome))
                .WithMessage("O campo Sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("O campo Email deve ser informado.");

            RuleFor(command => command.Email)
                .MaximumLength(50)
                .When(command => !string.IsNullOrWhiteSpace(command.Email))
                .WithMessage("O campo Email deve ter no máximo 50 caracteres!");

            RuleFor(command => command.Email)
                .EmailAddress()
                .When(command => !string.IsNullOrWhiteSpace(command.Email))
                .WithMessage("O campo Email deve ser preenchido corretamente!");

            RuleFor(command => command.Email)
                .Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")
                .When(command => !string.IsNullOrWhiteSpace(command.Email))
                .WithMessage("O campo Email é inválido!");

            RuleFor(command => command.DataNascimento)
                .Must(dataNascimento => dataNascimento < DateTime.Now.Date)
                .WithMessage("O campo DataNascimento deve ser maior que a data atual.");

            RuleFor(command => command.DataNascimento)
                .Must(dataNascimento => dataNascimento.AddYears(-15) <= DateTime.Now.Date.AddYears(-15))
                .WithMessage("Usuário não pode ter idade menor que 15 anos.");

            RuleFor(command => command.IdEscolaridade)
                .GreaterThan(0)
                .WithMessage("O campo IdEscolaridade deve ser maior que zero.");
        }
    }
}
