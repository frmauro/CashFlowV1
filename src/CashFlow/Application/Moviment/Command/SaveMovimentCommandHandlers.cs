using CashFlow.Application.Configuration.Commands;
using CashFlow.Application.Exceptions;
using CashFlow.Domain;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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
            if (!isValid(request)) throw new ValidationException();

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

        private bool isValid(SaveMovimentCommand request)
        {
            bool isValid = true;
            if (request.ValueMoviment <= 0)
                isValid = false;

            if (request.TypeMoviment != 0 && request.TypeMoviment != 1)
                isValid = false;

            if (string.IsNullOrEmpty(request.NamePerson))
                isValid = false;

            if (request.TypePerson < 0 && request.TypePerson > 1)
                isValid = false;

            return isValid;
        }
    }
}
