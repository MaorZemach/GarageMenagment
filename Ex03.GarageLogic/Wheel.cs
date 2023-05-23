using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{//test
    class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ManufactureName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_ManufacturerName = i_ManufactureName;
            r_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void InflateWheelAirPressure(float i_AirToAdd)
        {
            //check if not past the maximum
            if((m_CurrentAirPressure+i_AirToAdd) <= Car.k_WheelMaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            //else throw exepction.
        }
        public void InflateWheelToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }
    }
}
