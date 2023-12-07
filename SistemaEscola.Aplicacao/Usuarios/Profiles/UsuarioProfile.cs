using AutoMapper;
using SistemaEscola.DataTransfer.Usuarios.Request;
using SistemaEscola.DataTransfer.Usuarios.Response;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Usuarios
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequest>();
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
