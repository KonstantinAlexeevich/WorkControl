using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkControl.Storage.Abstractions;

namespace WorkControl.Storage.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.DocumentWorks)
                .WithOne(x => x.Work)
                .HasForeignKey(x => x.WorkId);
        }
    }
}