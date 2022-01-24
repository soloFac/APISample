using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APISample.Models
{
    public partial class desarrolladoresdbContext : DbContext
    {
        public desarrolladoresdbContext()
        {
        }

        public desarrolladoresdbContext(DbContextOptions<desarrolladoresdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desarrolladores> Desarrolladores { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<Tecnologias> Tecnologias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B0D07J7\\SQLEXPRESS;Database=desarrolladoresdb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desarrolladores>(entity =>
            {
                entity.HasKey(e => e.IdDesarrollador);

                entity.ToTable("desarrolladores");

                entity.Property(e => e.IdDesarrollador).HasColumnName("id_desarrollador");

                entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");

                entity.Property(e => e.IdTecnologia).HasColumnName("id_tecnologia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("profesion")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Desarrolladores)
                    .HasForeignKey(d => d.IdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_desarrolladores_puestos");

                entity.HasOne(d => d.IdTecnologiaNavigation)
                    .WithMany(p => p.Desarrolladores)
                    .HasForeignKey(d => d.IdTecnologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_desarrolladores_tecnologias");
            });

            modelBuilder.Entity<Puestos>(entity =>
            {
                entity.HasKey(e => e.IdPuesto);

                entity.ToTable("puestos");

                entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("puesto")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tecnologias>(entity =>
            {
                entity.HasKey(e => e.IdTecnologia);

                entity.ToTable("tecnologias");

                entity.Property(e => e.IdTecnologia).HasColumnName("id_tecnologia");

                entity.Property(e => e.Tecnologia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("tecnologia")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
