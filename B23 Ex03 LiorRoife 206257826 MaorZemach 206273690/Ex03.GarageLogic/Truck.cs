using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_WheelsAmountber = 14;
        private const float k_WheelMaxAirPressure = 26f;
        private const float k_FuelCapacityInLiters = 135f;
        private bool v_IsAbleToTransoprtHazardMaterials;
        private float m_CargoCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber, bool I_IsAbleToTransportHazardMaterials, float i_CargoCapacity)
            : base(i_ModelName, i_LicenseNumber, k_WheelsAmountber, k_WheelMaxAirPressure)
        {
            v_IsAbleToTransoprtHazardMaterials = I_IsAbleToTransportHazardMaterials;
            m_CargoCapacity = i_CargoCapacity;
        }

        public bool IsAbleToTransoprtHazardMaterials
        {
            get
            {
                return v_IsAbleToTransoprtHazardMaterials;
            }
            set
            {
                v_IsAbleToTransoprtHazardMaterials = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }
            set
            {
                m_CargoCapacity = value;
            }
        }

        public override void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle)
        {
            m_EnergySource = new FuelSource(eFuelType.Soler, k_FuelCapacityInLiters, i_CurrentEnergyInVehicle);
        }

        public override string ToString()
        {
            string returnedString = string.Format(@"Truck's unique properties:{0}Driving with hazard materials: {1}
Maximum cargo capacity: {2}", Environment.NewLine, IsAbleToTransoprtHazardMaterials, CargoCapacity);

            return returnedString;
        }
    }
}