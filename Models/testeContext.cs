using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDatabaseFirts.Models
{
    public partial class testeContext : DbContext
    {

        

        public testeContext()
        {
        }

        public testeContext(DbContextOptions<testeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cadastro> Cadastro { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-XVGT587\\SQLEXPRESS;Database=teste;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro>(entity =>
            {
                entity.HasKey(e => e.IdCadastro)
                    .HasName("PK__cadastro__C9557C685411C4DF");

                entity.Property(e => e.DataCadastro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__endereco__0B7C7F17F1C70208");

                entity.Property(e => e.Endereco1).IsUnicode(false);

                entity.HasOne(d => d.IdCadastroNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdCadastro)
                    .HasConstraintName("FK__endereco__IdCada__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
