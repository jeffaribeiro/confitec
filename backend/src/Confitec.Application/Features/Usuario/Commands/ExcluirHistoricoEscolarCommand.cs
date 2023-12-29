using MediatR;

namespace Confitec.Application.Features.Usuario.Commands
{
    public class ExcluirHistoricoEscolarCommand : IRequest<bool>
    {
        public int IdHistoricoEscolar { get; set; }
    }
}
