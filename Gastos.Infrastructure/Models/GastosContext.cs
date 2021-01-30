using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class GastosContext : IdentityDbContext<Usuarios>
    {
        public GastosContext()
        {
        }

        public GastosContext(DbContextOptions<GastosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Detalhes> Detalhes { get; set; }
        public virtual DbSet<Movimentacoes> Movimentacoes { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TipoMovimentacoes> TipoMovimentacoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VM055QS;Database=Gastos;User Id=Gastos; Password=Gastos;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.UseIdentityColumns();

            //modelBuilder.Entity<Usuarios>(entity =>
            //{
            //    entity.ToTable("Usuarios");

            //    entity.HasKey(e => e.UsuarioId);
            //    entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId").ValueGeneratedOnAdd();
            //    entity.Property(e => e.Email).IsRequired().HasMaxLength(100);

            //    entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);

            //    entity.Property(e => e.Senha).IsRequired();
            //});

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("Tags");

                entity.HasKey(e => e.TagId);
                entity.Property(e => e.TagId).HasColumnName("TagId").ValueGeneratedOnAdd();
                entity.Property(e => e.Tag).HasColumnName("Tag").IsRequired().HasMaxLength(50);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity
                .HasMany(e => e.Detalhes)
                .WithMany(e => e.Tags)
                .UsingEntity(j => j.ToTable("DetalhesTags"));
                entity.HasMany(e => e.Movimentacoes).WithMany(e => e.Tags).UsingEntity(f => f.ToTable("MovimentacoesTags"));
            });

            modelBuilder.Entity<TipoMovimentacoes>(entity =>
            {
                entity.ToTable("TipoMovimentacoes");
                entity.HasKey(e => e.TipoMovimentacaoId);
                entity.Property(e => e.TipoMovimentacaoId).HasColumnName("TipoMovimentacaoId").ValueGeneratedOnAdd();

                entity.Property(e => e.Tipo).HasMaxLength(20).HasColumnName("Tipo");
            });

            modelBuilder.Entity<Movimentacoes>(entity =>
            {
                entity.ToTable("Movimentacoes");
                entity.HasKey(e => e.MovimentacaoId);
                entity.Property(e => e.MovimentacaoId).HasColumnName("MovimentacaoId").ValueGeneratedOnAdd();
                entity.Property(e => e.Data).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Nome).HasColumnName("Nome").HasMaxLength(100);
                entity.Property(e => e.Valor).HasColumnName("Valor").HasColumnType("money");
                entity.HasOne(d => d.TipoMovimentacao)
                    .WithMany()
                    .HasForeignKey(d => d.TipoMovimentacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Movimentacoes)
                    .HasForeignKey(d => d.UsuarioId);

                entity.HasMany(e => e.Detalhes).WithOne(f => f.Movimentacao).HasForeignKey(e => e.DetalheId);
            });

            modelBuilder.Entity<Detalhes>(entity =>
            {
                entity.ToTable("Detalhes");
                entity.HasKey(e => e.DetalheId);
                entity.Property(e => e.DetalheId).HasColumnName("DetalheId").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.Movimentacao)
                    .WithMany(p => p.Detalhes)
                    .HasForeignKey(d => d.MovimentacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
