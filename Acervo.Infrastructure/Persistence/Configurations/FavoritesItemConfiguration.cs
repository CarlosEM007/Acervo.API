using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class FavoritesItemConfiguration : IEntityTypeConfiguration<FavoritesItem>
{
    public void Configure(EntityTypeBuilder<FavoritesItem> builder)
    {
        builder.ToTable("FavoritesItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AddedAt)
            .IsRequired();

        builder.HasOne(x => x.Favorites)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.FavoritesId);

        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey(x => x.BookId);

        builder.HasIndex(x => new
        {
            x.FavoritesId,
            x.BookId
        }).IsUnique();
    }
}