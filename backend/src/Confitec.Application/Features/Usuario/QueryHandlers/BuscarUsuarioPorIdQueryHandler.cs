using Confitec.Application.Base;
using Confitec.Application.Dto;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Features.Usuario.Queries.Validations;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;

namespace Confitec.Application.Features.Usuario.QueryHandlers
{
    public class BuscarUsuarioPorIdQueryHandler : BaseHandler, IRequestHandler<BuscarUsuarioPorIdQuery, UsuarioDto?>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public BuscarUsuarioPorIdQueryHandler(INotificador notificador,
                                              IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto?> Handle(BuscarUsuarioPorIdQuery query, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new BuscarUsuarioPorIdValidation(), query)) return null!;

            return await _usuarioRepository.BuscarPorId(query.IdUsuario);
        }
    }
}
