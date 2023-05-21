using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        private readonly float r_MaxEletricCapacity;//private?
        private float m_TimeLeftInHours;//private?

        public ElectricSource(float i_MaxEletricCapacity, float i_TimeLeftInHours) : base(i_MaxEletricCapacity, i_TimeLeftInHours)
        {
            r_MaxEletricCapacity = i_MaxEletricCapacity;
            m_TimeLeftInHours = i_TimeLeftInHours;
        }

        public float MaxEletricCapacity
        {
            get
            {
                return r_MaxEletricCapacity;
            }
            //no set cus readonly
        }

        public float TimeLeftInHours
        {
            get
            {
                return m_TimeLeftInHours;
            }
            set
            {
                m_TimeLeftInHours = value;
            }
        }

        public override void RenewAmountOfEnergy(float i_TimeToAddInHours)
        {
            // Implement the renewal logic for FuelSource
            Console.WriteLine("Renewing Electric energy.");

            //input tests and exception throws
        }
        //CHECK ABOUT THE EXCEPTIONS!
        public override void RenewAmountOfEnergy()//check if neccesery and place in the right class (maybe Exceptions class)
        {
            throw new NotImplementedException();
        }

        public override void RenewAmountOfEnergy(eFuelType i_FuelType, float i_FuelToAddInLiters)//check if neccesery and place in the right class (maybe Exceptions class)
        {
            throw new NotImplementedException();
        }
    }
}