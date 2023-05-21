using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_AmountOfEnergyLeftInPercentage; // protected?
        public abstract void RenewAmountOfEnergy();
        public abstract void RenewAmountOfEnergy(eFuelType i_FuelType, float i_FuelToAddInLiters);
        public abstract void RenewAmountOfEnergy(float i_TimeToAddInHours);

        // protected readonly float m_MaxAmountOfEnergySource;
        // protected float m_CurrentAmountOfEnergySource;
        //  private const int k_MinAmountOfEnergySource = 0;

        protected EnergySource(float i_MaxAmountOfEnergySource, float i_CapacityLeftInEnergySource)
        {
            m_AmountOfEnergyLeftInPercentage = (i_CapacityLeftInEnergySource / i_MaxAmountOfEnergySource) * 100;
        }

        public float AmountOfEnergyLeftInPercentage
        {
            get
            {
                return m_AmountOfEnergyLeftInPercentage;
            }

            set
            {
                m_AmountOfEnergyLeftInPercentage = value;
            }
        }

        /* public void ChargeOrRefuelVehicle(float i_AmountToCharge)
         {
             if (i_AmountToCharge < 0)
             {
                 throw new ValueOutOfRangeException("Error, The entered energy source number is negative.", k_MinAmountOfEnergySource, m_MaxAmountOfEnergySource);
             }
             else if (i_AmountToCharge + m_CurrentAmountOfEnergySource > m_MaxAmountOfEnergySource)
             {
                 throw new ValueOutOfRangeException("Error, The addition amount you wish to add is more then allowed.", k_MinAmountOfEnergySource, m_MaxAmountOfEnergySource);
             }
             else
             {
                 m_CurrentAmountOfEnergySource += i_AmountToCharge;
             }
         }
         */
    }
}