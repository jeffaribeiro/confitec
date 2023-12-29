using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.WebApi.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IMediator _mediator;

        public UsuarioController(INotificador notificador,
                                 IMediator mediator) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] BuscarUsuarioQuery request)
            => CustomResponse(await _mediator.Send(request));

        [HttpGet("{idUsuario:int}")]
        public async Task<IActionResult> BuscarPorId(int idUsuario)
        {
            var request = new BuscarUsuarioPorIdQuery { IdUsuario = idUsuario };
            return CustomResponse(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioCommand request)
        {
            return CustomResponse(await _mediator.Send(request));
        }

        [HttpPut("{idUsuario:int}")]
        public async Task<IActionResult> Alterar(int idUsuario, [FromBody] AlterarUsuarioCommand request)
        {
            if (idUsuario != request.IdUsuario)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            return CustomResponse(await _mediator.Send(request));
        }

        [HttpDelete("{idUsuario:int}")]
        public async Task<IActionResult> Excluir(int idUsuario)
        {
            var request = new ExcluirUsuarioCommand { IdUsuario = idUsuario };
            return CustomResponse(await _mediator.Send(request));
        }

        [HttpPost("historico")]
        public async Task<IActionResult> CadastrarHistoricoEscolar([FromBody] CadastrarHistoricoEscolarCommand request)
        {
            return CustomResponse(await _mediator.Send(request));
        }

        [HttpDelete("historico/{idHistoricoEscolar:int}")]
        public async Task<IActionResult> ExcluirHistoricoEscolar(int idHistoricoEscolar)
        {
            var request = new ExcluirHistoricoEscolarCommand { IdHistoricoEscolar = idHistoricoEscolar };
            return CustomResponse(await _mediator.Send(request));
        }
    }
}