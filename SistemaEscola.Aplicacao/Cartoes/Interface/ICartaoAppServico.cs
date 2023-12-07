using SistemaEscola.DataTransfer.Cartoes;
using SistemaEscola.DataTransfer.Cartoes.Response;
using SistemaEscola.Dominio.Cartoes.Entidade;

namespace SistemaEscola.Aplicacao.Cartoes.Interface
{
    public interface ICartaoAppServico
    {

        Task<Cartao> Adicionar(int idColuna);

        Task<List<Cartao>> Lista(int IdColuna);
        Task<Cartao> RecuperarPorId(int id);
        Task<CartaoResponse> Atualizar(CartaoMoverRequest request);
        Task<List<Cartao>> ListarTodos(int Idboard);
        Task<CartaoResponse> Editar(int Idboard, CartoesRequest request);

    }
}
