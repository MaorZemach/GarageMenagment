using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIManagement
    {
        private Ex03.GarageLogic.Garage m_Garage;
        public UIManagement()
        {
            m_Garage = new Ex03.GarageLogic.Garage();
        }

        public void Run()
        {
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
                            AddNewVehicleToGarage();
                            break;
                        }

                    case eMenuOption.DisplayListOfVehiclesLicenseNumbersInGarage:
                        {
                            displayLicenseNumberListOfVehiclesInGarage();
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
                            displayVehicleDetailsByLicenseNumber();
                            break;
                        }

                    case eMenuOption.Exit:
                        {
                            Environment.Exit(1);
                            break;
                        }

                    default:
                        break;
                }

            }
        }

        private void AddNewVehicleToGarage()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber)) 
            {
                UIInputsOutputsMessages.PrintMessage("This vehicle is already exists in the garage.");
                m_Garage.UpdateVehicleStatus(vehicleLicenseNumber, eVehicleStatusInGarage.InRepair);
            }

            else
            {   
                Vehicle newVehicle = getVehicleDetailsFromUserAndCreateNewVehicle(vehicleLicenseNumber);
                m_Garage.AddNewVehicleToGarage(vehicleLicenseNumber, newVehicle);
                UIInputsOutputsMessages.RequestSucceededMsg();
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
            float CapacityLeftInEnergySource = 0;
            bool isValidInput = false;

            vehicleModel = UIInputsOutputsMessages.GetVehicleModelFromUser();
            vehicleType = (eVehicleType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eVehicleType));       
            if (vehicleType == eVehicleType.Truck)
            {
                energySourceType = eEnergySourceType.Fuel;
                CapacityLeftInEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                if (CapacityLeftInEnergySource < 0 || CapacityLeftInEnergySource > 135f)
                {
                    throw new ValueOutOfRangeException("The inserted value is out of range.", 0, 135);
                }
                newVehicle = getTruckDetailsAndCreateTruck(i_VehicleLicenseNumber, energySourceType, CapacityLeftInEnergySource, vehicleModel);
            }

            else if (vehicleType == eVehicleType.Motorcycle)
            {
                energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                CapacityLeftInEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                if(energySourceType==eEnergySourceType.Electric)
                {
                    if(CapacityLeftInEnergySource < 0 || CapacityLeftInEnergySource > 2.6f)
                    {
                        throw new ValueOutOfRangeException("The inserted value is out of range.", 0, 2.6f);
                    }
                }

                else if(energySourceType == eEnergySourceType.Fuel)
                {
                    if(CapacityLeftInEnergySource < 0 || CapacityLeftInEnergySource > 6.4f)
                    {
                        throw new ValueOutOfRangeException("The inserted value is out of range.", 0, 6.4f);

                    }
                }
                
                newVehicle = getMotorcycleDetailsAndCreateMotorcycle(i_VehicleLicenseNumber, energySourceType, CapacityLeftInEnergySource, currentWheelAirPressure, vehicleModel);
            }

            else //car
            {
                energySourceType = (eEnergySourceType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eEnergySourceType));
                CapacityLeftInEnergySource = float.Parse(UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please enter the current amount of energy in the vehicle: ", Environment.NewLine)));
                if(energySourceType == eEnergySourceType.Electric)
                {
                    if(CapacityLeftInEnergySource < 0 || CapacityLeftInEnergySource > 5.2f)
                    {
                        throw new ValueOutOfRangeException("The inserted value is out of range.", 0, 5.2f);

                    }
                }

                else if(energySourceType == eEnergySourceType.Fuel)
                {
                    if(CapacityLeftInEnergySource < 0 || CapacityLeftInEnergySource > 46f)
                    {
                        throw new ValueOutOfRangeException("The inserted value is out of range.", 0, 46f);
                    }
                }

                newVehicle = getCarDetailsAndCreateCar(i_VehicleLicenseNumber, energySourceType, CapacityLeftInEnergySource, currentWheelAirPressure, vehicleModel);
            }

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

            newVehicle.ProduceAndAddWheel(UIInputsOutputsMessages.GetWheelManufacturerMsg(), newVehicle.MaxWheelAirPressure, currentWheelAirPressure);
            UIInputsOutputsMessages.GetOwnerDetails(out ownerName, out ownerPhoneNumber);
            newVehicle.SetVehicleOwnerInfo(ownerName, ownerPhoneNumber);
            while (isValidInput == false)
            {
                try
                {
                    newVehicle.setCapacityLeftInEnergySource(CapacityLeftInEnergySource);
                    newVehicle.VehicleEnergySource.SetEnergyPrecentage(newVehicle.VehicleEnergySource.MaxEnergySourceCapacity, CapacityLeftInEnergySource);
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
                UIInputsOutputsMessages.VehicleIsNotInGarageMsg();
            }

            else
            {
                eVehicleStatusInGarage newVehicleStatus = (eVehicleStatusInGarage)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eVehicleStatusInGarage));
                m_Garage.UpdateVehicleStatus(vehicleLicenseNumber, newVehicleStatus);
                UIInputsOutputsMessages.RequestSucceededMsg();
            }

        }

        private void inflatingWheelsToMaxAirPressure()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber) == false)
            {
                UIInputsOutputsMessages.VehicleIsNotInGarageMsg();
            }

            else
            {
                m_Garage.InflateWheelsAirPressureToMax(vehicleLicenseNumber);
                UIInputsOutputsMessages.RequestSucceededMsg();
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
                UIInputsOutputsMessages.VehicleIsNotInGarageMsg();
            }

            else
            {

                Vehicle vehicle = m_Garage.GetVehicleByLicenseNumber(vehicleLicenseNumber);           
                vehicleEnergySourceType = vehicle.VehicleEnergySource.GetType();
                
                if (vehicleEnergySourceType != i_energySourceType)
                {
                    UIInputsOutputsMessages.UnMatchEnergySourceForVehicleMsg();
                }

                else
                {
                    if (i_energySourceType == typeof(FuelSource))
                    {
                        while ((eFuelType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eFuelType)) != (vehicle.VehicleEnergySource as FuelSource).FuelType)
                        {
                            UIInputsOutputsMessages.UnMatchFuelForVehicleMsg();
                        }
                    }

                    while (isValidInput == false)
                    {
                        try
                        {
                            if (i_energySourceType == typeof(FuelSource))
                            {
                                CapacityOfEnergySourceToAdd = UIInputsOutputsMessages.GetAmountOfFuelToAdd();                  
                                vehicle.VehicleEnergySource.RenewAmountOfEnergy(CapacityOfEnergySourceToAdd);
                                vehicle.VehicleEnergySource.SetEnergyPrecentage(vehicle.VehicleEnergySource.MaxEnergySourceCapacity, vehicle.VehicleEnergySource.CapacityLeftInEnergySource);

                            }

                            else
                            {
                                CapacityOfEnergySourceToAdd = UIInputsOutputsMessages.GetNumOfMinutesToCharge();
                                vehicle.VehicleEnergySource.RenewAmountOfEnergy(CapacityOfEnergySourceToAdd);
                                vehicle.VehicleEnergySource.SetEnergyPrecentage(vehicle.VehicleEnergySource.MaxEnergySourceCapacity, vehicle.VehicleEnergySource.CapacityLeftInEnergySource);
                            }

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

                    UIInputsOutputsMessages.RequestSucceededMsg();
                }
            }
        }

        private Vehicle getMotorcycleDetailsAndCreateMotorcycle(string i_MotorCycleLicense, eEnergySourceType i_EnergySourceType, float i_AmountOfEnergySource, float i_AmountOfAirPressure, string i_ModelName)
        {
            int engineCapacity = 0;
            bool isEnginCapacityValid = false;
            string motorcycleUniqueProperties;
            eLicenseType licenseType = (eLicenseType)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eLicenseType));

            while (!isEnginCapacityValid)
            {
                motorcycleUniqueProperties = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}Please insert the capacity of the Motorcycle engine: ", Environment.NewLine));
                isEnginCapacityValid = int.TryParse(motorcycleUniqueProperties, out engineCapacity);            
            }

            Vehicle MotorCycle = Garage.ProduceMotorcycle(i_EnergySourceType, i_AmountOfEnergySource, i_ModelName, i_MotorCycleLicense, licenseType, engineCapacity);

            return MotorCycle;
        }

        private Vehicle getTruckDetailsAndCreateTruck(string i_TruckLicense, eEnergySourceType i_EnergySourceType, float i_AmountOfEnergySource, string i_ModelName)
        {
            bool v_isTransportHazardMaterials = false;
            bool n_IsValidInput = false;
            float cargoCapacity = 0;

            while (!n_IsValidInput)
            {
                string isTransportHazardMaterialsString = UIInputsOutputsMessages.getInputFromUser(string.Format("{0}If the truck able to transoprt hazard materials press: 'y' , else press 'n': ", Environment.NewLine));
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
            eCarColor chosenCarColor = (eCarColor)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eCarColor));
            eAmountOfDoors numberOfCarDoors = (eAmountOfDoors)UIInputsOutputsMessages.GetEnumOptionFromUser(typeof(eAmountOfDoors));
            Vehicle Car = Garage.ProduceCar(i_EnergySourceType, i_AmountOfEnergySource, i_ModelName, i_TruckLicense, numberOfCarDoors, chosenCarColor);

            return Car;
        }

        private void displayLicenseNumberListOfVehiclesInGarage()
        {
            string inputOptionFromUser = UIInputsOutputsMessages.GetUserInputStatusOptionChoiceForDisplayingListOfVehiclesLicenseNumbers();
            Dictionary<string, Vehicle> VehiclesInGarage = m_Garage.VehiclesList;

            if (int.Parse(inputOptionFromUser) >= 0 && int.Parse(inputOptionFromUser) <= 3)
            {
                if (inputOptionFromUser != "3")
                {//print lis tby status
                    eVehicleStatusInGarage VehicleStatus = (eVehicleStatusInGarage)int.Parse(inputOptionFromUser);
                    if (m_Garage.IsVehicleInGarageListInChosenStatusIsEmpty(VehicleStatus))
                    {
                        UIInputsOutputsMessages.ThereIsNoVehiclesInThisStatusMsg();
                    }

                    else
                    {
                        if (m_Garage.IsVehicleInGarageListEmpty())
                        {
                            UIInputsOutputsMessages.ThereIsNoVehiclesInTheGarageMsg();
                        }

                        else
                        {
                            foreach (KeyValuePair<string, Vehicle> vehicle in VehiclesInGarage)
                            {
                                if (vehicle.Value.VehicleStatusInGarage.Equals(VehicleStatus))
                                {
                                    UIInputsOutputsMessages.VehicleLicenseNumberMsg(vehicle.Key);
                                }
                            }
                        }
                    }
                }

                else
                {//print whole list
                    foreach (KeyValuePair<string, Vehicle> vehicle in VehiclesInGarage)
                    {
                        UIInputsOutputsMessages.VehicleLicenseNumberMsg(vehicle.Key);
                    }
                }
            }

            else
            {
                throw new ValueOutOfRangeException("Input must be between 0 to 3", 0, 3);
            }

            UIInputsOutputsMessages.PressAnyKeyToContinue();
        }

        private void displayVehicleDetailsByLicenseNumber()
        {
            string vehicleLicenseNumber = UIInputsOutputsMessages.GetVehicleLicenseNumberFromUser();

            if (m_Garage.IsVehicleExistsInGarage(vehicleLicenseNumber) == false)
            {
                UIInputsOutputsMessages.ThereIsNoVehiclesInTheGarageMsg();
            }

            else
            {
                Vehicle vehicle = m_Garage.GetVehicleByLicenseNumber(vehicleLicenseNumber);
                UIInputsOutputsMessages.DisplayVehicleDetails(vehicle);
            }

            UIInputsOutputsMessages.PressAnyKeyToContinue();
        }
    }
}
