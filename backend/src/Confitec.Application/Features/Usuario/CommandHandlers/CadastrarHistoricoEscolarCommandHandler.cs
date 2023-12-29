using Confitec.Application.Base;
using Confitec.Application.Notifications;
using Confitec.Application.Repositories;
using MediatR;
using Confitec.Application.Features.Usuario.Commands.Validations;
using Confitec.Application.Features.Usuario.Commands;

namespace Confitec.Application.Features.HistoricoEscolar.CommandHandlers
{
    public class CadastrarHistoricoEscolarCommandHandler : BaseHandler, IRequestHandler<CadastrarHistoricoEscolarCommand, bool>
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public CadastrarHistoricoEscolarCommandHandler(INotificador notificador,
                                                       IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CadastrarHistoricoEscolarCommand command, CancellationToken cancellationToken)
        {
            if (!ExecutarValidacao(new CadastrarHistoricoEscolarValidation(), command)) return false;

            var formato = Path.GetExtension(command.Nome).Split(".")[1].ToUpper();

            if (!formato.Equals("DOCX") && !formato.Equals("PDF"))
            {
                Notificar("O histórico escolar deve ser um arquivo no formato PDF ou DOCX.");
                return false;
            }

            var sucessoUpload = await UploadArquivo(command.Arquivo, command.Nome);

            if (!sucessoUpload)
                return false;

            return await _usuarioRepository.CadastrarHistoricoEscolar(command);
        }

        private async Task<bool> UploadArquivo(string arquivo, string arquivoNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                Notificar("Forneça um arquivo para este histórico escolar!");
                return false;
            }

            var arquivoDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", arquivoNome);

            if (File.Exists(filePath))
            {
                Notificar("Já existe um arquivo com este nome!");
                return false;
            }

            await File.WriteAllBytesAsync(filePath, arquivoDataByteArray);

            return true;
        }
    }
}
