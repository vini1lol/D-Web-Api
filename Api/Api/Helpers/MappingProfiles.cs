using Api.Dto;
using Api.Models;
using AutoMapper;
using System.Net;

namespace Api.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Compra, CompraDto>(MemberList.None)
                .ForSourceMember(x => x.Produtos, opt => opt.DoNotValidate());
            CreateMap<Produto, ProdutoDto>(MemberList.None)
                .ForSourceMember(x=> x.Compras, opt=> opt.DoNotValidate());
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<User, UserDto>();
        }
    }
}
