using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    internal static class StartCalcualtor
    {
        public static void CalculateStartSResources() 
        {
            foreach(var province in PaxApocalyticaGame.Dictionary_NameSFactory.Keys) 
            {
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                PaxApocalyticaGame.Dictionary_NameSFactory[province].Produce(PaxApocalyticaGame.Dictionary_NameOwner[province]);
            }
            foreach(var country in PaxApocalyticaGame.Dictionary_CountrynameSimpleResources.Keys) 
            {
                Random random = new Random();
                if (country == "China" || country == "USA" || country == "Germany" || country == "Russia" || country == "France" || country == "Turkey")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] += random.Next(40, 80);
                    }
                }
                else if (country == "Kazakh ASSR")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] += random.Next(30, 60);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] == 0)
                        {
                            PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] = random.Next(20, 40);
                        }
                    }
                    for (int i = 4; i < 10; i++)
                    {
                        if (PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] == 0)
                        {
                            PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][i] = random.Next(20, 40);
                        }
                    }
                }
            }
        }
        public static void CalculateStartMResources()
        {
            foreach (var province in PaxApocalyticaGame.Dictionary_NameMFactory.Keys)
            {
                if (PaxApocalyticaGame.Dictionary_NameMFactory[province] != null)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory[province].Produce_Start(PaxApocalyticaGame.Dictionary_NameOwner[province]);
                    }
                }
            }

            foreach(var country in PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources.Keys) 
            {
                if (PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.Soviet)
                {
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][1] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][1] = 400; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][5] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][5] = 600; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][9] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][9] = 40; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][10] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][10] = 30; }
                }
                if (PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.NATO)
                {
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][11] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][11] = 200; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][15] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][15] = 400; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][17] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][17] = 40; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][18] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][18] = 20; }
                }
                if (PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup == FactoriesAndResources.MilitaryFactoryType.Type.Generic)
                {
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][19] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][19] = 200; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][23] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][23] = 400; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][25] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][25] = 30; }
                    if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][26] == 0) { PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][26] = 20; }
                }
            }
        }
        public static void CalculateStartCash() 
        {
            foreach(var province in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys) 
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[province]].Cash 
                    += PaxApocalyticaGame.Dictionary_NameCharacteristics[province].GetTaxes();
            }
        }
        public static void CalculateStartManpower()
        {
            foreach (var province in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[province]].Manpower
                    += PaxApocalyticaGame.Dictionary_NameCharacteristics[province].Manpower;
            }
        }
    }

    internal static class Calculator
    {
        public static int CalculateMaintanenceCost() 
        {
            return 0;
        }
        public static void RecalculateMaxImport()
        {
            foreach (var province in PaxApocalyticaGame.Dictionary_NameAirfield.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOccupant[province]].MaxImport
                    += PaxApocalyticaGame.Dictionary_NameAirfield[province].Planes.Length;
            }
            foreach (var province in PaxApocalyticaGame.Dictionary_NamePort.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOccupant[province]].MaxImport
                    += PaxApocalyticaGame.Dictionary_NamePort[province];
            }
        }
        public static void RecalcualteManpower() 
        {
            foreach (var country in PaxApocalyticaGame.Dictionary_CountrynameCharacteristics.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower = 0;
            }
            foreach (var province in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[province]].Manpower
                    += PaxApocalyticaGame.Dictionary_NameCharacteristics[province].Manpower;
            }
        }
        public static void RecalcualteCash()
        {
            foreach (var province in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys)
            {
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[province]].Cash
                    += PaxApocalyticaGame.Dictionary_NameCharacteristics[province].GetTaxes();
            }

        }
        public static void RecalculateCanBuildUnit(string country) 
        {
            //infantry
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower>=10000) 
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][0] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][0] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][5] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][1] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][1] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][6] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][2] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][2] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][15] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][3] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][3] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][16] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][4] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][4] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][23] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][5] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][5] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][24] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][6] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][6] = false; }

            //vdv
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][7] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][26] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][26] = false; }
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][8] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][27] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][27] = false;
            }

            //tanks
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][1] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][7] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][7] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][2] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][8] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][8] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][3] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][9] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][9] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][4] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][10] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][10] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][11] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][11] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][11] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][12] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][12] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][12] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][13] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][13] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][13] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][14] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][14] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][14] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][19] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][15] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][15] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][20] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][16] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][16] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][21] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][17] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][17] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0] >= 10
                && PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][22] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 10000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][18] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][18] = false;
            }

            //fighters
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][9] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][22] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][22] = false; }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][17] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][23] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][23] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][25] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][24] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][24] = false; }

            //strike aircrafts
            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][10] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][19] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][19] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][18] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][20] = true; }
            else
            {
                PaxApocalyticaGame.Dictionary_CanBuildUnit[country][20] = false;
            }

            if (PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][26] >= 50
                && PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Manpower >= 5000)
            { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][21] = true; }
            else { PaxApocalyticaGame.Dictionary_CanBuildUnit[country][21] = false; }
        }
        public static void RecalculateIsFunctioning() 
        {
            foreach(var provinve in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys) 
            {
                ulong populInProv = PaxApocalyticaGame.Dictionary_NameCharacteristics[provinve].Population;
                if (populInProv < 20000) { PaxApocalyticaGame.Dictionary_NameMFactory[provinve].IsFunctioning = false; }
                else { PaxApocalyticaGame.Dictionary_NameMFactory[provinve].IsFunctioning = true; }
                if (populInProv < 10000) { PaxApocalyticaGame.Dictionary_NameSFactory[provinve].IsFunctioning = false; }
                else { PaxApocalyticaGame.Dictionary_NameSFactory[provinve].IsFunctioning = true; }
            }        
        }
    }
}
