using AutoMapper;
using Practical_17.Model;
using Practical_17.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_17.Configration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentViewVM>().ReverseMap();
        }
            
    }
}
