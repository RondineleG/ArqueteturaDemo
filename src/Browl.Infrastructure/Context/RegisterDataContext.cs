using Browl.Domain.Models;
using Browl.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Browl.Infrastructure.Context
{
    public class RegisterDataContext : DbContext
    {

        public RegisterDataContext()
        {

        }
        public RegisterDataContext(DbContextOptions options) : base(options) { }


        public DbSet<City> Cities { get; set; }

        public DbSet<Terminal> Terminals { get; set; }

        public DbSet<AdminSetting> AdminSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegisterDataContext).Assembly);
            modelBuilder.ToLowerCaseName();
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=den1.mssql8.gear.host;Database=protondb;User Id=protondb; Password=Og4Fx_F?Qca9;");
            // optionsBuilder.UseNpgsql(@"Host=hansken.db.elephantsql.com;Database=tnpkxfez;Username=tnpkxfez;Password=BoJ9moLDO3E7hQctzyMFveqG6QQA2dt2");
            //optionsBuilder.UseNpgsql(@"Host=tuffi.db.elephantsql.com;Database=xbkrgeuq;Username=xbkrgeuq;Password=BbQy_7dYVgluoF11ZpzI9f1O-8WudHfw");

        }

    }
}