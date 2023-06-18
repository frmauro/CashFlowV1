using CashFlow.Application.Configuration.Commands;
using CashFlow.Domain;
using MediatR;
using static Dapper.SqlMapper;

namespace CashFlow.Application.Moviment.Command
{
    public class DeleteAllMovementCommandHandler : ICommandHandler<DeleteAllMovementCommand, Unit>
    {
        private readonly IMovementRepository _repository;

        public DeleteAllMovementCommandHandler(IMovementRepository repository)
        {
                _repository = repository;
        }
        public async Task<Unit> Handle(DeleteAllMovementCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAllAsync();
            return Unit.Value;
        }
    }
}
