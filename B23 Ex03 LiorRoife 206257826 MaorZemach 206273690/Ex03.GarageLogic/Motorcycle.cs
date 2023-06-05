using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int k_WheelsAmount = 2;
        internal const float k_WheelMaxAirPressure = 31f;
        internal const float k_FuelCapacityInLiters = 6.4f;
        private const float k_MaxBatteryTimeInHours = 2.6f;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicenseType i_LicenseType)
            : base(i_ModelName, i_LicenseNumber, k_WheelsAmount, k_WheelMaxAirPressure)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public override void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle)
        {
            if (i_EnergySourceType == eEnergySourceType.Fuel)
            {
                m_EnergySource = new FuelSource(eFuelType.Octan98, k_FuelCapacityInLiters, i_CurrentEnergyInVehicle);
            }

            else
            {
                m_EnergySource = new ElectricSource(k_MaxBatteryTimeInHours, i_CurrentEnergyInVehicle);
            }
        }

        public override string ToString()
        {
            string returnedString = string.Format(@"Motorcycle's unique properties:{0}License type: {1}
Engine size: {2}
", Environment.NewLine, LicenseType, EngineCapacity);

            return returnedString;
        }
    }
}