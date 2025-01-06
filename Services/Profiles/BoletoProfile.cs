using System;
using AutoMapper;
using Domain.Entities;
using Models.DTOBoleto;
using Models.DTOJuego;

namespace Services.Profiles
{
    public class BoletoProfile: Profile
    {
       public BoletoProfile() 
       {
            CreateMap<Boletos,BoletoDTO>();
            CreateMap<BoletoForCreateDTO, Boletos>();
            CreateMap<JuegoForUpdateDTO,Boletos>();
            CreateMap<Boletos,BoletoForUpdateDTO>();
       }
    }
}
