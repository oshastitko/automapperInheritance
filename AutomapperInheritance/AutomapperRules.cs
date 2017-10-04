using AutoMapper;
using AutomapperInheritance.Domain;
using AutomapperInheritance.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperInheritance
{
    public class AutomapperRules : AutoMapper.Profile
    {
        public AutomapperRules()
        {
            CreateMap<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentAbstractDomain>()
                .Include<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentTractorDomain>()
                .Include<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentTrailerDomain>()
                .Include<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentStraightTruckDomain>()
                .Include<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentCargoVanDomain>()
    ;

            CreateMap<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentTractorDomain>().ApplyBaseMapping();
            CreateMap<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentTrailerDomain>().ApplyBaseMapping();
            CreateMap<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentStraightTruckDomain>().ApplyBaseMapping();
            CreateMap<ApplicationDriverEquipmentInfrastructure, ApplicationDriverEquipmentCargoVanDomain>().ApplyBaseMapping();
        }
    }

    public static class BaseMapping
    {
        public static IMappingExpression<A, T> ApplyBaseMapping<A, T>(this IMappingExpression<A, T> mappingExpression)
            where A : ApplicationDriverEquipmentInfrastructure
            where T : ApplicationDriverEquipmentAbstractDomain
        {
            mappingExpression.ForMember(dest => dest.Type, opt => opt.ResolveUsing(GetEquipment));

            return mappingExpression;
        }

        private static ApplicationDriverEquipmentAbstractDomain GetEquipment(ApplicationDriverEquipmentInfrastructure infrastructure)
        {
            switch (infrastructure.Type)
            {
                case "Tractor":
                    return Mapper.Map<ApplicationDriverEquipmentTractorDomain>(infrastructure);
                case "Trailer":
                    return Mapper.Map<ApplicationDriverEquipmentTrailerDomain>(infrastructure);
                case "StraightTruck":
                    return Mapper.Map<ApplicationDriverEquipmentStraightTruckDomain>(infrastructure);
                case "CargoVan":
                    return Mapper.Map<ApplicationDriverEquipmentCargoVanDomain>(infrastructure);
            }
            return null;
        }
    }

}
