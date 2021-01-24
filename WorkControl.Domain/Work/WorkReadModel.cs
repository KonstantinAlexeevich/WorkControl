using EventFlow.Aggregates;
using EventFlow.ReadStores;
using WorkControl.Domain.Work.Events;

namespace WorkControl.Domain.Work
{
    public class WorkReadModel : IReadModel, IAmReadModelFor<WorkAggregate, WorkId, RenameEvent>
    {
        public string Name { get; private set; }

        public void Apply(
            IReadModelContext context,
            IDomainEvent<WorkAggregate, WorkId, RenameEvent> domainEvent)
        {
            Name = domainEvent.AggregateEvent.Name;
        }
    }
}