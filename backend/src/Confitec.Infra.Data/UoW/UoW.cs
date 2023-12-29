using Confitec.Application.UoW;
using System.Data.Common;

namespace Confitec.Infra.Data.UoW
{
    public sealed class UoW : IUoW, IDisposable
    {
        public DbSession Session { get; }

        public UoW(DbSession session)
        {
            Session = session;
            BeginTransaction();
        }

        public DbTransaction BeginTransaction()
        {
            if (Session.Transaction is null)
                Session.Transaction = Session.Connection.BeginTransaction();

            return Session.Transaction;
        }

        public bool Commit()
        {
            try
            {
                Session.Transaction.Commit();

                if (Session.Transaction != null)
                {
                    Console.WriteLine("Commit bem-sucedido!");
                    return true;
                }
                else
                {
                    Console.WriteLine("O commit falhou. A transação foi revertida.");
                    Rollback();
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Erro inesperado durante o commit. A transação foi revertida.");
                Rollback();
                return false;
            }
        }

        public void Rollback()
        {
            Session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            Session.Transaction = null!;
            Session.Connection.Close();
            Session.Connection.Dispose();
        }

        public async Task BeginTransactionAsync()
        {
            DbSession session = Session;
            session.Transaction = await Session.Connection.BeginTransactionAsync();
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await Session.Transaction.CommitAsync();

                if (Session.Transaction != null)
                {
                    Console.WriteLine("Commit bem-sucedido!");
                    await DisposeAsync();
                    return true;
                }
                else
                {
                    Console.WriteLine("A transação foi revertida. O commit falhou.");
                    await DisposeAsync();
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Erro durante o commit. A transação foi revertida.");
                await RollbackAsync();
                return false;
            }

        }

        public async Task RollbackAsync()
        {
            await Session.Transaction.RollbackAsync();
            await DisposeAsync();
        }

        public async Task DisposeAsync()
        {
            Session.Transaction = null!;
            await Session.Connection.CloseAsync();
            await Session.Connection.DisposeAsync();
        }
    }
}
