using MediatR;

namespace Confitec.Application.Features.Usuario.Commands
{
    public class CadastrarHistoricoEscolarCommand : IRequest<bool>
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Arquivo { get; set; } = null!;
    }
}
