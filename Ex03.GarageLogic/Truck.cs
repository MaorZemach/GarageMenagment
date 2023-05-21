﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_WheelsNumber = 14;
        private const float k_WheelMaxAirPressure = 26f;
        private const float k_FuelTankCapacityInLiters = 135f; 
        private readonly eFuelType r_FuelType; 
        private bool v_IsTransoprtHazardousMaterials;
        private float m_CargoCapacity;

        public Truck(string i_ModelName, string i_LicensingNumber, bool i_IsTransoprtHazardousMaterials, float i_CargoCapacity)
            :base(i_ModelName, i_LicensingNumber, k_WheelsNumber)
        {
            v_IsTransoprtHazardousMaterials = i_IsTransoprtHazardousMaterials;
            m_CargoCapacity = i_CargoCapacity;
            r_FuelType = eFuelType.Soler;
        }

        public eFuelType TruckFuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public  bool IsTransoprtHazardousMaterials
        {
            get
            {
                return v_IsTransoprtHazardousMaterials;
            }
            set
            {
                v_IsTransoprtHazardousMaterials = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }
            set
            {
                m_CargoCapacity = value;
            }
        }

        public override void CreateEnergySource(eEnergySourceType i_EnergySourceType, float i_CurrentEnergyInVehicle)
        {             
                m_FuelSource = new FuelSource(r_FuelType, k_FuelTankCapacityInLiters, i_CurrentEnergyInVehicle);         
        }
    }
}