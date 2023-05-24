using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIManagement
    {
        //private const int k_MinutesInHour = 60;
        private Ex03.GarageLogic.Garage m_Garage;
        public UIManagement()
        {
            m_Garage = new Ex03.GarageLogic.Garage();
        }

        public void Run()
        {
            //run
            const int exitOption = 8;
            const int minRangeOfOptions = 1;
            eMenuOption convertedUserInputChoice = 0;
            bool v_isValidChoice;

            while (convertedUserInputChoice != eMenuOption.Exit)
            {
                v_isValidChoice = false;
                UIInputsOutputsMessages.PrintGarageMenuOptions();

                while (!v_isValidChoice)
                {
                    try
                    {
                        convertedUserInputChoice = (eMenuOption)UIInputsOutputsMessages.GetInputChoiceFromUser(1, 8);//GetMenuOptionChoiceFromUser(); -- menu options
                        v_isValidChoice = true;
                    }
                    catch (FormatException formatException)
                    {
                        v_isValidChoice = false;
                        Console.WriteLine(formatException.Message);
                    }
                    catch (ValueOutOfRangeException valueOutOfRangeException)
                    {
                        v_isValidChoice = false;
                        Console.WriteLine(valueOutOfRangeException.Message);
                    }
                }

                switch (convertedUserInputChoice)
                {
                    case eMenuOption.InsertNewVehicle:
                        {
                            // insertNewVehicleToGarage();
                            insertNewVehicleToGarage();
                            break;
                        }

                    case eMenuOption.DisplayListOfVehiclesLicenseNumbersInGarage:
                        {
                            // displayLicenseNumberListOfVehiclesInGarage();
                            break;
                        }

                    case eMenuOption.ChangeVehicleStatus:
                        {
                            updateVehicleStatus();
                            break;
                        }

                    case eMenuOption.InflateWheelsToMax:
                        {
                            inflatingWheelsToMaxAirPressure();
                            break;
                        }

                    case eMenuOption.RefuelVehicle:
                        {
                            refuelingVehicle();
                            break;
                        }

                    case eMenuOption.ChargeVehicle:
                        {
                            chargeElectricVehicle();
                            break;
                        }

                    case eMenuOption.DisplayVehicleDetails:
                        {
                            // displayVehicleDetailsByLicenseNumber();
                            break;
                        }

                    case eMenuOption.Exit:
                        {
                            // Exit();
                            break;
                        }

                    default:
                        break;
                }

            }
        }

        private void insertNewVehicleToGarage()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();//get Vehicle License Number 


            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber)) // If Vehicle License Number exists in the garage change to inrepair and print msg.
            {
                UIInputsOutputsMessages.PrintMessage("This vehicle is already exists in the garage.");
                m_Garage.UpdateVehicleStatusInGarage(vehicleLicenseNumber, eVehicleStatusInGarage.InRepair);
            }

            else// If Vehicle License Number DOESN'T exist in the garage we create and insert new vehicle to the garage.
            {   //e.g:
                //Choose Vehicle Type (Motorcycle / Car / Truck)
                //Choose Model
                //Choose EnergySource Fuel / Battery //?
                //Switch(VehicleType)
                //If Car: get
                //If Motorcycle: get
                //If Truck: get
                //
                //Enter vehicle status:              1. EnergySource status  fuel / battery left (Percentage or exact amount - need to make sure about it.)
                //                                   2. Wheels ManufacturerName
                //                                   2. Wheels air pressure status (Percentage or exact amount -  need to make sure about it.)
                //                                   3. If it's Car - Model choose Color , 
                //                                   4. If it's Motorcycle - Model choose LicenceType , 
                //                                   5. If it's Truck - choose if if cold avilable or not.

                Vehicle newVehicle = getVehicleDetailsFromUserAndCreateNewVehicle(vehicleLicenseNumber);
                m_Garage.AddNewVehicleToGarage(vehicleLicenseNumber, newVehicle);
                UIInputsOutputsMessages.PrintRequestCompleted();
            }
        }

        private Vehicle getVehicleDetailsFromUserAndCreateNewVehicle(string i_VehicleLicenseNumber)
        {
            Vehicle newVehicle;
            eVehicleType vehicleType;
            eEnergySourceType energySourceType;
            string vehicleModel;
            string ownerPhoneNumber, ownerName;
            float currentWheelAirPressure = 0;
            float currentAmountOfEnergySource = 0;
            bool isValidInput = false;

            vehicleModel = UIInputsOutputsMessages.GetVehicleModelFromUser();
            vehicleType = (eVehicleType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eVehicleType));
            //currentWheelAirPressure = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of air pressure in the vehicle wheels: ", Environment.NewLine)));

            /*if (vehicleType is eVehicleType.Truck == true)
            {
                energySourceType = eEnergySourceType.Fuel;
            }
            
            else
            {
                energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
            }*/


           /* switch (vehicleType)
            {
                case eVehicleType.Car:
                    {
                        energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                        newVehicle = getCarDetailsAndCreateCar(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, currentWheelAirPressure, vehicleModel);
                        break;
                    }
                case eVehicleType.Motorcycle:
                    {
                        energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                        newVehicle = getMotorcycleDetailsAndCreateMotorcycle(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, currentWheelAirPressure, vehicleModel);
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        energySourceType = eEnergySourceType.Fuel;
                        newVehicle = getTruckDetailsAndCreateTruck(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, vehicleModel);
                        break;
                    }
            }*/

            if(vehicleType==eVehicleType.Truck)
            {
                energySourceType = eEnergySourceType.Fuel;
                currentAmountOfEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                newVehicle = getTruckDetailsAndCreateTruck(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, vehicleModel);
            }
            else if(vehicleType==eVehicleType.Motorcycle)
            {
                energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                currentAmountOfEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                newVehicle = getMotorcycleDetailsAndCreateMotorcycle(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, currentWheelAirPressure, vehicleModel);
            }
            else //car
            {
                energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                currentAmountOfEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                newVehicle = getCarDetailsAndCreateCar(i_VehicleLicenseNumber, energySourceType, currentAmountOfEnergySource, currentWheelAirPressure, vehicleModel);
            }

            // Vehicle newVehicle = Factory.CreateNewVehicle(vehicleType, energySourceType, vehicleModel, i_VehicleLicenseNumber);
            
                        while (isValidInput == false)
                        {
                            try
                            {
                                currentWheelAirPressure = UIInputsOutputsMessages.GetCurrentWheelAirPressure(newVehicle.MaxWheelAirPressure);
                                isValidInput = true;
                            }
                            catch (FormatException formatException)
                            {
                                Console.WriteLine(formatException.Message);
                                isValidInput = false;
                            }
                            catch (ValueOutOfRangeException valueOutOfRangeException)
                            {
                                Console.WriteLine(valueOutOfRangeException.Message);
                                isValidInput = false;
                            }
                        }

                        newVehicle.ProduceAndAddWheel(UIInputsOutputsMessages.GetWheelManufacture(),newVehicle.MaxWheelAirPressure, currentWheelAirPressure);
                        UIInputsOutputsMessages.GetOwnerDetails(out ownerName, out ownerPhoneNumber);
                        newVehicle.SetOwnerDetails(ownerName, ownerPhoneNumber);
                        //setNewVehicleSpecialProperties(newVehicle);

                        while (isValidInput == false)
                        {
                            try
                            {
                               // currentAmountOfEnergySource = UIView.GetCurrentEnergyFromUser(newVehicle.EnergySource.MaxAmountOfEnergySource);
                                newVehicle.setCurrentAmountOfEnergySource(currentAmountOfEnergySource);
                                newVehicle.VehicleEnergySource.setAmountOfEnergyPrecentage(newVehicle.VehicleEnergySource.MaxAmountOfEnergySource, currentAmountOfEnergySource);
                                isValidInput = true;
                            }
                            catch (FormatException formatException)
                            {
                                Console.WriteLine(formatException.Message);
                                isValidInput = false;
                            }
                            catch (ValueOutOfRangeException valueOutOfRangeException)
                            {
                                Console.WriteLine(valueOutOfRangeException.Message);
                                isValidInput = false;
                            }
                        }
                        
            return newVehicle;
        }

        private void updateVehicleStatus()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber) == false)
            {
                UIInputsOutputsMessages.PrintVehicleIsNotInGarage();
            }

            else
            {
                eVehicleStatusInGarage newVehicleStatus = (eVehicleStatusInGarage)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eVehicleStatusInGarage));
                m_Garage.UpdateVehicleStatusInGarage(vehicleLicenseNumber, newVehicleStatus);
                UIInputsOutputsMessages.PrintRequestCompleted();
            }

        }

        private void inflatingWheelsToMaxAirPressure()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber) == false)
            {
                UIInputsOutputsMessages.PrintVehicleIsNotInGarage();
            }
            else
            {
                m_Garage.InflateWheelsAirPressureToMax(vehicleLicenseNumber);
                UIInputsOutputsMessages.PrintRequestCompleted();
            }
        }

        private void refuelingVehicle()
        {
            addToEnergySource(typeof(FuelSource));
        }

        private void chargeElectricVehicle()
        {
            addToEnergySource(typeof(ElectricSource));
        }

        private void addToEnergySource(Type i_energySourceType)
        {
            float CapacityOfEnergySourceToAdd;
            bool isValidInput = false;
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();
            Type vehicleEnergySourceType;

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber) == false)
            {
                UIInputsOutputsMessages.PrintVehicleIsNotInGarage();
            }

            else
            {

                Vehicle vehicle = m_Garage.GetVehicleInGarage(vehicleLicenseNumber);

                //if(vehicle.CheckEnergySourceIsFuel()==false)
                // {
                //  vehicleEnergySourceType = vehicle.VehicleElectricSource.GetType();
                //}                else if(vehicle.CheckEnergySourceIsFuel() == true)
                //{
                vehicleEnergySourceType = vehicle.VehicleEnergySource.GetType();
                //}

                if (vehicleEnergySourceType != i_energySourceType)
                {
                    UIInputsOutputsMessages.PrintUnMatchEnergySourceForVehicle();
                }

                else
                {
                    if (i_energySourceType == typeof(FuelSource))
                    {
                        while ((eFuelType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eFuelType)) != (vehicle.VehicleEnergySource as FuelSource).FuelType)
                        {
                            UIInputsOutputsMessages.PrintUnMatchFuelForVehicle();
                        }
                    }

                    while (isValidInput == false)
                    {
                        try
                        {
                            if (i_energySourceType == typeof(FuelSource))
                            {
                                CapacityOfEnergySourceToAdd = UIInputsOutputsMessages.GetAmountOfFuelToAdd();
                                vehicle.VehicleFuelSource.RenewAmountOfEnergy(vehicle.VehicleFuelSource.FuelType, CapacityOfEnergySourceToAdd);
                                vehicle.VehicleEnergySource.setAmountOfEnergyPrecentage(vehicle.VehicleFuelSource.MaxFuelCapacity, vehicle.VehicleFuelSource.FuelLeftInLiters);

                            }

                            else
                            {
                                CapacityOfEnergySourceToAdd = UIInputsOutputsMessages.GetNumOfMinutesToCharge();
                                vehicle.VehicleElectricSource.RenewAmountOfEnergy(CapacityOfEnergySourceToAdd);
                                vehicle.VehicleEnergySource.setAmountOfEnergyPrecentage(vehicle.VehicleElectricSource.MaxEletricCapacity, vehicle.VehicleElectricSource.TimeLeftInHours);
                            }

                            //vehicle.VehicleEnergySource.ChargeOrRefuelVehicle(amountToAddToEnergySource);
                            isValidInput = true;
                        }
                        catch (FormatException formatException)
                        {
                            Console.WriteLine(formatException.Message);
                            isValidInput = false;
                        }
                        catch (ValueOutOfRangeException valueOutOfRangeException)
                        {
                            Console.WriteLine(valueOutOfRangeException.Message);
                            isValidInput = false;
                        }
                    }
                    UIInputsOutputsMessages.PrintRequestCompleted();
                }
            }
        }

        private Vehicle getMotorcycleDetailsAndCreateMotorcycle(string i_MotorCycleLicense, eEnergySourceType i_EnergySourceType, float i_AmountOfEnergySource, float i_AmountOfAirPressure, string i_ModelName)
        {
            int engineCapacity = 0;
            bool isEnginCapacityValid = false;
            string motorcycleUniqProperties;
           // string motorcycleUniqProperties = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please choose Motorcycle License: (0)A1,(1)A2,(2)A3", Environment.NewLine));
            eLicenseType licenseType = (eLicenseType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eLicenseType));
           // string motorcycleUniqProperties = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please insert the capacity of the Motorcycle engine: ", Environment.NewLine));
            while (isEnginCapacityValid == false)
            {
                motorcycleUniqProperties = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please insert the capacity of the Motorcycle engine: ", Environment.NewLine));
                isEnginCapacityValid = int.TryParse(motorcycleUniqProperties, out engineCapacity);
            }

            Vehicle MotorCycle = Garage.ProduceMotorcycle(i_EnergySourceType, i_AmountOfEnergySource, i_ModelName, i_MotorCycleLicense, licenseType, engineCapacity);

            return MotorCycle;
        }

        private Vehicle getTruckDetailsAndCreateTruck(string i_TruckLicense, eEnergySourceType i_EnergySourceType, float i_AmountOfEnergySource, string i_ModelName)
        {
            bool v_isTransportHazardMaterials = false;
            bool n_IsValidInput = false;
            float cargoCapacity = 0;
            while (n_IsValidInput == false)
            {
                string isTransportHazardMaterialsString = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}If the truck transoprt Hazard materials press: 'y' , else press 'n'", Environment.NewLine));
                if (string.Compare(isTransportHazardMaterialsString, "y") == 0)
                {
                    v_isTransportHazardMaterials = true;
                    n_IsValidInput = true;
                }

                else if (string.Compare(isTransportHazardMaterialsString, "n") == 0)
                {
                    n_IsValidInput = true;
                }
            }

            n_IsValidInput = false;
            string cargoCapacityInput = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the cargo capacity of the truck: ", Environment.NewLine));
            n_IsValidInput = float.TryParse(cargoCapacityInput, out cargoCapacity);
            while (n_IsValidInput == false)
            {
                cargoCapacityInput = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Invalid input. Please try again: ", Environment.NewLine));
                n_IsValidInput = float.TryParse(cargoCapacityInput, out cargoCapacity);
            }

            Vehicle Truck = Garage.ProduceTruck(i_EnergySourceType, i_AmountOfEnergySource, i_ModelName, i_TruckLicense, v_isTransportHazardMaterials, cargoCapacity);

            return Truck;
        }

        private Vehicle getCarDetailsAndCreateCar(string i_TruckLicense, eEnergySourceType i_EnergySourceType, float i_AmountOfEnergySource, float i_AmountOfAirPressure, string i_ModelName)
        {
            //string carColorInput = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the car color: (0)White,(1)Black,(2)Yellow,(3)Red: ", Environment.NewLine));
            eCarColors chosenCarColor = (eCarColors)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eCarColors));
           // string numberOfDoorsInput = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the number of doors in the car (between 2 to 5):", Environment.NewLine));
            eNumberOfDoors numberOfCarDoors = (eNumberOfDoors)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eNumberOfDoors));

            Vehicle Car = Garage.ProduceCar(i_EnergySourceType, i_AmountOfEnergySource, i_ModelName, i_TruckLicense, numberOfCarDoors, chosenCarColor);

            return Car;
        }
    }
}
