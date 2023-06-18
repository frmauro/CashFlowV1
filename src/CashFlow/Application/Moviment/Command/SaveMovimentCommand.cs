using CashFlow.Application.Configuration.Commands;
using MediatR;

namespace CashFlow.Application.Moviment.Save
{
    public class SaveMovimentCommand : CommandBase<Unit>
    {
        public decimal ValueMoviment { get; }
        public int TypeMoviment { get; }
        public string? NamePerson { get; }
        public int TypePerson { get; }
        public SaveMovimentCommand(decimal valueMoviment, int typeMoviment, string? namePerson, int typePerson)
        {
            ValueMoviment = valueMoviment;
            TypeMoviment = typeMoviment;
            TypePerson = typePerson;
            NamePerson = namePerson;
        }
    }
}
