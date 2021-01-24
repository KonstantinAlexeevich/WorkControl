using System;
using System.Collections.Generic;
using System.Linq;
using EventFlow.Snapshots;

namespace WorkControl.Domain.Work
{
    [Serializable]
    [SnapshotVersion("Work", 1)]
    public class WorkSnaphost : ISnapshot
    {
        public WorkSnaphost(string name, IEnumerable<WorkSnapshotVersion> previousVersions)
        {
            Name = name;
            PreviousVersions = (previousVersions ?? Enumerable.Empty<WorkSnapshotVersion>()).ToList();
        }

        public string Name { get; set; }

        public IReadOnlyCollection<WorkSnapshotVersion> PreviousVersions { get; }
    }
}