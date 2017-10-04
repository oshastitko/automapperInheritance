using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperInheritance.Domain
{
    public abstract class ApplicationDriverEquipmentAbstractDomain
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string CurrentMileage { get; set; }
        public string Type { get; protected set; }
    }

    public class ApplicationDriverEquipmentTractorDomain : ApplicationDriverEquipmentAbstractDomain
    {
        public ApplicationDriverEquipmentTractorDomain()
        {
            Type = "Tractor";
        }
        public string VINNumber { get; set; }
    }

    public class ApplicationDriverEquipmentTrailerDomain : ApplicationDriverEquipmentAbstractDomain
    {
        public ApplicationDriverEquipmentTrailerDomain()
        {
            Type = "Trailer";
        }

        public string Length { get; set; }
    }

    public class ApplicationDriverEquipmentStraightTruckDomain : ApplicationDriverEquipmentAbstractDomain
    {
        public ApplicationDriverEquipmentStraightTruckDomain()
        {
            Type = "StraightTruck";
        }

        public string VINNumber { get; set; }
        public string Length { get; set; }
    }

    public class ApplicationDriverEquipmentCargoVanDomain : ApplicationDriverEquipmentAbstractDomain
    {
        public ApplicationDriverEquipmentCargoVanDomain()
        {
            Type = "CargoVan";
        }

        public string VINNumber { get; set; }
        public string Length { get; set; }
    }
}
