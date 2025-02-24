﻿using AutoMapper;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Mapeo
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            /*Iniciar Sesion*/
            CreateMap<DatosUsuario, LoginDto>();
            CreateMap<LoginDto, DatosUsuario>();

            CreateMap<SesionDto, DatosUsuario>();
            CreateMap<DatosUsuario, SesionDto>();

            /*Usuarios por id*/
            CreateMap<DatosUsuario, IdUuarioDto>();
            CreateMap<IdUuarioDto, DatosUsuario>();

            /*Captura*/
            CreateMap<DatosCaptura, IdOrganismoDto>();
            CreateMap<IdOrganismoDto, DatosCaptura>();
        }

    }
}
