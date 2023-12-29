using Confitec.Application.Base;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Confitec.Application.Features.Usuario.Commands.Validations;
using Confitec.Application.Features.Usuario.Commands;

namespace Confitec.Application.Features.HistoricoEscolar.CommandHandlers
{
    public class ExcluirHistoricoEscolarCommandHandler : BaseHandler, IRequestHandler<ExcluirHistoricoEscolarCommand, bool>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public ExcluirHistoricoEscolarCommandHandler(INotificador notificador,
                                                     IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(ExcluirHistoricoEscolarCommand command, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new ExcluirHistoricoEscolarValidation(), command)) return false;

            return await _usuarioRepository.ExcluirHistoricoEscolar(command.IdHistoricoEscolar);
        }
    }
}
