using Confitec.Application.Dto;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Repositories;
using Confitec.Application.UoW;
using Dapper;
using System.Data;

namespace Confitec.Infra.Data.Repositories
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        private readonly DbSession _session;

        public EscolaridadeRepository(DbSession session)
            => _session = session;

        public async Task<IEnumerable<EscolaridadeDto>> Buscar()
        {
            var query = @"SELECT
                              E.IdEscolaridade,
                              E.Escolaridade
                          FROM ESCOLARIDADE E
                          ORDER BY E.IdEscolaridade";

            var result =
                await _session
                        .Connection
                        .QueryAsync<EscolaridadeDto>(sql: query,
                                                     commandType: CommandType.Text,
                                                     transaction: _session.Transaction);
            return result;
        }
    }
}
