using AdministradorTareasHeinerUrenaZunigaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;

namespace AdministradorTareasHeinerUrenaZunigaAPI.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Colaborador)
                .WithMany()
                .HasForeignKey(t => t.ColaboradorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Colaborador>()
                .HasKey(c => c.Id);
        }

    }
}
