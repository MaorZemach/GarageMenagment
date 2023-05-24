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
        protected FuelSource m_FuelSource;
        protected ElectricSource m_ElectricSource;
        private eVehicleStatusInGarage m_VehicleStatus;
        private List<Wheel> m_Wheels;
        private readonly int r_NumOfWheels;
        private float m_MaxWheelAirPressure;
        private readonly float r_MaxEnergyCapacity;
        private string m_OwnerName;
        private string m_OwnerPhone;

        public Vehicle(string i_ModelName, string i_LicensingNumber, int i_NumOfWheels, float i_MaxWheelAirPressure)
        {
            r_ModelName = i_ModelName;
            r_LicensingNumber = i_LicensingNumber;
            m_Wheels = new List<Wheel>();
            r_NumOfWheels = i_NumOfWheels;
            m_MaxWheelAirPressure = i_MaxWheelAirPressure;
            m_VehicleStatus = eVehicleStatusInGarage.InRepair;
            //m_EnergySource = i_EnergySource;
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
                return m_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
            set
            {
                m_OwnerPhone = value;
            }

        }

        public void SetOwnerDetails(string i_OwnerName, string i_OwnerPhone)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
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

        public void InflateWheels(float i_AirToAdd)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelAirPressure(i_AirToAdd);
            }
        }

        public void inflateWheelsAirPressureToMax()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public bool CheckEnergySourceIsFuel()
        {
            bool v_IsFuel = false;
            if(VehicleEnergySource==null)
            {
                v_IsFuel = true;
            }

            return v_IsFuel;
        }

       public void setCurrentAmountOfEnergySource(float i_NewAmountOfEnergySource)
        {
            bool v_IsFuel = CheckEnergySourceIsFuel();
            if(v_IsFuel==true)
            {
                this.VehicleFuelSource.FuelLeftInLiters = i_NewAmountOfEnergySource;
            }
            else
            {
                VehicleElectricSource.TimeLeftInHours = i_NewAmountOfEnergySource;
            }
        }

        public abstract void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle); 
    }
}
