namespace CashFlow.Domain
{
    public class Movement : Entity
    {
        public decimal Value { get; set; }
        public MovementType Type { get; set; }
        public required Person Person { get; set; }
    }
}
