using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class PRUEBA_ANARContext : DbContext
    {
        public PRUEBA_ANARContext()
        {
        }

        public PRUEBA_ANARContext(DbContextOptions<PRUEBA_ANARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JAVB2807;Database=PRUEBA_ANAR;user=sa;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("PACIENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_POSTAL");

                entity.Property(e => e.Correo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_IDENTIFICACION");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_APELLIDO");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_NOMBRE");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_APELLIDO");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_NOMBRE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_IDENTIFICACION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
