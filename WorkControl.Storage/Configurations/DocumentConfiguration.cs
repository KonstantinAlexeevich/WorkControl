using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkControl.Storage.Abstractions;

namespace WorkControl.Storage.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.DocumentWorks)
                .WithOne(x => x.Document)
                .HasForeignKey(x => x.DocumentId);

            builder.HasOne(x => x.CreateUser)
                .WithMany()
                .HasForeignKey(x => x.CreateUserId);
        }
    }
}