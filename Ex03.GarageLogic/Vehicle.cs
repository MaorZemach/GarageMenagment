using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
  public abstract class Vehicle
  {
        protected readonly string r_ModelName;
        protected readonly string r_LicensingNumber;
        protected FuelSource m_FuelSource;
        protected ElectricSource m_ElectricSource;
        private eVehicleStatusInGarage m_VehicleStatus;
        private List<Wheel> m_Wheels;
        private readonly int r_NumOfWheels;
        private readonly  float r_MaxEnergyCapacity;
              
        public Vehicle(string i_ModelName, string i_LicensingNumber, int i_NumOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicensingNumber = i_LicensingNumber;
            m_Wheels = new List<Wheel>();
            r_NumOfWheels = i_NumOfWheels;
            m_VehicleStatus = eVehicleStatusInGarage.InRepair;
            m_FuelSource = null;
            m_ElectricSource = null;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicensingNumber;
            }
        }

        public  int NumOfWheels
        {
            get
            {
                return r_NumOfWheels;
            }
        }

        public eVehicleStatusInGarage VehicleStatusInGarage
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public FuelSource VehicleFuelSource
        {
            get
            {
                return m_FuelSource;
            }
        }
        public ElectricSource VehicleElectricSource
        {
            get
            {
                return m_ElectricSource;
            }
        }

        public void ProduceAndAddWheel(string i_WheelManufactureName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            for(int i = 0;i < r_NumOfWheels;i++)
            {
                m_Wheels.Add(CreateNewWheel(i_WheelManufactureName, i_MaxAirPressure, i_CurrentAirPressure));
            }
        }

        private static Wheel CreateNewWheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            return new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
        }

        public void InflateWheels(float i_AirPressureToAdd)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelAirPressure(i_AirPressureToAdd);
            }
        }

        public abstract void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle); 
    }
}
