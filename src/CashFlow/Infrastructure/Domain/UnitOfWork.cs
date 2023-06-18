using CashFlow.Domain;
using CashFlow.Infrastructure.Database;

namespace CashFlow.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovementContext _movementContext;
        public UnitOfWork(MovementContext movementContext)
        {
            _movementContext = movementContext;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await this._movementContext.SaveChangesAsync(cancellationToken);
        }
    }
}
