using System;
using AutoMapper;
using Domain.Entities;
using Models.DTOJuego;

namespace Services.Profiles
{
    public class JuegoProfile : Profile
    {
       public JuegoProfile() 
        {
           CreateMap<Juegos,JuegoDTO>();
           CreateMap<JuegoForCreateDTO, Juegos>();
           CreateMap<JuegoForUpdateDTO,Juegos>();
           CreateMap<Juegos,JuegoForUpdateDTO>();

        }

    }
}
