using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.WebApi.Controllers
{
    [ApiController]
    [Route("api/escolaridade")]
    public class EscolaridadeController : BaseController
    {
        private readonly IEscolaridadeRepository _repository;

        public EscolaridadeController(INotificador notificador,
                                      IEscolaridadeRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
            => CustomResponse(await _repository.Buscar());
    }
}