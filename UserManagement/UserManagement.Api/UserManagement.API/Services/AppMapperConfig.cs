using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtityModel=UserManagement.Infrastructure.Entities;
using DomainModel=UserManagement.Domain.Models;

namespace UserManagement.API.Services
{
    public class AppMapperConfig : Profile
    {
        public AppMapperConfig()
        {
            CreateMap<DomainModel.User,EtityModel.User>().ReverseMap();
        }
    }
}
