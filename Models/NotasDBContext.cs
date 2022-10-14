using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NOTASDEESTUDIANTE.Models
{
    public partial class NotasDBContext : DbContext
    {
        public NotasDBContext()
        {
        }

        public NotasDBContext(DbContextOptions<NotasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NotasEstudiante> NotasEstudiantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JASONMENAPC; Database=NotasDB; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotasEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdnotasEstudiantes)
                    .HasName("PK__NotasEst__2F1508682B5B0D39");

                entity.Property(e => e.IdnotasEstudiantes).HasColumnName("IDNotasEstudiantes");

                entity.Property(e => e.Apellido).HasMaxLength(30);

                entity.Property(e => e.Carnet).HasMaxLength(12);

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.Property(e => e.NotaIip).HasColumnName("NotaIIP");

                entity.Property(e => e.NotaIp).HasColumnName("NotaIP");

                entity.Property(e => e.NotaProy).HasColumnName("NotaPROY");

                entity.Property(e => e.NotaSist).HasColumnName("NotaSIST");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
