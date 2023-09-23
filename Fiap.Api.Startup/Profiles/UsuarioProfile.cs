﻿using AutoMapper;
using Fiap.Api.Startup.DTO.EnderecoDTO;
using Fiap.Api.Startup.DTO.UsuarioDTO;
using Fiap.Api.Startup.Models;

namespace Fiap.Api.Startup.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, OutCreateUserDto>();

        CreateMap<InCreateUserDto, Usuario>();

        CreateMap<InCreateUserDto, OutCreateUserDto>();

        CreateMap<Usuario, OutListUserDto>()
            .ForMember(dest => dest.Veiculo, opt => opt.MapFrom(src => src.Veiculos));

        CreateMap<Usuario, InUpdateUserDto>();
        CreateMap<InUpdateUserDto, Usuario>();

        CreateMap<InCreateEnderecoDto, Endereco>();
    }
}
