using Confitec.Application.Base;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Commands.Validations;

namespace Confitec.Application.Features.Usuario.CommandHandlers
{
    public class ExcluirUsuarioCommandHandler : BaseHandler, IRequestHandler<ExcluirUsuarioCommand, bool>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public ExcluirUsuarioCommandHandler(INotificador notificador,
                                            IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(ExcluirUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new ExcluirUsuarioValidation(), command)) return false;

            return await _usuarioRepository.Excluir(command.IdUsuario);
        }
    }
}
