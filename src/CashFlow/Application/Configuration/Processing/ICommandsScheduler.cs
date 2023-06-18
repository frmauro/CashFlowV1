using CashFlow.Application.Configuration.Commands;

namespace CashFlow.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
