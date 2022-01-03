using Browl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Infrastructure.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> city)
        {

            city.ToTable("city");

            city.HasKey(x => x.Id);


            city.Property(x => x.Id)
                 .HasColumnName("cityid");

            city.Property(x => x.NameCity)
                .HasColumnType("varchar(100)")
                .IsRequired();

            city.Property(x => x.IbgeCodeCity)
                .HasColumnType("varchar(14)");


            city.Property(x => x.IntrraCodeCity)
                .HasColumnType("varchar(50)");


            city.Property(x => x.ActiveCity)
               //.HasColumnType("bit");
               .HasColumnType("bool");


            city.HasMany(p => p.Terminals).WithOne(p => p.City);

            city.HasQueryFilter(p => !p.IsDeleted);

        }


    }
}
