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
        protected EnergySource m_EnergySource;
        private eVehicleStatusInGarage m_VehicleStatus;
        private List<Wheel> m_Wheels;
        private readonly int r_AmountOfWheels;
        private float m_MaxWheelAirPressure;
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;

        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_AmountOfWheels, float i_MaxWheelAirPressure)
        {
            r_ModelName = i_ModelName;
            r_LicensingNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
            r_AmountOfWheels = i_AmountOfWheels;
            m_MaxWheelAirPressure = i_MaxWheelAirPressure;
            m_VehicleStatus = eVehicleStatusInGarage.InRepair;
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
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

        public int AmountOfWheels
        {
            get
            {
                return r_AmountOfWheels;
            }
        }

        public float MaxWheelAirPressure
        {
            get
            {
                return m_MaxWheelAirPressure;
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

        public EnergySource VehicleEnergySource
        {
            get
            {
                return m_EnergySource;
            }
            set
            {
                m_EnergySource = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }
            set
            {
                m_VehicleOwnerPhone = value;
            }

        }

        public void SetVehicleOwnerInfo(string i_OwnerName, string i_OwnerPhone)
        {
            m_VehicleOwnerName = i_OwnerName;
            m_VehicleOwnerPhone = i_OwnerPhone;
        }

        public void ProduceAndAddWheel(string i_WheelManufactureName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            for (int i = 0; i < r_AmountOfWheels; i++)
            {
                m_Wheels.Add(CreateNewWheel(i_WheelManufactureName, i_MaxAirPressure, i_CurrentAirPressure));
            }
        }

        private static Wheel CreateNewWheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            return new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
        }

        public void InflateWheels(float i_AirToAdd)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelAirPressure(i_AirToAdd);
            }
        }

        public void inflateWheelsAirPressureToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public bool CheckIfEnergySourceIsFuel()
        {
            bool v_IsFuel = false;

            if (VehicleEnergySource == null)
            {
                v_IsFuel = true;
            }

            return v_IsFuel;
        }

        public void setCapacityLeftInEnergySource(float i_NewAmountOfEnergySource)
        {
            VehicleEnergySource.CapacityLeftInEnergySource = i_NewAmountOfEnergySource;
        }

        public abstract void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle);

        public void GetEnergyInfo(out string o_EnergySourceType, out float o_EnergyAmountLeft, out float o_MaxEnergyCapacity, out float o_EnergyLeftInPercentage)
        {
            o_EnergySourceType = m_EnergySource.GetType().Name;
            o_EnergyAmountLeft = m_EnergySource.CapacityLeftInEnergySource;
            o_MaxEnergyCapacity = m_EnergySource.MaxEnergySourceCapacity;
            o_EnergyLeftInPercentage = VehicleEnergySource.EnergyLeftInPercentage;
        }
    }
}