using AutoMapper;
using SistemaEscola.Aplicacao.Cartoes.Interface;
using SistemaEscola.DataTransfer.Cartoes;
using SistemaEscola.DataTransfer.Cartoes.Response;
using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;



namespace SistemaEscola.Aplicacao.Cartoes
{
    public class CartaoAppServico : ICartaoAppServico
    {
        private readonly IRepositorioGenerico<Cartao> repositorioGenerico;
        private readonly IRepositorioGenerico<Coluna> repositoriColunaGenerico;
        private readonly IRepositorioGenerico<Board> repositoriBoardGenerico;

        private IMapper mapper { get; }


        public CartaoAppServico(IRepositorioGenerico<Cartao> repositorioGenerico, IRepositorioGenerico<Coluna> repositoriColunaGenerico, IMapper mapper, IRepositorioGenerico<Board> repositoriBoardGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.repositoriColunaGenerico = repositoriColunaGenerico;
            this.mapper = mapper;
            this.repositoriBoardGenerico = repositoriBoardGenerico;
        }
        public async Task<Cartao> Adicionar(int idColuna)
        {
            Coluna coluna = await repositoriColunaGenerico.RecuperarPorIdAsync(idColuna) ?? throw (new Exception("Coluna nao existe"));

            Cartao cartao = new Cartao();
            cartao.Titulo = "Novo cartão";
            cartao.Descricao = null;
            cartao.Coluna = coluna;
            cartao.DataInicio = DateTime.Now;
            cartao.DataFim = null;

            cartao = await repositorioGenerico.AdicionarAsync(cartao);

            coluna.Cartoes.Add(cartao);
            repositoriColunaGenerico.AtualizarAsync(coluna);

            await repositorioGenerico.SalvarAsync();

            return cartao;
        }
   

        public async Task<List<Cartao>> Lista(int idColuna)
        {
            List<Cartao> coluna = await repositoriColunaGenerico.RecuperarCartaoPorIColuna(idColuna);

            return coluna;
        }

        public async Task<List<Cartao>> ListarTodos(int Idboard)
        {
            if (Idboard == null)
            {
                throw new Exception("Cartao nao existe");
            }

            var cartaos = await repositoriColunaGenerico.RecuperarCartaoesPorIdBoard(Idboard);

            return cartaos;

        }

        public async Task<Cartao> RecuperarPorId(int id)
        {
            var cartao = await repositorioGenerico.RecuperarPorIdAsync(id, x => x.UsuarioResponsavel, x => x.Tarefas, x => x.Comentarios);


            if (cartao == null)
            {
                throw new Exception("Cartao nao existe");
            }
            return cartao;
        }

        public async Task<CartaoResponse> Atualizar(CartaoMoverRequest request)
        {

            var colunaAntiga = await repositoriColunaGenerico.RecuperarColunaPorNome(request.NomeConlunaAnterior, request.IdBoard);

            var colunaIndex = await repositoriColunaGenerico.RecuperarColunaPorNome(request.NomeColunaIndex, request.IdBoard);

            var idsCartaoesIdex = colunaIndex.Cartoes.Select(car => car.Id).ToList();
            var idsCartaoesAntiga = colunaAntiga.Cartoes.Select(car => car.Id).ToList();

            if (request.colunaAntiga.Count == 0)
            {

                colunaAntiga.Cartoes.Clear();
                repositoriColunaGenerico.AtualizarAsync(colunaAntiga);

                colunaIndex.Cartoes.Clear();
                int indexFor = 0;
                foreach (var cartao in request.colunaAtual)
                {
                    indexFor++;
                    var cartaoAntigo = await repositorioGenerico.RecuperarPorIdAsync(cartao.Id);
                    cartaoAntigo.Index = indexFor;
                    colunaIndex.Cartoes.Add(cartaoAntigo);
                }
                repositoriColunaGenerico.AtualizarAsync(colunaIndex);

                await repositorioGenerico.SalvarAsync();
            }
            else
            {
                var idsCartoesAntigos = request.colunaAntiga.Where(x => x.Coluna.Id != colunaIndex.Id).ToList();

                var cartoesAtualRequest = request.colunaAtual.Where(x => idsCartoesAntigos.Any(y => y.Titulo != x.Titulo)).Select(x => x.Id).ToList();


                colunaIndex.Cartoes.Clear();
                colunaAntiga.Cartoes.Clear();
                int index = 0;

                foreach (var cartoesAntigos in idsCartoesAntigos)
                {
                    index++;
                    var cartaoAntigo = await repositorioGenerico.RecuperarPorIdAsync(cartoesAntigos.Id);
                    if (cartaoAntigo != null)
                    {
                        cartaoAntigo.Index = index;
                        colunaAntiga.Cartoes.Add(cartaoAntigo);
                    }
                }
                repositoriColunaGenerico.AtualizarAsync(colunaAntiga);
                index = 0;
                foreach (var cartoesIndex in cartoesAtualRequest)
                {
                    index++;

                    var cartaoAntigo = await repositorioGenerico.RecuperarPorIdAsync(cartoesIndex);
                    if (cartaoAntigo != null)
                    {
                        cartaoAntigo.Index = index;
                        colunaIndex.Cartoes.Add(cartaoAntigo);
                    }
                }

                repositoriColunaGenerico.AtualizarAsync(colunaIndex);

                await repositorioGenerico.SalvarAsync();
            }

            return null;


        }

        public async  Task<CartaoResponse>  Editar(int Idboard, CartoesRequest request)
        {
            var cartao = await repositorioGenerico.RecuperarPorIdAsync(Idboard);

            if (cartao != null)
            {
                cartao.Titulo = request.Titulo;
                cartao.DataInicio = request.DataInicio;
                cartao.Descricao = request.Descricao;
                cartao.DataFim = request.DataInicio;
                repositorioGenerico.AtualizarAsync(cartao);
            }

            await repositorioGenerico.SalvarAsync();
            return mapper.Map<CartaoResponse>(cartao);

        }
    }
}
