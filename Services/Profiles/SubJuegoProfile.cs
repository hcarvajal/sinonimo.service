using System;
using AutoMapper;
using Domain.Entities;
using Models.DTOSubJuego;
namespace Services.Profiles
{
    public class SubJuegoProfile : Profile
    {
        public SubJuegoProfile() 
        {
            CreateMap<SubJuego,SubJuegoDTO>();
            CreateMap<SubJuegoForCreateDTO, SubJuego>();
            CreateMap<SubJuegoForUpdateDTO, SubJuego>();
            CreateMap<SubJuego,SubJuegoForUpdateDTO>();
        }
    }
}
