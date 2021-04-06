using ApiLearning.Dtos;
using ApiLearning.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLearning.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //sources -> target
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>(); //update

            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
