using CeapBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CeapBackEnd.Context
{
    public class CeapDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public CeapDbContext(DbContextOptions<CeapDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nome).IsRequired().HasMaxLength(100).HasColumnName("nome");
                entity.Property(a => a.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
                entity.Property(a => a.Curso).IsRequired().HasMaxLength(50).HasColumnName("curso");
                entity.Property(a => a.DataNascimento).HasColumnName("data_nascimento");
                entity.Property(a => a.Ativo).IsRequired().HasColumnName("ativo");
            });
        }
    }
}
