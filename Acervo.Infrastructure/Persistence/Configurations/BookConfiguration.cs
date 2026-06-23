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

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.PagesNumber)
                .IsRequired();

            builder.Property(p => p.CoverImageUrl)
                .HasMaxLength(500);

            builder.Property(p => p.Release)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Publisher)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.PublisherId);
        }
    }
}
