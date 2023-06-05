using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelCapacity;

        public FuelSource(eFuelType i_FuelType, float i_MaxFuelCapacity, float i_FuelLeftInLiters) : base(i_MaxFuelCapacity, i_FuelLeftInLiters)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float MaxFuelCapacity
        {
            get
            {
                return r_MaxFuelCapacity;
            }
        }
    }
}