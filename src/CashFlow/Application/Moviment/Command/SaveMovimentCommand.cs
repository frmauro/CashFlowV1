using CashFlow.Application.Configuration.Commands;
using MediatR;

namespace CashFlow.Application.Moviment.Save
{
    public class SaveMovimentCommand : CommandBase<bool>
    {
        public decimal ValueMoviment { get; }
        public string? TypeMoviment { get; }
        public string? NamePerson { get; }
        public string? TypePerson { get; }
        public SaveMovimentCommand(decimal valueMoviment, string? typeMoviment, string? namePerson, string? typePerson)
        {
            ValueMoviment = valueMoviment;
            TypeMoviment = typeMoviment;
            TypePerson = typePerson;
            NamePerson = namePerson;
        }
    }
}
