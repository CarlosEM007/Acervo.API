using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acervo.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Author)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Release)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
