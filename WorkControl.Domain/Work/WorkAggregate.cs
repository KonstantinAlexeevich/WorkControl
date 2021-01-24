using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using WorkControl.Domain.Work.Events;

namespace WorkControl.Domain.Work
{
    public class WorkAggregate : AggregateRoot<WorkAggregate, WorkId>, IEmit<RenameEvent>
    {
        public const int SnapshotEveryVersion = 100;

        public WorkAggregate(WorkId id) : base(id)
        {
        }

        public string WorkName { get; set; }
        public IReadOnlyCollection<WorkSnapshotVersion> SnapshotVersions { get; } = new WorkSnapshotVersion[] { };

        // protected override Task<WorkSnaphost> CreateSnapshotAsync(CancellationToken cancellationToken)
        // {
        //   return Task.FromResult(new WorkSnaphost(WorkName, Enumerable.Empty<WorkSnapshotVersion>()));
        // }
        //
        // protected override Task LoadSnapshotAsync(WorkSnaphost snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken)
        // {
        //   WorkName = snapshot.Name;
        //   SnapshotVersions = snapshot.PreviousVersions;
        //   return Task.CompletedTask;
        // }

        public void Apply(RenameEvent aggregateEvent)
        {
            WorkName = aggregateEvent.Name;
        }

        public IExecutionResult Rename(string name)
        {
            Emit(new RenameEvent(name));
            return ExecutionResult.Success();
        }
    }
}