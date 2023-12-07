using AutoMapper;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.DataTransfer.Usuarios.Request;
using SistemaEscola.DataTransfer.Usuarios.Response;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Colunas.Profiles
{
    public class ColunaProfile : Profile
    {
        public ColunaProfile()
        {
            CreateMap<Coluna, ColunasResponse>();
        }
    }
}
