using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace WorkControl.Domain.Work.Commands
{
    public class RenameCommand : Command<WorkAggregate, WorkId, IExecutionResult>
    {
        public RenameCommand(
            WorkId aggregateId,
            string name
        ) : base(aggregateId)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}