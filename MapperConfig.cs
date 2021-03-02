using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreApi.Models;

namespace DotnetCoreApi
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<TableHead, CementConcrete>();
            CreateMap<TableHead, RebarSetting>();
        }

    }
}
