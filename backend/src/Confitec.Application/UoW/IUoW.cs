using System.Data.Common;

namespace Confitec.Application.UoW
{
    public interface IUoW : IDisposable
    {
        DbSession Session { get; }
        DbTransaction BeginTransaction();
        bool Commit();
        void Rollback();
        Task BeginTransactionAsync();
        Task<bool> CommitAsync();
        Task RollbackAsync();
        Task DisposeAsync();
    }
}
