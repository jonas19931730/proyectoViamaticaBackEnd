using Microsoft.EntityFrameworkCore;
using ProyectoViamatica.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.DBContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options ):base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Sector> Sectores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.IdZona).HasColumnName("IdZona");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FechaNacimiento")
                    .HasMaxLength(20)
                        .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sueldo).HasColumnName("Sueldo");

                entity.HasOne(d => d.IdZonaNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(e => e.IdZona)
                    .HasConstraintName("FK__persona__IdZona__29572725");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.IdSector);

                entity.ToTable("sector");

                entity.Property(e => e.IdSector).HasColumnName("Id");

                entity.Property(e => e.DescripcionSector)
                    .HasColumnName("Descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.HasKey(e => e.IdZona);

                entity.ToTable("zona");

                entity.Property(e => e.IdZona).HasColumnName("Id");

                entity.Property(e => e.IdSector).HasColumnName("IdSector");

                entity.Property(e => e.DescripcionZona)
                    .HasColumnName("Descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK__zona__IdSector__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);


        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
           
        }
    }
}
