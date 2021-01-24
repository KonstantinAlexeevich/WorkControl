using System.Collections.Generic;

namespace WorkControl.Storage.Abstractions
{
    public class Work
    {
        public long Id { get; set; }
        public long Name { get; set; }
        public List<DocumentWork> DocumentWorks { get; set; } = new();
    }
}