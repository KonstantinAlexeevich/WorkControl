using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkControl.Storage.Abstractions;

namespace WorkControl.Storage.Configurations
{
    public class DocumentWorkConfiguration : IEntityTypeConfiguration<DocumentWork>
    {
        public void Configure(EntityTypeBuilder<DocumentWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new {x.DocumentId, x.WorkId});
        }
    }
}