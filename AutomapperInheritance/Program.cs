using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperInheritance
{
    class Program
    {
        static IMapper mapper;

        static void Main(string[] args)
        {
            Infrastructure.ApplicationDriverEquipmentInfrastructure inf = new Infrastructure.ApplicationDriverEquipmentInfrastructure() { CurrentMileage = "mil", Length = "123", Make = "ccc", Model = "15", Type = "Tractor", VINNumber = "vin" };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperRules>());
            mapper = config.CreateMapper();

            var domain = mapper.Map<Domain.ApplicationDriverEquipmentAbstractDomain>(inf);
        }
    }
}
