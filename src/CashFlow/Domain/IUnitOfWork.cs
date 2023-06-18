namespace CashFlow.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
