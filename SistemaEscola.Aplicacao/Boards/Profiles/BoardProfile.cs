using AutoMapper;
using SistemaEscola.DataTransfer.Boards.Response;
using SistemaEscola.Dominio.Baords.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Boards.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile() 
        { 
            CreateMap<Board, BoardResponse>();
        }
    }
}
