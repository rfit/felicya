using AutoMapper;
using FelicyaDB.Entities;
using FelicyaShared.Models;

namespace FelicyaShared.Helpers
{
    public static class SharedMapper
    {
       public static IMapper Mapper { get; }

        static SharedMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(expression =>
            {
              expression.CreateMap<ProjectBaseModel, Project>()
                  .ForMember(s => s.ProjectName, s => s.MapFrom(p => p.ProjectName))
                  .ForMember(s => s.ProjectLeader, s => s.MapFrom(p => p.ProjectLeader))
                  .ForMember(s => s.ProjectOwner, s => s.MapFrom(p => p.ProjectOwner))
                  .ForMember(s => s.ProjectDescription, s => s.MapFrom(p => p.ProjectDescription))
                  .ForMember(s => s.ProjectNumber, s => s.MapFrom(p => p.ProjectNumber))
                  .ForMember(s => s.BudgetNumber, s => s.MapFrom(p => p.BudgetNumber))
                  .ForMember(s => s.ConstructionLeader, s => s.MapFrom(p => p.ConstructionLeader))
                  .ForMember(s => s.YearOfConstruction, s => s.MapFrom(p => p.YearOfConstruction))
                  .ForMember(s => s.FestivalDivision, s => s.MapFrom(p => p.FestivalDivision))
                  .ForMember(s => s.Location, s => s.MapFrom(p => p.Location))
                  .ForMember(s => s.ConstructionPurpose, s => s.MapFrom(p => p.ConstructionPurpose))
                  .ForMember(s => s.PhysicalSize, s => s.MapFrom(p => p.PhysicalSize))
                  .ForMember(s => s.PhysicalCapacity, s => s.MapFrom(p => p.PhysicalCapacity))
                  .ForAllOtherMembers(s => s.Ignore());
            });

            configuration.AssertConfigurationIsValid();
            Mapper = configuration.CreateMapper();
        }
    }
}