using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Military;
using PaxApocalytica.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
        army                                                    //меняется  +
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
            WriteFile_NameArmyname(basePath);
            WriteFile_ArmynameArmycharacteristics(basePath);
            WriteFile_NameCharacteristics(basePath);
            WriteFile_CountrynameSimpleResources_Trade(basePath);
            WriteFile_CreationQueue_Army(basePath); 
            WriteFile_UpgradeQueue_SFactory(basePath); 
            WriteFile_UpgradeQueue_MFactory(basePath);
            WriteFile_NameInterceptor(basePath); 
            WriteFile_CountryName_Friends(basePath);
            WriteFile_CountryName_Rivals(basePath);
            WriteFile_CountryName_Allies(basePath);
            WriteFile_WarSides(basePath);
            WriteFile_PactCountryname(basePath);
        }

        public static void WriteFile_PactCountryname(string basePath) 
        {
            string path = basePath + "Pact_Countryname.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_PactCountrynames.Keys)
                {
                    outputFile.Write(line + ";");
                    if (PaxApocalypticaGame.Dictionary_PactCountrynames[line].Count > 0) { outputFile.Write(PaxApocalypticaGame.Dictionary_PactCountrynames[line][0]); }
                    for(int i =1;i< PaxApocalypticaGame.Dictionary_PactCountrynames[line].Count; i++) 
                    {
                        outputFile.Write(";"+PaxApocalypticaGame.Dictionary_PactCountrynames[line][i]);
                    }
                    outputFile.WriteLine();
                }
            }
        }
        public static void WriteFile_NameInterceptor(string basePath)
        {
            string path = basePath + "Name_Interceptors.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Keys)
                {
                    outputFile.WriteLine(line + ";" + PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].ProducedResourceName + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].TechnologyLevel + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].ExtensionLevel);
                }
            }
        }
        public static void WriteFile_CountryName_Friends(string basePath)
        {
            string path = basePath + "CountryName_Friends.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_CountrynameFriends.Keys)
                {
                    outputFile.Write(line+";");
                    for(int i = 0;i< PaxApocalypticaGame.Dictionary_CountrynameFriends[line].Count-1; i++) 
                    {
                        outputFile.Write(PaxApocalypticaGame.Dictionary_CountrynameFriends[line][i] + ",");
                    }
                    outputFile.WriteLine(PaxApocalypticaGame.Dictionary_CountrynameFriends[line][PaxApocalypticaGame.Dictionary_CountrynameFriends[line].Count - 1]);
                }
            }
        }
        public static void WriteFile_CountryName_Rivals(string basePath)
        {
            string path = basePath + "CountryName_Rivals.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_CountrynameRivals.Keys)
                {
                    outputFile.Write(line + ";");
                    for (int i = 0; i < PaxApocalypticaGame.Dictionary_CountrynameRivals[line].Count - 1; i++)
                    {
                        outputFile.Write(PaxApocalypticaGame.Dictionary_CountrynameRivals[line][i] + ",");
                    }
                    outputFile.WriteLine(PaxApocalypticaGame.Dictionary_CountrynameRivals[line][PaxApocalypticaGame.Dictionary_CountrynameRivals[line].Count - 1]);
                }
            }
        }
        public static void WriteFile_CountryName_Allies(string basePath)
        {
            string path = basePath + "CountryName_Allies.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_CountrynameAllies.Keys)
                {
                    outputFile.Write(line + ";");
                    for (int i = 0; i < PaxApocalypticaGame.Dictionary_CountrynameAllies[line].Count - 1; i++)
                    {
                        outputFile.Write(PaxApocalypticaGame.Dictionary_CountrynameAllies[line][i] + ",");
                    }
                    outputFile.WriteLine(PaxApocalypticaGame.Dictionary_CountrynameAllies[line][PaxApocalypticaGame.Dictionary_CountrynameAllies[line].Count - 1]);
                }
            }
        }
        public static void WriteFile_WarSides(string basePath) 
        {
            string path = basePath + "WarSides.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_WarSides.Keys)
                {
                    outputFile.Write(line[0]);
                    for (int i =0;i<line.Count-1;i++) 
                    {
                        outputFile.Write("," + line[i] );
                    }
                    outputFile.Write(";");
                    outputFile.Write(PaxApocalypticaGame.Dictionary_WarSides[line][0]);
                    for (int i = 1; i < PaxApocalypticaGame.Dictionary_WarSides[line].Count; i++)
                    {
                        outputFile.Write("," + PaxApocalypticaGame.Dictionary_WarSides[line][i]);
                    }
                }
            }
        }
        public static void WriteFile_UpgradeQueue_SFactory(string basePath)
        {
            string path = basePath + "UpgradeQueue_SFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path)) 
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Keys)
                {
                    outputFile.WriteLine(line + ";" + PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].ProducedResourceName + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].TechnologyLevel + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory[line].ExtensionLevel);
                }
            }
        }
        public static void WriteFile_UpgradeQueue_MFactory(string basePath)
        {
            string path = basePath + "UpgradeQueue_MFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Keys)
                {
                    outputFile.WriteLine(line + ";" + PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory[line].ProducedResourceName + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory[line].TechnologyLevel + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory[line].ExtensionLevel + ";" +
                        PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory[line].FactoryType);
                }
            }
        }
        public static void WriteFile_CreationQueue_Army(string basePath)
        {
            string path = basePath + "CreationQueue_Army.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var line in PaxApocalypticaGame.Dictionary_CreationQueue_Army.Keys)
                {
                    outputFile.WriteLine(line+";" + PaxApocalypticaGame.Dictionary_CreationQueue_Army[line]);
                }
            }
        }
        public static void WriteFile_ArmynameArmycharacteristics(string basePath)
        {
            string path = basePath + "ArmyName_ArmyCharacteristics.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var name in PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Keys)
                {
                    outputFile.Write(PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[name].Owner + ";" + name);
                    for(int i = 0; i < 16; i++) 
                    {
                        Unit unit = PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[name].Units[i];
                        if (unit != null) { outputFile.Write(";" + unit.Name +","+unit.HP); }
                        else { outputFile.Write(";"); }
                    }
                    outputFile.WriteLine(";"+ PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[name].IsMoved);                        
                }
            }
        }
        public static void WriteFile_NameArmyname(string basePath)
        {
            string path = basePath + "Name_ArmyName.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var name in PaxApocalypticaGame.Dictionary_NameArmynames.Keys)
                {
                    outputFile.Write(name);
                    if (PaxApocalypticaGame.Dictionary_NameArmynames[name].Count == 0) { outputFile.Write(";"); }
                    else
                    {
                        foreach (var army in PaxApocalypticaGame.Dictionary_NameArmynames[name])
                        {
                            outputFile.Write(";" + army);
                        }
                    }
                    outputFile.WriteLine();
                }
            }
        }
        public static void WriteFile_NameAirfield(string basePath) 
        {
            string path = basePath + "Name_Airfield.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var airfield in PaxApocalypticaGame.Dictionary_NameAirfield.Keys)
                {
                    outputFile.Write(airfield + ";" + PaxApocalypticaGame.Dictionary_NameAirfield[airfield].Planes.Length);
                    foreach (var plane in PaxApocalypticaGame.Dictionary_NameAirfield[airfield].Planes) 
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
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.Keys)
                {
                    Color color = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Color;
                    MilitaryFactoryType.Type type = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].TechGroup;
                    int cash = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Cash;
                    int dipka = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].DiploPoints;
                    byte leaders = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].MaxLeaders;
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
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources.Keys)
                {
                    int Oil = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][0];
                    int Steel = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][1];
                    int Copper = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][2];
                    int Uranium = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][3];
                    int Coal = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][4];
                    int Grain = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][5];
                    int Livestock = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][6];
                    int Gas = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][7];
                    int Aluminium = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][8];
                    int Gold = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][9];
                    outputFile.WriteLine(country+";"+Oil + ";" + Steel + ";" + Copper + ";" + Uranium + ";" + Coal + ";" +
                        Grain + ";" + Livestock + ";" + Gas + ";" + Aluminium + ";" + Gold );
                }
            }
        }
        public static void WriteFile_CountrynameSimpleResources_Trade(string basePath)
        {
            string path = basePath + "CountryName_SimpleResources_Trade.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameSimpleResources.Keys)
                {
                    int Oil = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][0];
                    int Steel = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][1];
                    int Copper = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][2];
                    int Uranium = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][3];
                    int Coal = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][4];
                    int Grain = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][5];
                    int Livestock = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][6];
                    int Gas = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][7];
                    int Aluminium = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][8];
                    int Gold = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[country][9];
                    outputFile.WriteLine(country + ";" + Oil + ";" + Steel + ";" + Copper + ";" + Uranium + ";" + Coal + ";" +
                        Grain + ";" + Livestock + ";" + Gas + ";" + Aluminium + ";" + Gold);
                }
            }
        }
        public static void WriteFile_CountrynameMilresources(string basePath)
        {
            string path = basePath + "CountryName_MilitaryResources.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources.Keys)
                {
                    int Weaponry = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
                    int T72B = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1];
                    int T90A = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][2];
                    int T90M = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][3];
                    int T14 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][4];
                    int BMP2 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5];
                    int BMP3 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][6];
                    int BMD1 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][7];
                    int BMD2 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][8];
                    int FighterR = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][9];
                    int StrikeAircraftR = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][10];
                    int M1 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11];
                    int M1A1 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][12];
                    int M1A2 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][13];
                    int M1A2C = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][14];
                    int M3A1 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15];
                    int M3A3 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][16];
                    int FighterA = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][17];
                    int StrikeAircraftA = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][18];
                    int T55 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19];
                    int T55M = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][20];
                    int T72A = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][21];
                    int T72M = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][22];
                    int BMP1 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23];
                    int BMP23 = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][24];
                    int FighterG = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][25];
                    int StrikeAircraftG = PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][26];
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
                foreach (var province in PaxApocalypticaGame.Dictionary_NameOwner.Keys)
                {
                    outputFile.WriteLine(province+";"+ PaxApocalypticaGame.Dictionary_NameOwner[province]);
                }
            }
        }
        public static void WriteFile_NameOccupant(string basePath)
        {
            string path = basePath + "Name_Occupant.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalypticaGame.Dictionary_NameOccupant.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalypticaGame.Dictionary_NameOccupant[province]);
                }
            }
        }
        public static void WriteFile_NameCharacteristics(string basePath)
        {
            string path = basePath + "Name_Characteristics.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalypticaGame.Dictionary_NameCharacteristics.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Population+";"
                        + PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Eductaion +";"
                        + PaxApocalypticaGame.Dictionary_NameCharacteristics[province].Manpower+";"
                        + PaxApocalypticaGame.Dictionary_NameCharacteristics[province].EductaionEffort);
                }
            }
        }
        public static void WriteFile_NameSimpleFactory(string basePath)
        {
            string path = basePath + "Name_SimpleFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalypticaGame.Dictionary_NameSFactory.Keys)
                {
                    outputFile.WriteLine(province + ";" + PaxApocalypticaGame.Dictionary_NameSFactory[province].ProducedResourceName + ";" +
                        PaxApocalypticaGame.Dictionary_NameSFactory[province].TechnologyLevel + ";" +
                        PaxApocalypticaGame.Dictionary_NameSFactory[province].ExtensionLevel);
                }
            }
        }
        public static void WriteFile_NameMilitaryFactory(string basePath)
        {
            string path = basePath + "Name_MilitaryFactory.txt";

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (var province in PaxApocalypticaGame.Dictionary_NameMFactory.Keys)
                {
                    if (PaxApocalypticaGame.Dictionary_NameMFactory[province]==null) { outputFile.WriteLine(province + ";"); }
                    else 
                    {
                        outputFile.WriteLine(province.ToString() + ";" +
                            ConvertMResourceToString(PaxApocalypticaGame.Dictionary_NameMFactory[province].ProducedResourceName) + ";" +
                            PaxApocalypticaGame.Dictionary_NameMFactory[province].TechnologyLevel + ";" +
                            PaxApocalypticaGame.Dictionary_NameMFactory[province].ExtensionLevel); 
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
