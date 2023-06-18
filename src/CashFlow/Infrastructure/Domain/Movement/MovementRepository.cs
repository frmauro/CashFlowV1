using CashFlow.Domain;
using CashFlow.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Domain.Movement
{
    public class MovementRepository : IMovementRepository
    {
        private readonly MovementContext _context;

        public MovementRepository(MovementContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(CashFlow.Domain.Movement movement)
        {
            await this._context.Movements.AddAsync(movement);
            this._context.SaveChanges();
        }

        public async Task<int> DeleteAllAsync()
        {
            return await _context.Movements.ExecuteDeleteAsync();
        }

        public async Task<CashFlow.Domain.Movement> GetByIdAsync(int id)
        {
            return await _context.Movements.FindAsync(id);
        }
    }
}
