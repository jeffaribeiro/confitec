using Confitec.Application.Base;
using Confitec.Application.Dto;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Features.Usuario.Queries.Validations;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;

namespace Confitec.Application.Features.Usuario.QueryHandlers
{
    public class BuscarUsuarioQueryHandler : BaseHandler, IRequestHandler<BuscarUsuarioQuery, IEnumerable<UsuarioGridDto>>
    {
        public readonly IUsuarioRepository _repository;

        public BuscarUsuarioQueryHandler(INotificador notificador,
                                         IUsuarioRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioGridDto>> Handle(BuscarUsuarioQuery query, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new BuscarUsuarioValidation(), query)) return null!;

            return await _repository.Buscar(query);
        }
    }
}
