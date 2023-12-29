using Confitec.Application.Dto;

namespace Confitec.Application.Repositories
{
    public interface IEscolaridadeRepository
    {
        Task<IEnumerable<EscolaridadeDto>> Buscar();
    }
}
