using Confitec.Application.Base;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Commands.Validations;

namespace Confitec.Application.Features.Usuario.CommandHandlers
{
    public class CadastrarUsuarioCommandHandler : BaseHandler, IRequestHandler<CadastrarUsuarioCommand, bool>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public CadastrarUsuarioCommandHandler(INotificador notificador,
                                              IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CadastrarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new CadastrarUsuarioValidation(), command)) return false;

            return await _usuarioRepository.Cadastrar(command);
        }
    }
}
