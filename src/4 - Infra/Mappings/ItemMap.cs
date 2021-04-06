using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

          builder.HasKey(x => x.Id);

           builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnType("BIGINT");
                
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.Link)
                .HasColumnName("Link")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.PhotoUrl)
                .HasColumnName("Foto")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.WonOrBought)
                .HasColumnName("Ganhou/Comprou")
                .HasColumnType("TINYINT(1)");
            


        }
    }
}