using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acervo.Infrastructure.Persistence.Configurations
{
    public sealed class LibraryItemConfiguration : IEntityTypeConfiguration<LibraryItem>
    {
        public void Configure(EntityTypeBuilder<LibraryItem> builder)
        {
            builder.ToTable("LibraryItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LibraryId)
                .IsRequired();

            builder.Property(x => x.BookId)
                .IsRequired();

            builder.Property(x => x.AcquiredAt)
                .IsRequired();

            builder.Property(x => x.ReadingProgress)
                .IsRequired();

            builder.HasOne(x => x.Library)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.LibraryId);

            builder.HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x => x.BookId);
        }
    }
}