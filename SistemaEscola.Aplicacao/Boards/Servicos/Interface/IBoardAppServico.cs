using SistemaEscola.DataTransfer.Baords;
using SistemaEscola.DataTransfer.Boards.Response;
using SistemaEscola.Dominio.Baords.Entidade;

namespace SistemaEscola.Aplicacao.Boards.Servicos.Interface
{
    public interface IBoardAppServico
    {
        Task<List<Board>> Adicionar(BaordRequest request);

        Task<List<Board>> Listar();

        Task<Board> Recuperar(int id);
        Task<List<Board>> Editar(int id, BaordRequest request);
        Task<List<BoardResponse>> RecuperarPorNome();
        Task Deletar(int id);
    }
}
