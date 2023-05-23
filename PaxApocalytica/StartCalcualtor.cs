using PaxApocalytica.FactoriesAndResources;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    internal static class StartCalcualtor
    {
        public static void CalculateStartSResources()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameSFactory.Keys)
            {
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                PaxApocalypticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
            }
            foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources.Keys)
            {
                Random random = new Random();
                if (country == "China" || country == "USA" || country == "Germany" || country == "Russia" || country == "France" || country == "Turkey")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] += random.Next(40, 80);
                    }
                }
                else if (country == "Kazakh ASSR")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] += random.Next(30, 60);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] == 0)
                        {
                            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] = random.Next(20, 40);
                        }
                    }
                    for (int i = 4; i < 10; i++)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] == 0)
                        {
                            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][i] = random.Next(20, 40);
                        }
                    }
                }
            }
        }
        public static void CalculateStartMResources()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameMFactory.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_NameMFactory[province] != null)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory[province].Produce_Start(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                    }
                }
            }

            foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.Soviet)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1] = 400; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5] = 600; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][9] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][9] = 40; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][10] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][10] = 30; }
                }
                if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.NATO)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11] = 200; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15] = 400; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][17] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][17] = 40; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][18] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][18] = 20; }
                }
                if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.Generic)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19] = 200; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23] = 400; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][25] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][25] = 30; }
                    if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][26] == 0) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][26] = 20; }
                }
            }
        }
        public static void CalculateStartCash()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[province]].Cash
                    += PaxApocalypticaGame.Dictionary_NameCharacteristics[province].GetTaxes();
            }
        }
        public static void CalculateStartManpower()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[province]].Manpower
                    += PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Manpower;
            }
        }
    }

    internal static class Calculator
    {
        public static int CalculateMaintanenceCost()
        {
            return 0;
        }
        public static void RecalculateTradeSlots()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameAirfield.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOccupant[province]].MaxTradeSlots
                    += PaxApocalypticaGame.Dictionary_NameAirfield[province].Planes.Length;
            }
            foreach (var province in PaxApocalypticaGame.Dictionary_NamePort.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOccupant[province]].MaxTradeSlots
                    += PaxApocalypticaGame.Dictionary_NamePort[province];
            }
        }
        public static void RecalcualteManpower()
        {
            foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower = 0;
            }
            foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[province]].Manpower
                    += PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Manpower;
            }
        }
        public static void RecalcualteCash()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[province]].Cash
                    += PaxApocalypticaGame.Dictionary_NameCharacteristics[province].GetTaxes();
            }

        }
        public static void RecalculateCanBuildUnit(string country)
        {
            //infantry
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][0] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][0] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][1] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][1] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][6] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][2] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][2] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][3] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][3] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][16] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][4] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][4] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][5] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][5] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][24] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][6] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][6] = false; }

            //vdv
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][7] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][25] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][25] = false; }
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][8] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][26] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][26] = false;
            }

            //tanks
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][7] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][7] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][2] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][8] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][8] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][3] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][9] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][9] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][4] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][10] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][10] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][11] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][11] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][12] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][12] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][12] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][13] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][13] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][13] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][14] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][14] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][14] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][15] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][15] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][20] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][16] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][16] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][21] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][17] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][17] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][22] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][18] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][18] = false;
            }

            //fighters
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][9] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][22] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][22] = false; }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][17] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][23] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][23] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][25] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][24] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][24] = false; }

            //strike aircrafts
            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][10] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][19] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][19] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][18] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][20] = true; }
            else
            {
                PaxApocalypticaGame.Dictionary_CanBuildUnit[country][20] = false;
            }

            if (PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][26] >= 50
                && PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][21] = true; }
            else { PaxApocalypticaGame.Dictionary_CanBuildUnit[country][21] = false; }
        }
        public static void RecalculateIsFunctioning()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
            {
                ulong populInProv = PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Population;
                if (PaxApocalypticaGame.Dictionary_NameMFactory[province] != null)
                {
                    if (populInProv < 20000) { PaxApocalypticaGame.Dictionary_NameMFactory[province].IsFunctioning = false; }
                    else { PaxApocalypticaGame.Dictionary_NameMFactory[province].IsFunctioning = true; }
                }
                if (populInProv < 10000) { PaxApocalypticaGame.Dictionary_NameSFactory[province].IsFunctioning = false; }
                else { PaxApocalypticaGame.Dictionary_NameSFactory[province].IsFunctioning = true; }
            }
        }
        public static int CalculateMovingCost(string armyName)
        {
            int moveCost = 0;
            foreach (var unit in PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units)
            {
                if (unit.Name == Military.UnitName.Name.unmotorizedInfantry) { }
                else if (unit.Name == Military.UnitName.Name.infantry1r) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.infantry2r) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.infantry1a) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.infantry2a) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.infantry1g) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.infantry2g) { moveCost++; }
                else if (unit.Name == Military.UnitName.Name.tank1r) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank2r) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank3r) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank4r) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank1a) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank2a) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank3a) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank4a) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank1g) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank2g) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank3g) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.tank4g) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.vdv1) { moveCost += 2; }
                else if (unit.Name == Military.UnitName.Name.vdv2) { moveCost += 2; }
            }
            return moveCost;
        }

        public static void ChangeSResources()
        {

        }

        public static void ChangeMResources()
        {
            foreach (var province in PaxApocalypticaGame.Dictionary_NameMFactory.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_NameMFactory[province] != null)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory[province].Produce(PaxApocalypticaGame.Dictionary_NameOwner[province]);
                    }
                }
            }
        }

        public static void ChangeMResources(string sender, string receiver, MilitaryResources.Names mRName, int count)
        {

        }

        public static void CheckTradeLimitExceed()
        {
            foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade.Keys)
            {
                int sum = 0;
                foreach (var num in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country])
                {
                    if (num < 0) { sum -= num; }
                    else { sum += num; }
                }
                if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].MaxTradeSlots)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade_ReduceTrade.Add(country, sum - PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].MaxTradeSlots);
                }
            }
        }

        public static int CalculateTradeIncome()
        {
            int sum = 0; foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade.Keys)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 80;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 240; }
                    }
                    else if (i == 1)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 40;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 120; }
                    }
                    else if (i == 2)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 50;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 150; }
                    }
                    else if (i == 3)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 200;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 600; }
                    }
                    else if (i == 4)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                    }
                    else if (i == 5)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 20;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60; }
                    }
                    else if (i == 6)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 25;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 75; }
                    }
                    else if (i == 7)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                    }
                    else if (i == 8)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 40;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 120; }
                    }
                    else if (i == 9)
                    {
                        if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                        {
                            sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                        }
                        else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                    }
                }
            }
            return sum;
        }
        public static int CalculateTradeIncome(string country)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 80;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 240; }
                }
                else if (i == 1)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 40;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 120; }
                }
                else if (i == 2)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 50;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 150; }
                }
                else if (i == 3)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 200;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 600; }
                }
                else if (i == 4)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                }
                else if (i == 5)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 20;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60; }
                }
                else if (i == 6)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 25;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 75; }
                }
                else if (i == 7)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                }
                else if (i == 8)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 40;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 120; }
                }
                else if (i == 9)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] > 0)
                    {
                        sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 60;
                    }
                    else { sum += PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][i] * 180; }
                }
            }
            return sum;
        }
    }
}
