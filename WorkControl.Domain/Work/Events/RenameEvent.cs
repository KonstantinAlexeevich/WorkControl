using EventFlow.Aggregates;

namespace WorkControl.Domain.Work.Events
{
    public class RenameEvent : AggregateEvent<WorkAggregate, WorkId>
    {
        public RenameEvent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}