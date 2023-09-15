using Microsoft.EntityFrameworkCore;
using System;
using Pattern.Models;

namespace Pattern.DataSource
{
    public class ChordataContext:DbContext
    {
        public ChordataContext() {   }

        public DbSet<IChordata> Chordata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=chordata; Trusted_Connection=True;",
               providerOptions => { providerOptions.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Имя таблицы в БД
            modelBuilder.Entity<IChordata>()
                .ToTable("chordata");

            //Имена столбцов в БД и максимальная длина
            modelBuilder.Entity<IChordata>(bd =>
            {
                bd.Property(i => i.ID).HasColumnName("id_chordata");
                bd.Property(i => i.NameClass).HasColumnName("name_classes").HasMaxLength(50);
                bd.Property(i => i.LivingEnvironment).HasColumnName("living_environment").HasMaxLength(50);
                bd.Property(i => i.Size).HasColumnName("size").HasMaxLength(20);
                bd.Property(i => i.Detachment).HasColumnName("detachment").HasMaxLength(50);
            });
        }
    }
}
