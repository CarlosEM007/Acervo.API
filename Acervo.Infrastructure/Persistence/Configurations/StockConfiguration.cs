using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.HasOne(x => x.Seller)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.SellerId);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Stock)
            .HasForeignKey(x => x.StockId);
    }
}