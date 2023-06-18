using CashFlow.Application.Configuration.Commands;
using CashFlow.Domain;
using MediatR;

namespace CashFlow.Application.Moviment.Save
{
    internal sealed class SaveMovimentCommandHandlers : ICommandHandler<SaveMovimentCommand, Unit>
    {
        private readonly IMovementRepository _repository;

        public SaveMovimentCommandHandlers(IMovementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(SaveMovimentCommand request, CancellationToken cancellationToken)
        {
            if (request.ValueMoviment <= 0)
                return Unit.Value;

            if (request.TypeMoviment != 0 && request.TypeMoviment != 1)
                return Unit.Value;

            if (string.IsNullOrEmpty(request.NamePerson))
                return Unit.Value;

            if (request.TypePerson < 0 && request.TypePerson > 1)
                return Unit.Value;

            var entity = new Movement
            {
                Value = request.ValueMoviment,
                Data = DateTime.Now,
                Type = (MovementType)request.TypeMoviment,
                Person = new Person()
            };
            entity.Person.Type = (PersonType)request.TypePerson;
            entity.Person.Name = request.NamePerson;
            await _repository.AddAsync(entity);
            return Unit.Value;
        }
    }
}
