using PaxApocalytica.FactoriesAndResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    public static class FileWriter
    {
        /*
            FileReader.ReadFile_NameOwner();                    //меняется  +
            FileReader.ReadFile_NameOccupant();                 //меняется  +
            FileReader.ReadFile_CountrynameCharacterstics();    //меняется  +
            FileReader.ReadFile_CountrynameMilResources();      //меняется  +
            FileReader.ReadFile_CountrynameSimpleResources();   //меняется  +           
            FileReader.ReadFile_NameAirfield();                 //меняется  +
            FileReader.ReadFile_NameSimpleFactory();            //меняется  +
            FileReader.ReadFile_NameMilitaryFactory();          //меняется  +
        army                                                    //меняется
        */

        public static void SaveEverything(string basePath) //almost everything
        {
            WriteFile_CountrynameCharacterstics(basePath); 
            WriteFile_CountrynameSimpleResources(basePath);
            WriteFile_CountrynameMilresources(basePath);
            WriteFile_NameOwner(basePath);
            WriteFile_NameOccupant(basePath);
            WriteFile_NameSimpleFactory(basePath);
            WriteFile_NameMilitaryFactory(basePath); 
            WriteFile_NameAirfield(basePath); 
            
            WriteFile_NameCharacteristics(basePath);
        }

        public static void WriteFile_NameAirfield(string basePath) 
        {
            string path = basePath + "Name_Airfield.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var airfield in PaxApocalyticaGame.Dictionary_NameAirfield.Keys)
                {
                    outputFile.Write(airfield + ";" + PaxApocalyticaGame.Dictionary_NameAirfield[airfield].Planes.Length);
                    foreach (var plane in PaxApocalyticaGame.Dictionary_NameAirfield[airfield].Planes) 
                    {
                        if (plane == null) { outputFile.Write(";"); }
                        else 
                        {
                            if(plane.Name == Military.UnitName.Name.fighterA) { outputFile.Write(";fighterA"); }
                            else if (plane.Name == Military.UnitName.Name.fighterG) { outputFile.Write(";fighterG"); }
                            else if (plane.Name == Military.UnitName.Name.fighterR) { outputFile.Write(";fighterR"); }
                            else if (plane.Name == Military.UnitName.Name.strikeAircraftA) { outputFile.Write(";strikeAircraftA"); }
                            else if (plane.Name == Military.UnitName.Name.strikeAircraftG) { outputFile.Write(";strikeAircraftG"); }
                            else if(plane.Name == Military.UnitName.Name.strikeAircraftR) { outputFile.Write(";strikeAircraftR"); }    
                            else { throw new ArgumentException(); }
                        }                        
                    }
                    outputFile.WriteLine();
                }
            }
        }
        public static void WriteFile_CountrynameCharacterstics(string basePath) 
        {
            string path = basePath + "Countryname_Characterstics.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var country in PaxApocalyticaGame.Dictionary_CountrynameCharacteristics.Keys)
                {
                    Color color = PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Color;
                    MilitaryFactoryType.Type type = PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup;
                    int cash = PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].Cash;
                    int dipka = PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].DiploPoints;
                    byte leaders = PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[country].MaxLeaders;
                    if (type == MilitaryFactoryType.Type.Soviet) { outputFile.WriteLine(country + ";" + color.R + "," + color.G + "," + color.B + ";" + "Soviet" + ";" + cash + ";" + dipka + ";" + leaders); }
                    else if (type == MilitaryFactoryType.Type.NATO) { outputFile.WriteLine(country + ";" + color.R + "," + color.G + "," + color.B + ";" + "NATO" + ";" + cash + ";" + dipka + ";" + leaders); }
                    else if (type == MilitaryFactoryType.Type.Generic) { outputFile.WriteLine(country + ";" + color.R + "," + color.G + "," + color.B + ";" + "Generic" + ";" + cash + ";" + dipka + ";" + leaders); }
                    else throw new ArgumentException();
                }
            }
        }
        public static void WriteFile_CountrynameSimpleResources(string basePath)
        {
            string path = basePath + "CountryName_SimpleResources.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var country in PaxApocalyticaGame.Dictionary_CountrynameSimpleResources.Keys)
                {
                    int Oil = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][0];
                    int Steel = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][1];
                    int Copper = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][2];
                    int Uranium = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][3];
                    int Coal = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][4];
                    int Grain = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][5];
                    int Livestock = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][6];
                    int Gas = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][7];
                    int Aluminium = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][8];
                    int Gold = PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[country][9];
                    outputFile.WriteLine(country+";"+Oil + ";" + Steel + ";" + Copper + ";" + Uranium + ";" + Coal + ";" +
                        Grain + ";" + Livestock + ";" + Gas + ";" + Aluminium + ";" + Gold );
                }
            }
        }
        public static void WriteFile_CountrynameMilresources(string basePath)
        {
            string path = basePath + "CountryName_MilitaryResources.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var country in PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources.Keys)
                {
                    int Weaponry = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][0];
                    int T72B = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][1];
                    int T90A = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][2];
                    int T90M = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][3];
                    int T14 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][4];
                    int BMP2 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][5];
                    int BMP3 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][6];
                    int BMD1 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][7];
                    int BMD2 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][8];
                    int FighterR = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][9];
                    int StrikeAircraftR = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][10];
                    int M1 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][11];
                    int M1A1 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][12];
                    int M1A2 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][13];
                    int M1A2C = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][14];
                    int M3A1 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][15];
                    int M3A3 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][16];
                    int FighterA = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][17];
                    int StrikeAircraftA = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][18];
                    int T55 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][19];
                    int T55M = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][20];
                    int T72A = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][21];
                    int T72M = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][22];
                    int BMP1 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][23];
                    int BMP23 = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][24];
                    int FighterG = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][25];
                    int StrikeAircraftG = PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[country][26];
                    outputFile.WriteLine(country + ";"+Weaponry + ";" + T72B + ";" +T90A + ";" +T90M + ";" +T14 + ";" + BMP2 + ";"
                        + BMP3 + ";" + BMD1 + ";" + BMD2 + ";" +FighterR + ";" +StrikeAircraftR + ";" + M1 + ";" +
                        M1A1 + ";" + M1A2 + ";" + M1A2C + ";" + M3A1 + ";" + M3A3 + ";" + FighterA + ";" + StrikeAircraftA + ";" +
                        T55 + ";" + T55M + ";" + T72A + ";" + T72M + ";" + BMP1 + ";" + BMP23 + ";" + FighterG + ";" + StrikeAircraftG);
                }
            }
        }
        public static void WriteFile_NameOwner(string basePath) 
        {
            string path = basePath + "Name_Owner.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalyticaGame.Dictionary_NameOwner.Keys)
                {
                    outputFile.WriteLine(province+";"+ PaxApocalyticaGame.Dictionary_NameOwner[province]);
                }
            }
        }
        public static void WriteFile_NameOccupant(string basePath)
        {
            string path = basePath + "Name_Occupant.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalyticaGame.Dictionary_NameOccupant.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalyticaGame.Dictionary_NameOccupant[province]);
                }
            }
        }

        public static void WriteFile_NameCharacteristics(string basePath)
        {
            string path = basePath + "Name_Characteristics.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalyticaGame.Dictionary_NameCharacteristics.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalyticaGame.Dictionary_NameCharacteristics[province].Population+";"
                        + PaxApocalyticaGame.Dictionary_NameCharacteristics[province].Eductaion +";"
                        + PaxApocalyticaGame.Dictionary_NameCharacteristics[province].Manpower+";"
                        + PaxApocalyticaGame.Dictionary_NameCharacteristics[province].EductaionEffort);
                }
            }
        }
        public static void WriteFile_NameSimpleFactory(string basePath)
        {
            string path = basePath + "Name_SimpleFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalyticaGame.Dictionary_NameSFactory.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalyticaGame.Dictionary_NameSFactory[province].ProducedRecourceName + ";" +
                        PaxApocalyticaGame.Dictionary_NameSFactory[province].TechnologyLevel + ";" +
                        PaxApocalyticaGame.Dictionary_NameSFactory[province].ExtensionLevel);
                }
            }
        }
        public static void WriteFile_NameMilitaryFactory(string basePath)
        {
            string path = basePath + "Name_MilitaryFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalyticaGame.Dictionary_NameMFactory.Keys)
                {
                    if (PaxApocalyticaGame.Dictionary_NameMFactory[province]==null) { outputFile.WriteLine(province + ";"); }
                    else 
                    {
                        outputFile.WriteLine(province.ToString() + ";" +
                            ConvertMResourceToString(PaxApocalyticaGame.Dictionary_NameMFactory[province].ProducedResourceName) + ";" +
                            PaxApocalyticaGame.Dictionary_NameMFactory[province].TechnologyLevel + ";" +
                            PaxApocalyticaGame.Dictionary_NameMFactory[province].ExtensionLevel); 
                    }
                }
            }
        }
        public static string ConvertSResourceToString(SimpleResources.Names resourceName) 
        {
            if (resourceName==SimpleResources.Names.Coal) { return "Coal"; }
            if (resourceName == SimpleResources.Names.Gold) { return "Gold"; }
            if (resourceName == SimpleResources.Names.Aluminium) { return "Aluminium"; }
            if (resourceName == SimpleResources.Names.Copper) { return "Copper"; }
            if (resourceName == SimpleResources.Names.Steel) { return "Steel"; }
            if (resourceName == SimpleResources.Names.Livestock) { return "Livestock"; }
            if (resourceName == SimpleResources.Names.Grain) { return "Grain"; }
            if (resourceName == SimpleResources.Names.Oil) { return "Oil"; }
            if (resourceName == SimpleResources.Names.Gas) { return "Gas"; }
            if (resourceName == SimpleResources.Names.Uranium) { return "Uranium"; }
            return null;
        }
        public static string ConvertMResourceToString(MilitaryResources.Names resourceName)
        {
            if (resourceName == MilitaryResources.Names.Weaponry) { return "Weaponry"; }
            if (resourceName == MilitaryResources.Names.T72B) { return "T72B"; }
            if (resourceName == MilitaryResources.Names.T90A) { return "T90A"; }
            if (resourceName == MilitaryResources.Names.T90M) { return "T90M"; }
            if (resourceName == MilitaryResources.Names.T14) { return "T14"; }
            if (resourceName == MilitaryResources.Names.BMP2) { return "BMP2"; }
            if (resourceName == MilitaryResources.Names.BMP3) { return "BMP3"; }
            if (resourceName == MilitaryResources.Names.BMD1) { return "BMD1"; }
            if (resourceName == MilitaryResources.Names.BMD2) { return "BMD2"; }
            if (resourceName == MilitaryResources.Names.FighterR) { return "FighterR"; }
            if (resourceName == MilitaryResources.Names.StrikeAircraftR) { return "StrikeAircraftR"; }
            if (resourceName == MilitaryResources.Names.M1) { return "M1"; }
            if (resourceName == MilitaryResources.Names.M1A1) { return "M1A1"; }
            if (resourceName == MilitaryResources.Names.M1A2) { return "M1A2"; }
            if (resourceName == MilitaryResources.Names.M1A2C) { return "M1A2C"; }
            if (resourceName == MilitaryResources.Names.M3A1) { return "M3A1"; }
            if (resourceName == MilitaryResources.Names.M3A3) { return "M3A3"; }
            if (resourceName == MilitaryResources.Names.FighterA) { return "FighterA"; }
            if (resourceName == MilitaryResources.Names.StrikeAircraftA) { return "StrikeAircraftA"; }
            if (resourceName == MilitaryResources.Names.T55) { return "T55"; }
            if (resourceName == MilitaryResources.Names.T55M) { return "T55M"; }
            if (resourceName == MilitaryResources.Names.T72A) { return "T72A"; }
            if (resourceName == MilitaryResources.Names.T72M) { return "T72M"; }
            if (resourceName == MilitaryResources.Names.BMP1) { return "BMP1"; }
            if (resourceName == MilitaryResources.Names.BMP23) { return "BMP23"; }
            if (resourceName == MilitaryResources.Names.FighterG) { return "FighterG"; }
            if (resourceName == MilitaryResources.Names.StrikeAircraftG) { return "StrikeAircraftG"; }
            return null;
        }
    }
}
