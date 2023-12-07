using AutoMapper;
using SistemaEscola.DataTransfer.Cartoes.Response;
using SistemaEscola.DataTransfer.Usuarios.Request;
using SistemaEscola.DataTransfer.Usuarios.Response;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;


namespace SistemaEscola.Aplicacao.Cartoes.Profiles
{
    public class CartaoProfile : Profile
    {
        public CartaoProfile()
        {
            CreateMap<Cartao, CartaoResponse>();
            CreateMap<Cartao, CartaoResponse>();
        }

    }
}
