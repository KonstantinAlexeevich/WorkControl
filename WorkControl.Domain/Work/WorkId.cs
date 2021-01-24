using EventFlow.Core;

namespace WorkControl.Domain.Work
{
    public class WorkId : IIdentity
    {
        public WorkId(long value)
        {
            Value = value;
        }

        public long Value { get; }

        string IIdentity.Value => Value.ToString();
    }
}