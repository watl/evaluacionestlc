using AutoMapper;
using EvalCore.Models;
using EvalCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Mappings
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Funcionarios, FuncViewDto>();
        //.ForMember(dest =>
        //    dest.Keyfun,
        //    opt => opt.MapFrom(src => src.FunId))
        //.ForMember(dest =>
        //    dest.FName,
        //    opt => opt.MapFrom(src => src.FunNombre))
        //.ForMember(dest =>
        //    dest.LName,
        //    opt => opt.MapFrom(src => src.FunApellidos));

        }
    }
}
