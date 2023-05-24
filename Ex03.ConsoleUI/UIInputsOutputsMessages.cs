using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    
    class UIInputsOutputsMessages
    {
        private const int k_MinValue = 0;

        //print menu
        public const string k_SelectOptionFromMenuMsg = "Please select one of the options behind(a number between 1 to 8):";
        public const string k_TheVehicleIsAlreadyInTheGarageMsg = "This vehicle is already exists in the garage.";

        public const int k_MinMenuOptionValue = 1;
        public const int k_MaxMenuOptionValue = 8;

        public static void PrintGarageMenuOptions()
        {
            Console.Clear();
            Console.WriteLine(string.Format(
@"
Welcome to the Garage system!

------------------------------------------------------------------------
Please select one of the options behind (a number between 1 to 8):
 
1. Insert new vehicle to the garage.
2. Display the list of vehicles license numbers in the garage.
3. Change vehicle status.
4. Inflate wheels to maximum air pressure.
5. Refuel vehicle.
6. Charge electric vehicle.
7. Display vehicle details by license number.
8. Exit.
------------------------------------------------------------------------"));
        }

        public static int GetInputChoiceFromUser(int i_MinInputRangeValue, int i_MaxInputRangeValue)
        {
            int convertedUserInputChoice;
            string userChoiceInput = getInputFromUser("Please Insert your input choice:");
            bool v_isValidInput = int.TryParse(userChoiceInput, out convertedUserInputChoice);

            if (v_isValidInput)
            {
                v_isValidInput = isInputInRange(i_MinInputRangeValue, i_MaxInputRangeValue, convertedUserInputChoice);//depends on the current enum input choice

                if (!v_isValidInput)
                {
                    throw new ValueOutOfRangeException("The inserted value is out of range.", i_MinInputRangeValue, i_MaxInputRangeValue);
                }
            }

            else
            {
                throw new FormatException("Invalid input choice format.");
            }

            return convertedUserInputChoice;
        }

        /*
        public static int GetMenuOptionChoiceFromUser()
        {
            int convertedUserInputChoice;
            string userChoiceInput = getInputFromUser(k_SelectOptionFromMenuMsg);
            bool v_isValidInput = int.TryParse(userChoiceInput, out convertedUserInputChoice);

            if (v_isValidInput)
            {
                v_isValidInput = isInputInRange(k_MinMenuOptionValue, k_MaxMenuOptionValue, convertedUserInputChoice);//1,8 , convertedInput

                if (!v_isValidInput)
                {
                    throw new ValueOutOfRangeException("The inserted value is out of range", k_MinMenuOptionValue, k_MaxMenuOptionValue);
                }
            }

            else
            {
                throw new FormatException("Invalid choice format.");
            }

            return convertedUserInputChoice;
        }
    */

        public static string getInputFromUser(string i_RequestMsg)
        {
            string userInput;

            Console.Write(i_RequestMsg);
            userInput = Console.ReadLine();

            return userInput;
        }

        private static bool isInputInRange(float i_MinInputRangeValue, float i_MaxInputRangeValue, float i_Input)
        {
            bool v_isInputInRange = false;

            if (i_Input >= i_MinInputRangeValue && i_Input <= i_MaxInputRangeValue)
            {
                v_isInputInRange = true;
            }

            return v_isInputInRange;
        }

        public static string GetVehicleLicenseNumberFromUser()
        {
            string userInput;

            userInput = getInputFromUser(string.Format("{0}Please enter the license number of the vehicle you wish to insert into the garage:", Environment.NewLine));

            return userInput;
        }

        public static void PrintMessage(string i_MsgToPrint)
        {
            Console.WriteLine(i_MsgToPrint);
        }

        public static string GetVehicleModelFromUser()
        {
            string userInput;

            userInput = getInputFromUser(string.Format("{0}Please enter vehicle model name:", Environment.NewLine));

            return userInput;
        }

      

        public static Enum GetEnumOptionFromUser(Type i_EnumType)
        {
            int userChoice = 0;
            bool v_isValidInput = false;
            string enumName = i_EnumType.Name;
            string nameOfEnumMember;
            int enumLength = Enum.GetValues(i_EnumType).Length;

            Console.WriteLine(string.Format("{0}{1}: ", Environment.NewLine, enumName.Remove(0, 1)));
            for (int valueOfEnumMember = 0; valueOfEnumMember < enumLength; valueOfEnumMember++)
            {
                nameOfEnumMember = Enum.GetName(i_EnumType, valueOfEnumMember);
                Console.Write(string.Format(@"{0}) {1}{2}", valueOfEnumMember, nameOfEnumMember, Environment.NewLine));
            }

            while (!v_isValidInput)
            {
                try
                {
                    userChoice = GetInputChoiceFromUser(0, enumLength - 1);//GetMenuOptionChoiceFromUser(); //GetChoiceFromUser(0, enumLength - 1);
                    v_isValidInput = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    v_isValidInput = false;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    v_isValidInput = false;
                }
            }

            return (Enum)Enum.GetValues(i_EnumType).GetValue(userChoice);
        }

      

        public static void PrintVehicleIsNotInGarage()
        {
            Console.WriteLine("The vehicle is not in the garage");
        }

        public static void PrintRequestCompleted()
        {
            Console.WriteLine("Your request was completed successfully");
        }

        public static void PrintUnMatchEnergySourceForVehicle()
        {
            Console.WriteLine("The energy source you entered is not match to the vehicle energy source");
        }

        public static void PrintUnMatchFuelForVehicle()
        {
            Console.WriteLine("The fuel type you entered is not matched to the fuel type in the vehicle");
        }
        public static float GetAmountOfFuelToAdd()
        {
            float amountOfFuelToAdd = 0;
            string amountOfFuelFromUser = getInputFromUser(string.Format("{0}Please insert the amount of fueal you want to add in Liters: ", Environment.NewLine));

            if(float.TryParse(amountOfFuelFromUser, out amountOfFuelToAdd)== false)
            {
                throw new FormatException("Invalid fuel amount format!");
            }

            return amountOfFuelToAdd;
        }

        public static float GetNumOfMinutesToCharge()
        {
            float numOfHoursToCharge = 0;
            string numOfHoursToChargeInput = getInputFromUser(string.Format("{0}Please insert number of hours to charge in the vehicle: ", Environment.NewLine));

            if(float.TryParse(numOfHoursToChargeInput, out numOfHoursToCharge) ==false)
            {
                throw new FormatException("Invalid minuts to charge format!");
            }

            return numOfHoursToCharge;
        }

        public static string GetWheelManufacture()
        {
            return getInputFromUser(string.Format("{0}Please insert your wheel manufacture: ", Environment.NewLine));
        }

        public static float GetCurrentWheelAirPressure(float i_MaxWheelAirPressure)
        {
            float currenttAirPressure;
            string currenttAirPressureInput = getInputFromUser(string.Format("{0}Please insert current wheel Air pressure: ", Environment.NewLine));
            bool isValidAirPressure = float.TryParse(currenttAirPressureInput, out currenttAirPressure);

            if (isValidAirPressure == false)
            {
                throw new FormatException("Invalid input!");
            }
            else if (isInputInRange(k_MinValue, i_MaxWheelAirPressure, currenttAirPressure) == false)
            {
                throw new ValueOutOfRangeException("Value out of range", k_MinValue, i_MaxWheelAirPressure);
            }

            return currenttAirPressure;
        }

        public static void GetOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            o_OwnerName = getInputFromUser(string.Format("{0}Please insert owner name: ", Environment.NewLine));
            o_OwnerPhoneNumber = getInputFromUser(string.Format("{0}Please insert owner phone Number: ", Environment.NewLine));
        }
    }
}