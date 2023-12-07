using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.Dominio.Colunas.Consultas;
using SistemaEscola.Dominio.Colunas.Entidade;

namespace SistemaEscola.Aplicacao.Colunas.Servicos.Interface
{
    public interface IColunaAppServico
    {
        Task<ColunaListagem> Listar(int idBoard);
        Task<Coluna> Adicionar(AdicionarColunasRequest request);
        Task<Coluna> Recuperar(int id);
        Task<ColunasResponse> AtualizarTitulo(int id, ColunaTituloRequest titulo);
        Task DeletarColuna(int id);
    }
}
