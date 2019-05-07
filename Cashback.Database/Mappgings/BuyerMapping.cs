using Cashback.Domain.Entities.BuyerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cashback.Database.Mappgings
{

    public class BuyerMapping : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}