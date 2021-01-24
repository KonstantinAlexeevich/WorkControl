using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace WorkControl.Domain.Work.Commands
{
    public class RenameCommandHandler : CommandHandler<WorkAggregate, WorkId, IExecutionResult, RenameCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(WorkAggregate aggregate, RenameCommand command,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(aggregate.Rename(command.Name));
        }
    }
}