using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        /////////////////////  // $G$ DSN-999 (-2) The "fuel type" field should be readonly member of class FuelEnergyProvider.
        private readonly eFuelType r_FuelType;//add eFuelType enum
        private readonly float r_MaxFuelCapacity;//private?
        private float m_FuelLeftInLiters;//private?

        public FuelSource(eFuelType i_FuelType, float i_MaxFuelCapacity, float i_FuelLeftInLiters) : base(i_MaxFuelCapacity, i_FuelLeftInLiters)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
            m_FuelLeftInLiters = i_FuelLeftInLiters;
        }

        public float MaxFuelCapacity
        {
            get
            {
                return r_MaxFuelCapacity;
            }
            //no set cus readonly
        }

        public float FuelLeftInLiters
        {
            get
            {
                return m_FuelLeftInLiters;
            }
            set
            {
                m_FuelLeftInLiters = value;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }

            /*  set
              {
                  r_FuelType = value;
              }*/
        }

        public override void RenewAmountOfEnergy(eFuelType i_FuelType, float i_FuelToAddInLiters)
        {
           if(i_FuelType==this.FuelType)
           {
                if((m_FuelLeftInLiters + i_FuelToAddInLiters)>MaxFuelCapacity)
                {
                    //throw ValueOutOfRangeException("The amount of liters after adding the amount of fuel you wanted is higher from the maximum", 0, r_MaxFuelCapacity);
                }
                else
                {
                    m_FuelLeftInLiters += i_FuelToAddInLiters;
                }
           }

           else
            {
                //throw exeption "Fuel type not the same"
            }

        }

        //CHECK ABOUT THE EXCEPTIONS!
        public override void RenewAmountOfEnergy(float i_FuelToAddInLiters)//check if neccesery and place in the right class (maybe Exceptions class)
        {
            throw new NotImplementedException();
        }

        public override void RenewAmountOfEnergy()//check if neccesery and place in the right class (maybe Exceptions class)
        {
            throw new NotImplementedException();
        }
    }
}