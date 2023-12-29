using MediatR;

namespace Confitec.Application.Features.Usuario.Commands
{
    public class ExcluirUsuarioCommand : IRequest<bool>
    {
        public int IdUsuario { get; set; }
    }
}
