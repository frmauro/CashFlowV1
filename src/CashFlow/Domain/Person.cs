namespace CashFlow.Domain
{
    public class Person : Entity
    {
        public string? Name { get; set; }
        public PersonType Type { get; set; }

    }
}
