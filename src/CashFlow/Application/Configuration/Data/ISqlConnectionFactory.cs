using System.Data;

namespace CashFlow.Application.Configuration.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
