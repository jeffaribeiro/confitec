using MediatR;

namespace Confitec.Application.Features.Usuario.Commands
{
    public class CadastrarUsuarioCommand : IRequest<bool>
    {
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public int IdEscolaridade { get; set; }
    }
}
