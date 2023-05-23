using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        internal const int k_WheelsNum = 5;
        internal const float k_WheelMaxAirPressure = 33f;
        internal const float k_FuelTankCapacityInLiters = 46f;
        internal const float k_MaxBatteryTimeInHours = 5.2f;
        internal readonly eFuelType r_FuelType;
        private eCarColors m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_ModelName, string i_LicensingNumber, eCarColors i_CarColor, eNumberOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicensingNumber, k_WheelsNum)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumOfDoors;
            r_FuelType = eFuelType.Octan95;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public eCarColors CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle)
        {
            if(i_EnergySourceType == eEnergySourceType.Fuel)
            {
                m_FuelSource = new FuelSource(r_FuelType, k_FuelTankCapacityInLiters, i_CurrentEnergyInVehicle);
            }

            else
            {
                m_ElectricSource = new ElectricSource(k_MaxBatteryTimeInHours, i_CurrentEnergyInVehicle);
            }
        }
    } 
}
