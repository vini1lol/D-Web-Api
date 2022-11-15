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
            CreateMap<Compra, CompraDto>();
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<User, UserDto>();
        }
    }
}
