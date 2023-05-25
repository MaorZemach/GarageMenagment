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

        }

        public bool IsVehicleInGarageListInChosenStatusIsEmpty(Enum i_VehicleStatusInGarage)
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

        //from maor
        public static Vehicle ProduceCar(eEnergySourceType i_EnergySourceType, float i_CurrentEnergy, string i_ModelName, string i_LicenseName, eNumberOfDoors i_NumOfDoors, eCarColors i_CarColor)
        {
            Car newCar = new Car(i_ModelName, i_LicenseName, i_CarColor, i_NumOfDoors);
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
            bool v_isValid = false;

            while (v_isValid == false)
                try
                {
                    newTruck.CreateEnergySource(i_EnergySourceType, i_CurrentEnergy);
                    newTruck.VehicleEnergySource.setAmountOfEnergyPrecentage(newTruck.VehicleEnergySource.MaxAmountOfEnergySource, i_CurrentEnergy);
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

        /*public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, eEnergySourceType i_EnergySource, string i_ModelName, string i_LicenseNumber)
        {
            Vehicle newVehicle;
            EnergySource newEnergySource;

            if (i_VehicleType == eVehicleType.Motorcycle)
            {
                if (i_EnergySource == eEnergySourceType.Fuel)
                {
                    newEnergySource = new FuelSource(eFuelType.Octan98, Motorcycle.k_FuelTankCapacity);
                }
                else
                {
                    newEnergySource = new ElectricSource(Motorcycle.k_MaxBatteryTimeInHours);
                }

                newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, newEnergySource);
            }
            else if (i_VehicleType == eVehicleType.Car)
            {
                if (i_EnergySource == eEnergySourceType.Fuel)
                {
                    newEnergySource = new FuelSource(eFuelType.Octan95, Car.k_FuelTankCapacity);
                }
                else
                {
                    newEnergySource = new ElectricSource(Car.k_MaxBatteryTimeInHours);
                }

                newVehicle = new Car(i_ModelName, i_LicenseNumber, newEnergySource);
            }
            else
            {
                newEnergySource = new FuelSource(eFuelType.Soler, Truck.k_FuelTankCapacity);
                newVehicle = new Truck(i_ModelName, i_LicenseNumber, newEnergySource);
            }

            return newVehicle;
        }*/
    }
}