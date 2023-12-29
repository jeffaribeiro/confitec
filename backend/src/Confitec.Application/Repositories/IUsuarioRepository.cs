using Confitec.Application.Dto;
using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Queries;

namespace Confitec.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioGridDto>> Buscar(BuscarUsuarioQuery filtros);
        Task<UsuarioDto?> BuscarPorId(int idUsuario);
        Task<bool> Cadastrar(CadastrarUsuarioCommand command);
        Task<bool> CadastrarHistoricoEscolar(CadastrarHistoricoEscolarCommand command);
        Task<bool> Alterar(AlterarUsuarioCommand command);
        Task<bool> Excluir(int idUsuario);
        Task<bool> ExcluirHistoricoEscolar(int idHistoricoEscolar);
    }
}
