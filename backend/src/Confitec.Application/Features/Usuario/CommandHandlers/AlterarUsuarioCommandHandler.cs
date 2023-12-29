using Confitec.Application.Base;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Commands.Validations;

namespace Confitec.Application.Features.Usuario.CommandHandlers
{
    public class AlterarUsuarioCommandHandler : BaseHandler, IRequestHandler<AlterarUsuarioCommand, bool>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public AlterarUsuarioCommandHandler(INotificador notificador,
                                            IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(AlterarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new AlterarUsuarioValidation(), command)) return false;

            return await _usuarioRepository.Alterar(command);
        }
    }
}
