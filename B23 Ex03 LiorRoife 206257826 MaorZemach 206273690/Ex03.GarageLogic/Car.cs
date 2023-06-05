using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        internal const int k_WheelsAmount = 5;
        internal const float k_WheelMaxAirPressure = 33f;
        internal const float k_FuelCapacityInLiters = 46f;
        internal const float k_MaxBatteryTimeInHours = 5.2f;
        internal readonly eFuelType r_FuelType;
        private eCarColor m_CarColor;
        private eAmountOfDoors m_AmountOfDoors;

        public Car(string i_ModelName, string i_LicenseNumberber, eCarColor i_CarColor, eAmountOfDoors i_AmountOfDoors)
            : base(i_ModelName, i_LicenseNumberber, k_WheelsAmount, k_WheelMaxAirPressure)
        {
            m_CarColor = i_CarColor;
            m_AmountOfDoors = i_AmountOfDoors;
            r_FuelType = eFuelType.Octan95;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public eCarColor CarColor
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

        public eAmountOfDoors AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }
            set
            {
                m_AmountOfDoors = value;
            }
        }

        public override void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_AmountOfEnergyInVehicle)
        {
            if (i_EnergySourceType == eEnergySourceType.Fuel)
            {
                m_EnergySource = new FuelSource(r_FuelType, k_FuelCapacityInLiters, i_AmountOfEnergyInVehicle);
            }

            else
            {
                m_EnergySource = new ElectricSource(k_MaxBatteryTimeInHours, i_AmountOfEnergyInVehicle);
            }
        }

        public override string ToString()
        {
            string returnedString = string.Format(@"Car's unique properties:{0}Color: {1}
Number of doors: {2}
", Environment.NewLine, CarColor, AmountOfDoors);

            return returnedString;
        }
    }
}