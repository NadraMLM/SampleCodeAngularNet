using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSample.Models;

namespace CodeSample.ViewModels.Mapping
{
    public class ViewModelToModelMappingProfile: Profile
    {
		public ViewModelToModelMappingProfile()
		{
			CreateMap<ClientViewModel, IdentityUser>()
				.ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
			CreateMap<ClientViewModel, Client>()
				.ForMember(m => m.Identity, opt => opt.MapFrom(vm => Mapper.Map<ClientViewModel, IdentityUser>(vm)));
			CreateMap<SaveClientViewModel, IdentityUser>()
				.ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
			CreateMap<SaveClientViewModel, Client>()
				.ForMember(m => m.Identity, opt => opt.MapFrom(vm => Mapper.Map<SaveClientViewModel, IdentityUser>(vm)));
		}
	}
}
