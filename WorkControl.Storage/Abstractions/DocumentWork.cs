namespace WorkControl.Storage.Abstractions
{
    public class DocumentWork
    {
        public long Id { get; set; }
        public long DocumentId { get; set; }
        public long WorkId { get; set; }
        public Document Document { get; set; }
        public Work Work { get; set; }
    }
}