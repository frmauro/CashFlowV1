namespace CashFlow.Domain
{
    public interface IMovementRepository
    {
        Task<Movement> GetByIdAsync(int id);

        Task AddAsync(Movement movement);

        Task<int> DeleteAllAsync();
    }
}
