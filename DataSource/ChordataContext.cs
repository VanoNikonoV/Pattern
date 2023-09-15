using Microsoft.EntityFrameworkCore;
using System;
using Pattern.Models;

namespace Pattern.DataSource
{
    public class ChordataContext:DbContext
    {
        public ChordataContext() {   }

        public DbSet<Chordata> Chordata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=chordata; Trusted_Connection=True;",
               providerOptions => { providerOptions.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birds>();
            modelBuilder.Entity<Amphibians>();
            modelBuilder.Entity<Mammals>();
            modelBuilder.Entity<NullChordata>();

            //Имя таблицы в БД
            modelBuilder.Entity<Chordata>()
                .ToTable("chordata");

            //Имена столбцов в БД и максимальная длина
            modelBuilder.Entity<Chordata>(bd =>
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
