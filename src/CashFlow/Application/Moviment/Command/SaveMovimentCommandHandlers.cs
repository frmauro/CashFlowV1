using CashFlow.Application.Configuration.Commands;
using CashFlow.Application.Exceptions;
using CashFlow.Domain;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace CashFlow.Application.Moviment.Save
{
    internal sealed class SaveMovimentCommandHandlers : ICommandHandler<SaveMovimentCommand, bool>
    {
        private readonly IMovementRepository _repository;

        public SaveMovimentCommandHandlers(IMovementRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(SaveMovimentCommand request, CancellationToken cancellationToken)
        {
            if (!isValid(request)) return false;

            var entity = new Movement
            {
                Value = request.ValueMoviment,
                Data = DateTime.Now.Date,
                Type = (MovementType)Convert.ToInt32(request.TypeMoviment),
                Person = new Person()
            };
            entity.Person.Type = (PersonType)Convert.ToInt32(request.TypePerson);
            entity.Person.Name = request.NamePerson;
            await _repository.AddAsync(entity);
            return true;
        }

        private bool isValid(SaveMovimentCommand request)
        {
            if (request.ValueMoviment <= 0) return false;

            if (string.IsNullOrEmpty(request.TypeMoviment)) return false;

            if (request.TypeMoviment != "0" & request.TypeMoviment != "1") return false;

            if (string.IsNullOrEmpty(request.NamePerson)) return false;

            if (string.IsNullOrEmpty(request.TypePerson)) return false;

            if (request.TypePerson != "0" & request.TypePerson != "1") return false;

            return true;
        }
    }
}
