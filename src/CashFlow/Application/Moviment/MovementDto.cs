namespace CashFlow.Application.Moviment
{
    public class MovementDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal MovementValue { get; set; }
        public string? MovementType { get; set; }
        public string? PersonName { get; set; }
        public string? PersonType { get; set;}

    }
}
