using CashFlow.Application.Configuration.Queries;
using CashFlow.Domain;

namespace CashFlow.Application.Moviment.Query
{
    public class GetAllQuery : IQuery<List<Movement>>
    {
        public GetAllQuery()
        {
        }
    }
}
