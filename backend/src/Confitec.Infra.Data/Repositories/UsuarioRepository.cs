using Confitec.Application.Dto;
using Confitec.Application.Features.Usuario.Commands;
using Confitec.Application.Features.Usuario.Queries;
using Confitec.Application.Repositories;
using Confitec.Application.UoW;
using Dapper;
using System.Data;

namespace Confitec.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSession _session;

        public UsuarioRepository(DbSession session)
            => _session = session;

        public async Task<bool> Alterar(AlterarUsuarioCommand command)
        {
            var query = @"UPDATE USUARIO SET 
                                  Nome = @Nome,
                                  Sobrenome = @Sobrenome,
                                  Email = @Email,
                                  DataNascimento = @DataNascimento,
                                  IdEscolaridade = @IdEscolaridade
                               WHERE IdUsuario = @IdUsuario";

            var parms = new DynamicParameters();

            parms.Add("@Nome", command.Nome);
            parms.Add("@Sobrenome", command.Sobrenome);
            parms.Add("@Email", command.Email);
            parms.Add("@DataNascimento", command.DataNascimento);
            parms.Add("@IdEscolaridade", command.IdEscolaridade);
            parms.Add("@IdUsuario", command.IdUsuario);

            var result =
                await _session
                        .Connection
                        .ExecuteAsync(sql: query,
                                      param: parms,
                                      commandType: CommandType.Text,
                                      transaction: _session.Transaction);
            return result > 0;
        }

        public async Task<IEnumerable<UsuarioGridDto>> Buscar(BuscarUsuarioQuery filtros)
        {
            var query = @"SELECT
                              U.IdUsuario,
                              U.Nome,
                              U.Sobrenome,
                              U.Email,
                              U.DataNascimento,
                              U.IdEscolaridade,
                              E.Escolaridade
                          FROM USUARIO U
                          INNER JOIN ESCOLARIDADE E ON U.IdEscolaridade = E.IdEscolaridade
                          WHERE (@Nome is null or U.Nome LIKE '%'+@Nome+'%')
                            AND (@Sobrenome is null or U.Sobrenome LIKE '%'+@Sobrenome+'%')";

            var parms = new DynamicParameters();

            parms.Add("@Nome", filtros.Nome);
            parms.Add("@Sobrenome", filtros.Sobrenome);

            var result =
                await _session
                        .Connection
                        .QueryAsync<UsuarioGridDto>(sql: query,
                                                     param: parms,
                                                     commandType: CommandType.Text,
                                                     transaction: _session.Transaction);
            return result;
        }

        public async Task<UsuarioDto?> BuscarPorId(int idUsuario)
        {
            var query = @"SELECT
                              U.IdUsuario,
                              U.Nome,
                              U.Sobrenome,
                              U.Email,
                              U.DataNascimento,
                              U.IdEscolaridade,
                              E.Escolaridade
                          FROM USUARIO U
                          INNER JOIN ESCOLARIDADE E ON U.IdEscolaridade = E.IdEscolaridade
                          WHERE U.IdUsuario = @IdUsuario";

            var parms = new DynamicParameters();

            parms.Add("@IdUsuario", idUsuario);

            var result =
                await _session
                        .Connection
                        .QuerySingleOrDefaultAsync<UsuarioDto>(sql: query,
                                                                    param: parms,
                                                                    commandType: CommandType.Text,
                                                                    transaction: _session.Transaction);
            return result;
        }

        public async Task<bool> Cadastrar(CadastrarUsuarioCommand command)
        {
            var query = @"INSERT INTO USUARIO(Nome, Sobrenome, Email, DataNascimento, IdEscolaridade)
                          VALUES(@Nome, @Sobrenome, @Email, @DataNascimento, @IdEscolaridade)";

            var parms = new DynamicParameters();

            parms.Add("@Nome", command.Nome);
            parms.Add("@Sobrenome", command.Sobrenome);
            parms.Add("@Email", command.Email);
            parms.Add("@DataNascimento", command.DataNascimento);
            parms.Add("@IdEscolaridade", command.IdEscolaridade);

            var result =
                await _session
                        .Connection
                        .ExecuteAsync(sql: query,
                                      param: parms,
                                      commandType: CommandType.Text,
                                      transaction: _session.Transaction);
            return result > 0;
        }

        public async Task<bool> CadastrarHistoricoEscolar(CadastrarHistoricoEscolarCommand command)
        {
            var query = @"INSERT INTO HISTORICOESCOLAR(Formato, Nome)
                          VALUES(@Formato, @Nome)

                          INSERT INTO USUARIOHISTORICOESCOLAR(IdUsuario, IdHistoricoEscolar)
                          VALUES(@IdUsuario, SCOPE_IDENTITY())";

            var parms = new DynamicParameters();

            var formato = Path.GetExtension(command.Nome).Split(".")[1].ToUpper();

            parms.Add("@Formato", formato);
            parms.Add("@Nome", command.Nome);
            parms.Add("@IdUsuario", command.IdUsuario);

            var result =
                await _session
                        .Connection
                        .ExecuteAsync(sql: query,
                                      param: parms,
                                      commandType: CommandType.Text,
                                      transaction: _session.Transaction);
            return result > 0;
        }

        public async Task<bool> Excluir(int idUsuario)
        {
            var query = @"DECLARE @idsHistoricoEscolar TABLE (id int);

                          INSERT @idsHistoricoEscolar 
                          SELECT IdHistoricoEscolar FROM USUARIOHISTORICOESCOLAR WHERE IdUsuario = @IdUsuario; 
                          
                          DELETE FROM USUARIOHISTORICOESCOLAR WHERE IdUsuario = @IdUsuario;
                          DELETE FROM HISTORICOESCOLAR WHERE IdHistoricoEscolar IN (SELECT id from @idsHistoricoEscolar);
                          DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario";

            var parms = new DynamicParameters();

            parms.Add("@IdUsuario", idUsuario);

            var result =
                await _session
                        .Connection
                        .ExecuteAsync(sql: query,
                                      param: parms,
                                      commandType: CommandType.Text,
                                      transaction: _session.Transaction);
            return result > 0;
        }

        public async Task<bool> ExcluirHistoricoEscolar(int idHistoricoEscolar)
        {
            var query = @"DELETE FROM USUARIOHISTORICOESCOLAR WHERE IdHistoricoEscolar = @IdHistoricoEscolar
                          DELETE FROM HISTORICOESCOLAR WHERE IdHistoricoEscolar = @IdHistoricoEscolar";

            var parms = new DynamicParameters();

            parms.Add("@IdHistoricoEscolar", idHistoricoEscolar);

            var result =
                await _session
                        .Connection
                        .ExecuteAsync(sql: query,
                                      param: parms,
                                      commandType: CommandType.Text,
                                      transaction: _session.Transaction);
            return result > 0;
        }
    }
}
