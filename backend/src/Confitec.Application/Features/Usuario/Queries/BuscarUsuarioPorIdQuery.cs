using Confitec.Application.Dto;
using MediatR;

namespace Confitec.Application.Features.Usuario.Queries
{
    public class BuscarUsuarioPorIdQuery : IRequest<UsuarioDto?>
    {
        public int IdUsuario { get; set; }
    }
}
