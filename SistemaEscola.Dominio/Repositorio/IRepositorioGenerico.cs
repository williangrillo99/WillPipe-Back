using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Colunas.Consultas;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System.Linq.Expressions;

namespace SistemaEscola.Dominio.Repositorio.Interface
{
    public interface IRepositorioGenerico<T> where T : BaseEntity
    {
        Task<T> AdicionarAsync(T entity);
        void AtualizarAsync(T entity);
        void DeletarAsync(T entity);
        Task<List<Cartao>> RecuperarCartaoesPorIdBoard(int idBoard);
        //Task<List<T>> FiltrarAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes);
        Task<List<T>> RecuperarAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes);
        Task<T?> RecuperarPorIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task SalvarAsync();
        Usuario Logar(string email, string senha);
        Task<List<Usuario>> ListarPorDominio(string dominio);
        Task<List<Cartao>> RecuperarCartaoPorIColuna(int idColuna);
        Task<ColunaListagem> RecuperarColunasIdBoard(int idBoard);
        Task<Coluna> RecuperarColunaPorNome(string nome, int idBoard);
        //Task<List<Cartao>> RecuperarListaCartaoPorIds(List<int> ids)
    }
}