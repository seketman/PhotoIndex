using AutoMapper;
using PhotoIndex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoIndex.API.ViewModels;

namespace PhotoIndex.API.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ResourceViewModel, Resource>()
                .ForMember(resource => resource.Activities, vm => vm.Ignore())
                .ForMember(resource => resource.UserId, vm => vm.Ignore());

            Mapper.CreateMap<LocationViewModel, Location>();
            Mapper.CreateMap<ResourceActivityViewModel, ResourceActivity>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>().ForMember(user => user.UserName, vm => vm.MapFrom(rm => rm.Email));
        }
    }
}