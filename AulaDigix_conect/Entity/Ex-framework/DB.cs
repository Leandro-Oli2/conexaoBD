using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Ex_framework
{
    public class DB: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;database=conexaoBD;Username=postgres;password=Oliveira@87185");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Usuario>().ToTable("usuario");
        }
    }
}