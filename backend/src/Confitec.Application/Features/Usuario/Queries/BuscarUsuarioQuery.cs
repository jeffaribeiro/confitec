using Confitec.Application.Dto;
using MediatR;

namespace Confitec.Application.Features.Usuario.Queries
{
    public class BuscarUsuarioQuery : IRequest<IEnumerable<UsuarioGridDto>>
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
    }
}
