using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        private readonly float r_MaxBatteryCapacity;

        public ElectricSource(float i_MaxBatteryCapacity, float i_BatteryTimeLeftInHours) : base(i_MaxBatteryCapacity, i_BatteryTimeLeftInHours)
        {
            r_MaxBatteryCapacity = i_MaxBatteryCapacity;
        }

        public float MaxEletricCapacity
        {
            get
            {
                return r_MaxBatteryCapacity;
            }
        }
    }
}