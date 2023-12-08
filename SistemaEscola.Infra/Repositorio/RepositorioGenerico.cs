using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Colunas.Consultas;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System.Linq.Expressions;

namespace SistemaEscola.Infra.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : BaseEntity
    {
        private AppDbContext appDbContext { get; }
        private DbSet<T> DbSet { get; }
   
        public RepositorioGenerico(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            DbSet = appDbContext.Set<T>();
        }

        public Usuario Logar(string email, string senha)
        {

            IQueryable<Usuario> query = appDbContext.Usuarios.AsQueryable();

            var usuario = query.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            return usuario;
        }

        public async Task<ColunaListagem> RecuperarColunasIdBoard(int idBoard)
        {
            IQueryable<Coluna> query =  appDbContext.Colunas.AsQueryable();

            IQueryable<Cartao> cartaos = appDbContext.Cartaos.AsQueryable();

            IQueryable<Board> boardQuery = appDbContext.Baords.AsQueryable();


            var listaCartoes = new List<ColunaCartoesConsulta>();

            var colunas = query.Where(x => x.Board.Id == idBoard).ToList();

            var board = boardQuery.Where(x => x.Id == idBoard).FirstOrDefault();
            

            foreach(var coluna in colunas)
            {
                var cartao = cartaos.Where(x => x.Coluna.Id == coluna.Id).OrderBy(x => x.Index).ToList();

                
                var lista = new ColunaCartoesConsulta()
                {
                    IdColuna = coluna.Id,
                    NomeColuna = coluna.Nome,
                    Cartoes = cartao,
                 
                };
                listaCartoes.Add(lista);
            }

            var colunasListagem = new ColunaListagem()
            {
                IdBoard = board.Id,
                Coluna = listaCartoes,
                NomeBoard = board.Nome,
            };

            return colunasListagem;

        }

        public async Task<List<Cartao>> RecuperarCartaoesPorIdBoard(int idBoard)
        {
            IQueryable<Coluna> query = appDbContext.Colunas.AsQueryable();

            var colunas = query.Where(x => x.Board.Id == idBoard).Select(x => x.Id);
      
      
            IQueryable<Cartao> cartao = appDbContext.Cartaos.AsQueryable();

            var teste  = cartao.Where(x => colunas.Any(y => y == x.Coluna.Id)).Include(x => x.Coluna).ToList();
            return teste;
        }


        public async Task<Coluna> RecuperarColunaPorNome(string nome, int idBoard)
        {
            var query = appDbContext.Colunas.Where(x => x.Nome == nome && x.Board.Id == idBoard).Include(x => x.Cartoes).FirstOrDefault();

            return query;
        }


        public async Task<T> AdicionarAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public void AtualizarAsync(T entity)
        {
            DbSet.Attach(entity);
            appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeletarAsync(T entity)
        {
            if (appDbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            DbSet.Remove(entity);

        }
        //public async Task<List<T>> FiltrarAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = DbSet;

        //    foreach(var filter in filters) 
        //        query = query.Where(filter);
        //    foreach(var include in includes)
        //        query = query.Include(include);

        //    if (skip != null)
        //        query = query.Skip(skip.Value);

        //    if(take != null)
        //        query = query.Take(take.Value);

        //    return await query.ToListAsync();
        //}

        public async Task<List<T>> RecuperarAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var include in includes)
                query = query.Include(include);

            if (skip != null)
                query = query.Skip(skip.Value);
            if (take != null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public Task<T?> RecuperarPorIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            query = query.Where(x => x.Id == id);

            foreach (var include in includes)
                query = query.Include(include);

            return query.SingleOrDefaultAsync();
        }

        public async Task SalvarAsync()
        {
            await appDbContext.SaveChangesAsync();
        }

        public Task<List<Usuario>> ListarPorDominio(string dominio)
        {
            IQueryable<Usuario> query = appDbContext.Usuarios.AsQueryable();

            var listaUsuario = query.Where(x => x.Dominio == dominio).ToListAsync();

            return listaUsuario;
        }

        public Task<List<Cartao>> RecuperarCartaoPorIColuna(int idColuna)
        {
            var query = appDbContext.Cartaos.Where(x => x.Coluna.Id == idColuna).ToListAsync();

            return query;
        }

        //public Task<List<Cartao>> RecuperarListaCartaoPorIds(List<int> ids)
        //{
        //    var query = appDbContext.Cartaos.
        //}
    }
}
