using Browl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Infrastructure.Mapping
{
    public class TerminalMap : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> Terminal)
        {

            Terminal.ToTable("terminal");

            Terminal.HasKey(x => x.Id);


            Terminal.Property(x => x.Id)
                 .HasColumnName("terminalid");

            Terminal.Property(x => x.NameTerminal)
                .HasColumnType("varchar(100)")
                .IsRequired();

            Terminal.Property(x => x.CNPJ)
                .HasColumnType("varchar(14)");


            Terminal.Property(x => x.StateRegistry)
                .HasColumnType("varchar(50)");


            Terminal.Property(x => x.NIF)
                .HasColumnType("varchar(50)");


            Terminal.Property(x => x.SpecificInstruction)
                .HasColumnType("varchar(100)")
                .IsRequired();

            Terminal.Property(x => x.GeneralObservation)
                .HasColumnType("varchar(100)")
                .IsRequired();


            Terminal.Property(x => x.Status)
                .HasColumnType("varchar(1)");

            Terminal.Property(x => x.Address)
                .HasColumnType("varchar(100)");

            Terminal.Property(x => x.District)
                .HasColumnType("varchar(50)");

            Terminal.HasOne(x => x.City)
                    .WithMany()
                    .HasForeignKey(p => p.Id);

            Terminal.HasOne(x => x.City)
                   .WithMany(x => x.Terminals).HasForeignKey(x => x.CityId);

            Terminal.HasQueryFilter(p => !p.IsDeleted);

        }


    }
}
