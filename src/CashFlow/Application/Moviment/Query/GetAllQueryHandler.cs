using CashFlow.Application.Configuration.Data;
using CashFlow.Application.Configuration.Queries;
using CashFlow.Domain;
using Dapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Data.SqlClient;

namespace CashFlow.Application.Moviment.Query
{
    public class GetAllQueryHandler : IQueryHandler<GetAllQuery, List<Movement>>
    {
        private readonly IConfiguration _configuration;

        public GetAllQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Movement>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var sql = "select m.Id, m.[Value], m.[Type], m.PersonId, m.[Data], p.Id, p.[Name], p.[Data], p.[Type] from Movements m inner join Person p on m.PersonId = p.Id ";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MovementDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Movement, Person, Movement>(sql, (Movement, Person) =>
                {
                    Movement.Person = Person;
                    return Movement;
                }, splitOn: "PersonId");
                return result.ToList();
            }
        }
    }
}
