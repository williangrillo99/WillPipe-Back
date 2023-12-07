using AutoMapper;
using SistemaEscola.Aplicacao.Colunas.Servicos.Interface;
using SistemaEscola.DataTransfer.Baords;
using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Colunas.Consultas;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Colunas.Servicos
{
    public class ColunaAppServico : IColunaAppServico
    {
        private readonly IRepositorioGenerico<Coluna> repositorioGenerico;
        private readonly IRepositorioGenerico<Board> repositorioBoardGenerico;
        private readonly IMapper mapper;

        public ColunaAppServico(IRepositorioGenerico<Coluna> repositorioGenerico, IRepositorioGenerico<Board> repositorioBoardGenerico, IMapper mapper)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.repositorioBoardGenerico = repositorioBoardGenerico;
            this.mapper = mapper;
        }

        public async Task<Coluna> Adicionar(AdicionarColunasRequest request)
        {

            var board = await repositorioBoardGenerico.RecuperarPorIdAsync(request.IdBoard, x => x.Colunas);

            var ultimoid = board.Colunas.LastOrDefault();

            if (board == null)
            {
                throw new NotImplementedException();

            }

            Coluna coluna = new Coluna();
            
            coluna.Nome = string.Concat("Nova coluna #" + (ultimoid?.Id + 1).ToString());
            coluna.Board = board;

            coluna = await repositorioGenerico.AdicionarAsync(coluna);

            await repositorioGenerico.SalvarAsync();

            return coluna;
        }

        public async Task<ColunaListagem> Listar(int idBoard)
        {
            ColunaListagem colunas = await repositorioGenerico.RecuperarColunasIdBoard(idBoard);

            return colunas;
        }
        public async Task<ColunasResponse> AtualizarTitulo(int id, ColunaTituloRequest titulo)
        {

            Coluna coluna = await repositorioGenerico.RecuperarPorIdAsync(id) ?? throw (new Exception("Coluna nao existe"));
            coluna.Nome = titulo.Titulo;

            repositorioGenerico.AtualizarAsync(coluna);

            await repositorioGenerico.SalvarAsync();

            var response = mapper.Map<ColunasResponse>(coluna);

            return response;
        }
        public async Task<Coluna> Recuperar(int id)
        {
            var coluna = await repositorioGenerico.RecuperarPorIdAsync(id, x => x.Cartoes, x => x.Board);

            return coluna == null ? throw new NotImplementedException() : coluna;
        }

        public async Task  DeletarColuna(int id)
        {
            var coluna = await repositorioGenerico.RecuperarPorIdAsync(id);

            repositorioGenerico.DeletarAsync(coluna);
            await repositorioGenerico.SalvarAsync();

        }
    }
}
