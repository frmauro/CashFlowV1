using MediatR;

namespace CashFlow.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
