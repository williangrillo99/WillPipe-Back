using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Baords.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;

namespace SistemaEscola.Dominio.Baords.Servicos
{
    public class BoardServico : IBoardServico
    {
        private readonly IRepositorioGenerico<Board> repositorioGenerico;

        public BoardServico(IRepositorioGenerico<Board> repositorioGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
        }
        public async Task<Board> Recupear(int id)
        {
            Board board = await repositorioGenerico.RecuperarPorIdAsync(id);

            if (board == null)
            {
                throw new Exception("Board não existe");
            }
            return board;
        }
    }
}
