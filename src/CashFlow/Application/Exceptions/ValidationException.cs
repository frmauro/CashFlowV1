using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashFlow.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occurred.") { }
    }
}
