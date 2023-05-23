using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> r_Vehicles; // maybe should be private readonly

        public Garage()
        {
            r_Vehicles = new Dictionary<string, Vehicle>(); //<key, value> -> <licenseNumber,Vehicle>
        }

        public Dictionary<string, Vehicle> VehiclesList
        {
            get
            {
                return r_Vehicles;
            }
        }

        public bool IsVehicleExistsInGarage(string i_VehicleLicenseNumber)
        {
            return r_Vehicles.ContainsKey(i_VehicleLicenseNumber);
        }

        public void AddNewVehicleToGarage(string i_LisecnceNumber, Vehicle i_Vehicle)
        {
            r_Vehicles.Add(i_LisecnceNumber, i_Vehicle);
            UpdateVehicleStatusInGarage(i_LisecnceNumber, eVehicleStatusInGarage.InRepair);
        }

        public void UpdateVehicleStatusInGarage(string i_VehicleLicenseNumber, eVehicleStatusInGarage i_UpdatedVehicleStatus)
        {
            Vehicle vehicle = GetVehicleInGarage(i_VehicleLicenseNumber);

            vehicle.VehicleStatusInGarage = i_UpdatedVehicleStatus;
        }

        public Vehicle GetVehicleInGarage(string i_VehicleLicenseNumber)
        {
            Vehicle vehicle = null;

            r_Vehicles.TryGetValue(i_VehicleLicenseNumber, out vehicle);

            return vehicle;
        }

        public void InflateWheelsAirPressureToMax(string i_VehicleLicenseNumber)
        {
            Vehicle vehicle = GetVehicleInGarage(i_VehicleLicenseNumber);

            vehicle.inflateWheelsAirPressureToMax();
            vehicle.eF
        }

        public bool IsVehicleInGarageListInChosenStateIsEmpty(Enum i_VehicleStatusInGarage)
        {
            bool v_isEmpty = true;

            foreach (KeyValuePair<string, Vehicle> vehicle in VehiclesList)
            {
                if (vehicle.Value.VehicleStatusInGarage.Equals(i_VehicleStatusInGarage) == true)
                {
                    v_isEmpty = false;
                    break;
                }
            }

            return v_isEmpty;
        }

        //from maor
        public static Vehicle ProduceCar(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseName, eNumberOfDoors i_NumOfDoors, eCarColors i_CarColor)
        {
            Car newCar = new Car(i_ModelName, i_LicenseName, eCarColors.Black, eNumberOfDoors.FiveDoors);
            newCar.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);

            return newCar;
        }

        public static Vehicle ProduceMotorcycle(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseNum, eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            Motorcycle newMotorcycle = new Motorcycle(i_ModelName, i_LicenseNum, i_EngineCapacity, i_LicenseType);
            newMotorcycle.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);

            return newMotorcycle;
        }

        public static Vehicle ProduceTruck(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseName, bool I_IsTransoprtHazardousMaterials, float CargoCapacity)
        {
            Truck newTruck = new Truck(i_ModelName, i_LicenseName, I_IsTransoprtHazardousMaterials, CargoCapacity);
            newTruck.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);

            return newTruck;
        }
    }
}