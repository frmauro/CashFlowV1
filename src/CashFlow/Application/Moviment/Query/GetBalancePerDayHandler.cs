using CashFlow.Application.Configuration.Data;
using CashFlow.Application.Configuration.Queries;
using CashFlow.Domain;
using Dapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Data.SqlClient;

namespace CashFlow.Application.Moviment.Query
{
    public class GetBalancePerDayHandler : IQueryHandler<GetBalancePerDay, object>
    {
        private readonly IConfiguration _configuration;

        public GetBalancePerDayHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<dynamic> Handle(GetBalancePerDay request, CancellationToken cancellationToken)
        {
            var sql = "SELECT  Data, SUM(value) as Saldo FROM Movements GROUP BY data ";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MovementDB")))
            {
                connection.Open();
                var consolidationMovements = await connection.QueryAsync<dynamic>(sql);
                return consolidationMovements;
            }
        }
    }
}
