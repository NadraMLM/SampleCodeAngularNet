using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSample.ViewModels.Mapping
{
    public class AutoMapperConfiguration
    {
			public static void Configure()
			{
				Mapper.Initialize(x =>
				{
					x.AddProfile<ViewModelToModelMappingProfile>();
					x.AddProfile<ModelToViewModelMappingProfile>();
				});
			}
	}
}
