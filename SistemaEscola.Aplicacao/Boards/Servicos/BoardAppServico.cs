using AutoMapper;
using SistemaEscola.Aplicacao.Boards.Servicos.Interface;
using SistemaEscola.DataTransfer.Baords;
using SistemaEscola.DataTransfer.Boards.Response;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Baords.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;

namespace SistemaEscola.Aplicacao.Boards.Servicos
{
    public class BoardAppServico : IBoardAppServico

    {
        private IMapper mapper { get; }

        private readonly IRepositorioGenerico<Board> repositorioGenerico;
        public BoardAppServico(IRepositorioGenerico<Board> repositorioGenerico, IMapper mapper)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.mapper = mapper;
        }

        public async Task<List<Board>> Adicionar(BaordRequest request)
        {
            Board board = new Board();  
            board.Descricao = request.Descricao;
            board.Nome = request.Nome;

            board  = await  repositorioGenerico.AdicionarAsync(board);
            await repositorioGenerico.SalvarAsync();


            var boards = await repositorioGenerico.RecuperarAsync(null, null);

            return boards;
        }
        public async Task<List<Board>> Listar()
        {
            List<Board> lista = await repositorioGenerico.RecuperarAsync(null, null, x => x.Colunas);

            mapper.Map<List<Board>>(lista);

            return lista;

        }
        public async Task<Board> Recuperar(int id)
        { 
            Board board = await repositorioGenerico.RecuperarPorIdAsync(id,x => x.Colunas) ?? throw(new Exception("d"));

            return board;
        }


        public async Task<List<BoardResponse>> RecuperarPorNome()
        {
            var board = await repositorioGenerico.RecuperarAsync(null, null);

            return mapper.Map<List<BoardResponse>>(board);
        }

        public async Task<List<Board>> Editar(int id, BaordRequest request)
        {
            Board board = await repositorioGenerico.RecuperarPorIdAsync(id);

            if (board != null)
            {
                board.Nome = request.Nome;
                board.Descricao = request.Descricao;
                repositorioGenerico.AtualizarAsync(board);
                await repositorioGenerico.SalvarAsync();
            }
            else
            {
                throw new Exception("Board nao encontrado");
            }

            var boards = await repositorioGenerico.RecuperarAsync(null, null);

            return boards.ToList();
        }

        public async Task  Deletar(int id)
        {
            Board board = await repositorioGenerico.RecuperarPorIdAsync(id);

            repositorioGenerico.DeletarAsync(board);

            await repositorioGenerico.SalvarAsync();
        
        }
    }
}
