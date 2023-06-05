using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_EnergyLeftInPercentage;
        protected readonly float m_MaxEnergySourceCapacity;
        protected float m_CapacityLeftInEnergySource;

        protected EnergySource(float i_MaxEnergySourceCapacity, float i_CapacityLeftInEnergySource)
        {
            m_MaxEnergySourceCapacity = i_MaxEnergySourceCapacity;
            SetEnergyPrecentage(i_MaxEnergySourceCapacity, i_CapacityLeftInEnergySource);
            m_CapacityLeftInEnergySource = i_CapacityLeftInEnergySource;
        }

        public float CapacityLeftInEnergySource
        {
            get
            {
                return m_CapacityLeftInEnergySource;
            }
            set
            {
                m_CapacityLeftInEnergySource = value;
            }
        }

        public float EnergyLeftInPercentage
        {
            get
            {
                return m_EnergyLeftInPercentage;
            }

            set
            {
                m_EnergyLeftInPercentage = value;
            }
        }

        public float MaxEnergySourceCapacity
        {
            get
            {
                return m_MaxEnergySourceCapacity;
            }
        }

        public void SetEnergyPrecentage(float i_MaxEnergySourceCapacity, float i_CapacityLeftInEnergySource)
        {
            m_EnergyLeftInPercentage = (i_CapacityLeftInEnergySource / i_MaxEnergySourceCapacity) * 100;
        }

        public void RenewAmountOfEnergy(float i_EnergySourceToAdd)
        {
            if ((m_CapacityLeftInEnergySource + i_EnergySourceToAdd) > m_MaxEnergySourceCapacity || i_EnergySourceToAdd < 0)
            {
                throw new ValueOutOfRangeException("Invalid input. The value after addition is out of range.", 0, m_MaxEnergySourceCapacity);
            }

            else
            {
                m_CapacityLeftInEnergySource = m_CapacityLeftInEnergySource + i_EnergySourceToAdd;
            }
        }
    }
}