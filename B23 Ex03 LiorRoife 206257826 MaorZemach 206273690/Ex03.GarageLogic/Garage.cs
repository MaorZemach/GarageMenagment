using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new Dictionary<string, Vehicle>();
        }

        public Dictionary<string, Vehicle> VehiclesList
        {
            get
            {
                return r_Vehicles;
            }
        }

        public void AddNewVehicleToGarage(string i_LisecnceNumber, Vehicle i_Vehicle)
        {
            r_Vehicles.Add(i_LisecnceNumber, i_Vehicle);
            UpdateVehicleStatus(i_LisecnceNumber, eVehicleStatusInGarage.InRepair);
        }

        public Vehicle GetVehicleByLicenseNumber(string i_VehicleLicenseNumber)
        {
            Vehicle vehicle = null;
            try
            {
                r_Vehicles.TryGetValue(i_VehicleLicenseNumber, out vehicle);
            }
            catch (ArgumentException)
            {
                throw new ArgumentNullException();
            }

            return vehicle;
        }

        public void UpdateVehicleStatus(string i_VehicleLicenseNumber, eVehicleStatusInGarage i_UpdatedVehicleStatus)
        {
            Vehicle vehicle = GetVehicleByLicenseNumber(i_VehicleLicenseNumber);

            vehicle.VehicleStatusInGarage = i_UpdatedVehicleStatus;
        }

        public void InflateWheelsAirPressureToMax(string i_VehicleLicenseNumber)
        {
            Vehicle vehicle = GetVehicleByLicenseNumber(i_VehicleLicenseNumber);

            vehicle.inflateWheelsAirPressureToMax();
        }

        public bool IsVehicleInGarageListInChosenStatusIsEmpty(Enum i_VehicleStatusInGarage)
        {
            bool v_isEmpty = true;

            foreach (KeyValuePair<string, Vehicle> vehicle in VehiclesList)
            {
                if (vehicle.Value.VehicleStatusInGarage.Equals(i_VehicleStatusInGarage))
                {
                    v_isEmpty = false;
                    break;
                }
            }

            return v_isEmpty;
        }

        public bool IsVehicleInGarageListEmpty()
        {
            bool v_isEmpty;

            if (VehiclesList.Count == 0)
            {
                v_isEmpty = true;
            }

            else
            {
                v_isEmpty = false;
            }

            return v_isEmpty;
        }

        public bool IsVehicleExistsInGarage(string i_VehicleLicenseNumber)
        {
            return r_Vehicles.ContainsKey(i_VehicleLicenseNumber);
        }

        public static Vehicle ProduceCar(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseName, eAmountOfDoors i_AmountOfDoors, eCarColor i_CarColor)
        {
            Car newCar = new Car(i_ModelName, i_LicenseName, i_CarColor, i_AmountOfDoors);
            bool v_isValid = false;

            while (!v_isValid)
                try
                {
                    newCar.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);
                    v_isValid = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    v_isValid = false;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    v_isValid = false;
                }

            return newCar;
        }

        public static Vehicle ProduceMotorcycle(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            Motorcycle newMotorcycle = new Motorcycle(i_ModelName, i_LicenseNumber, i_EngineCapacity, i_LicenseType);
            bool v_isValid = false;

            while (!v_isValid)
                try
                {
                    newMotorcycle.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);
                    v_isValid = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    v_isValid = false;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    v_isValid = false;
                }

            return newMotorcycle;
        }

        public static Vehicle ProduceTruck(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseName, bool I_IsAbleToTransportHazardMaterials, float CargoCapacity)
        {
            Truck newTruck = new Truck(i_ModelName, i_LicenseName, I_IsAbleToTransportHazardMaterials, CargoCapacity);
            bool v_isValid = false;

            while (!v_isValid)
                try
                {
                    newTruck.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);
                    newTruck.VehicleEnergySource.SetEnergyPrecentage(newTruck.VehicleEnergySource.MaxEnergySourceCapacity, i_CurrentEnergy);
                    v_isValid = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    v_isValid = false;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    v_isValid = false;
                }

            return newTruck;
        }
    }
}