using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Comentarios.Entidade;
using SistemaEscola.Dominio.Tarefas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Board> Baords { get; set; }
        public DbSet<Coluna> Colunas { get; set; }
        public DbSet<Cartao> Cartaos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost, 1433; Database = SistemaEscola99dddds01m; User ID = sa; Password = 1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;", b => b.MigrationsAssembly("SistemaEscola.Infra"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}