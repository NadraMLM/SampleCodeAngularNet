using AutoMapper;
using CodeSample.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSample.ViewModels.Mapping
{
    public class ModelToViewModelMappingProfile: Profile
    {
		public ModelToViewModelMappingProfile()
		{
			CreateMap<IdentityUser, ClientViewModel>()
					.ForMember(vm => vm.Email, map => map.MapFrom(m => m.UserName));
			CreateMap<Client, ClientViewModel>()
					.ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
					.ConstructUsing((src, ctx) => ctx.Mapper.Map<ClientViewModel>(src.Identity));
			CreateMap<IdentityUser, SaveClientViewModel>()
					.ForMember(vm => vm.Email, map => map.MapFrom(m => m.UserName));
			CreateMap<Client, SaveClientViewModel>()
					.ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
					.ConstructUsing((src, ctx) => ctx.Mapper.Map<SaveClientViewModel>(src.Identity));
		}
	}
}
