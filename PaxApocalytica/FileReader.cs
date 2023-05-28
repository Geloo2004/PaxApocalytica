using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    public static class FileReader
    {
        public static void ReadFile_TruceSides() 
        {
            PaxApocalypticaGame.Dictionary_CountrynameFriends = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "TruceSides.txt");
            }
            else
            {
                lines = Resources.TruceSides.Split("\r\n");
            }
            foreach (var line in lines)
            {

            }
        }
        
        public static void ReadFile_NameInterceptors() 
        {
            PaxApocalypticaGame.Dictionary_CountrynameFriends = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "NameInterceptors.txt");
            }
            else
            {
                lines = Resources.NameInterceptors.Split("\r\n");
            }
            foreach (var line in lines)
            {

            }
        }
        public static void ReadFile_PactCountrynames() 
        {
            PaxApocalypticaGame.Dictionary_PactCountrynames = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Pact_Countryname.txt");
            }
            else
            {
                lines = Resources.Pact_Countryname.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] subsublines = sublines[1].Split(",");

                PaxApocalypticaGame.Dictionary_PactCountrynames.Add(sublines[0], new List<string>());
                foreach (var subsubline in subsublines)
                {
                    if (subsubline != "")
                    {
                        PaxApocalypticaGame.Dictionary_PactCountrynames[sublines[0]].Add(subsubline);
                    }
                }
            }

        }
        public static void ReadFile_CountrynameFriends()
        {
            PaxApocalypticaGame.Dictionary_CountrynameFriends = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_Friends.txt");
            }
            else
            {
                lines = Resources.CountryName_Friends.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] subsublines = sublines[1].Split(",");

                PaxApocalypticaGame.Dictionary_CountrynameFriends.Add(sublines[0], new List<string>());
                foreach(var subsubline in subsublines) 
                {
                    PaxApocalypticaGame.Dictionary_CountrynameFriends[sublines[0]].Add(subsubline);
                }
            }
        }
        public static void ReadFile_CountrynameAllies()
        {
            PaxApocalypticaGame.Dictionary_CountrynameAllies = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_Allies.txt");
            }
            else
            {
                lines = Resources.CountryName_Allies.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] subsublines = sublines[1].Split(",");

                PaxApocalypticaGame.Dictionary_CountrynameAllies.Add(sublines[0], new List<string>());
                foreach (var subsubline in subsublines)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameAllies[sublines[0]].Add(subsubline);
                }
            }

            /* Проверка того, что страны существуют 
            foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameAllies.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.ContainsKey(country))
                {
                    foreach (var country1 in PaxApocalypticaGame.Dictionary_CountrynameAllies[country])
                    {
                        if (country1 != "")
                        {
                            if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.ContainsKey(country1))
                            {

                            }
                            else { throw new ArgumentException(); }
                        }
                    }
                }
                else { throw new ArgumentException(); }
            }*/
        }
        public static void ReadFile_CountrynameRivals()
        {
            PaxApocalypticaGame.Dictionary_CountrynameRivals = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_Rivals.txt");
            }
            else
            {
                lines = Resources.CountryName_Rivals.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] subsublines = sublines[1].Split(",");

                PaxApocalypticaGame.Dictionary_CountrynameRivals.Add(sublines[0], new List<string>());
                foreach (var subsubline in subsublines)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameRivals[sublines[0]].Add(subsubline);
                }
            }
        }
        public static void ReadFile_WarSides()
        {
            PaxApocalypticaGame.Dictionary_WarSides = new Dictionary<List<string>, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "WarSides.txt");
            }
            else
            {
                lines = Resources.WarSides.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] side0 = sublines[0].Split(",");
                string[] side1 = sublines[1].Split(",");
                PaxApocalypticaGame.Dictionary_WarSides.Add(side0.ToList(), side1.ToList());
            }
            /*
            foreach(var key in PaxApocalypticaGame.Dictionary_WarSides.Keys) 
            {
                foreach(var country in key) 
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.ContainsKey(country))
                    {

                    }
                    else { throw new ArgumentException(); }
                }
                foreach (var country in PaxApocalypticaGame.Dictionary_WarSides[key])
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.ContainsKey(country))
                    {

                    }
                    else { throw new ArgumentException(); }
                }
            }*/
        }

        public static void ReadFile_CreationQueue_Army()
        {
            PaxApocalypticaGame.Dictionary_CreationQueue_Army = new Dictionary<string, string>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CreationQueue_Army.txt");
            }
            else
            {
                lines = Resources.CreationQueue_Army.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_CreationQueue_Army.Add(sublines[0], sublines[1]);              
            }
        }
        public static void ReadFile_UpgradeQueue_SFactory() 
        {
            PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory = new Dictionary<string, SimpleFactory>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "UpgradeQueue_SFactory.txt");
            }
            else
            {
                lines = Resources.UpgradeQueue_SFactory.Split("\r\n");
            }

            foreach(var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");

                if (sublines[1] ==      "Oil") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Oil, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Gold") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gold, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Steel") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Steel, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Aluminium") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Aluminium, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Gas") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gas, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Copper") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Copper, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Livestock") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Livestock, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Coal") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Coal, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Uranium") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Uranium, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else if (sublines[1] == "Grain") { PaxApocalypticaGame.Dictionary_UpgradeQueue_SFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Grain, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]))); }
                else { throw new ArgumentException(); }
            }
        }
        public static void ReadFile_UpgradeQueue_MFactory() 
        {
            PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory = new Dictionary<string, MilitaryFactory>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "UpgradeQueue_MFactory.txt");
            }
            else
            {
                lines = Resources.UpgradeQueue_MFactory.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                MilitaryFactoryType.Type mft;

                if (sublines[4] == "NATO") 
                {
                    mft = MilitaryFactoryType.Type.NATO;
                }
                else if(sublines[4] == "Soviet")
                {
                    mft = MilitaryFactoryType.Type.Soviet;
                }
                else if (sublines[4] == "Generic")
                {
                    mft = MilitaryFactoryType.Type.Generic;
                }
                else { throw new ArgumentException(); }


                if (sublines[1] == "Weaponry") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.Weaponry, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T72B") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T72B, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T90A") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T90A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T90M") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T90M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T14") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T14, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMP2") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMP2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMP3") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMP3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMD1") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMD1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMD2") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMD2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "FighterR") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.FighterR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "StrikeAircraftR") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.StrikeAircraftR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M1") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M1A1") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M1A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M1A2") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M1A2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M1A2C") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M1A2C, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M3A1") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M3A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "M3A3") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.M3A3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "FighterA") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.FighterA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "StrikeAircraftA") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.StrikeAircraftA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T55") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T55, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T55M") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T55M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T72A") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T72A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "T72M") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.T72M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMP1") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMP1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "BMP23") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.BMP23, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "FighterG") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.FighterG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else if (sublines[1] == "StrikeAircraftG") { PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(sublines[0], new MilitaryFactory(MilitaryResources.Names.StrikeAircraftG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), mft)); }
                else { throw new ArgumentException(); }
            }
        }

        public static void ReadFile_NameArmynames()
        {
            PaxApocalypticaGame.Dictionary_NameArmynames = new Dictionary<string, List<string>>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_ArmyName.txt");
            }
            else
            {
                lines = Resources.Name_ArmyName.Split("\r\n");
            }

            foreach(var line in lines) 
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_NameArmynames.Add(sublines[0], new List<string>());                
                for(int i = 1; i < sublines.Length; i++) 
                {
                    if (sublines[i] != "")
                    {
                        PaxApocalypticaGame.Dictionary_NameArmynames[sublines[0]].Add(sublines[i]);
                    }
                }
            }
        }
        public static void ReadFile_ArmynameArmycharacteristics()
        {
            PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics = new Dictionary<string, Military.Army>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "ArmyName_ArmyCharacteristics.txt");
            }
            else
            {
                lines = Resources.ArmyName_ArmyCharacteristics.Split("\r\n");
            }

            foreach(var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                bool isMoved = false;
                if (sublines[18] == "True") { isMoved = true; }
                else if (sublines[18] == "False") { isMoved = false; }
                else { throw new ArgumentException(); }

                PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(sublines[1], new Military.Army(sublines[0],isMoved));
                for(int i =0;i<16;i++) 
                {
                    if (sublines[i + 2] == "") 
                    {
                        PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[sublines[1]].Units[i] = null;
                        continue;
                    }

                    string[] subsublines = sublines[i + 2].Split(",");
                    if (subsublines[1]=="") { throw new ArgumentException(); }
                    int hp = Convert.ToInt32(subsublines[1]);
                    Military.Unit unit;
                    if (subsublines[0] =="unmotorizedInfantry") { unit = new Military.Unit(Military.UnitName.Name.unmotorizedInfantry,hp); }
                    else if (subsublines[0] =="infantry1r") { unit = new Military.Unit(Military.UnitName.Name.infantry1r, hp); }
                    else if (subsublines[0] =="infantry2r") { unit = new Military.Unit(Military.UnitName.Name.infantry2r, hp); }
                    else if (subsublines[0] =="tank1r") { unit = new Military.Unit(Military.UnitName.Name.tank1r, hp); }
                    else if (subsublines[0] =="tank2r") { unit = new Military.Unit(Military.UnitName.Name.tank2r, hp); }
                    else if (subsublines[0] =="tank3r") { unit = new Military.Unit(Military.UnitName.Name.tank3r, hp); }
                    else if (subsublines[0] =="tank4r") { unit = new Military.Unit(Military.UnitName.Name.tank4r, hp); }
                    else if (subsublines[0] =="vdv1") { unit = new Military.Unit(Military.UnitName.Name.vdv1, hp); }
                    else if (subsublines[0] =="vdv2") { unit = new Military.Unit(Military.UnitName.Name.vdv2, hp); }
                    else if (subsublines[0] =="infantry1a") { unit = new Military.Unit(Military.UnitName.Name.infantry1a, hp); }
                    else if (subsublines[0] =="infantry2a") { unit = new Military.Unit(Military.UnitName.Name.infantry2a, hp); }
                    else if (subsublines[0] =="tank1a") { unit = new Military.Unit(Military.UnitName.Name.tank1a, hp); }
                    else if (subsublines[0] =="tank2a") { unit = new Military.Unit(Military.UnitName.Name.tank2a, hp); }
                    else if (subsublines[0] =="tank3a") { unit = new Military.Unit(Military.UnitName.Name.tank3a, hp); }
                    else if (subsublines[0] =="tank4a") { unit = new Military.Unit(Military.UnitName.Name.tank4a, hp); }
                    else if (subsublines[0] =="infantry1g") { unit = new Military.Unit(Military.UnitName.Name.infantry1g, hp); }
                    else if (subsublines[0] =="infantry2g") { unit = new Military.Unit(Military.UnitName.Name.infantry2g, hp); }
                    else if (subsublines[0] =="tank1g") { unit = new Military.Unit(Military.UnitName.Name.tank1g, hp); }
                    else if (subsublines[0] =="tank2g") { unit = new Military.Unit(Military.UnitName.Name.tank2g, hp); }
                    else if (subsublines[0] =="tank3g") { unit = new Military.Unit(Military.UnitName.Name.tank3g, hp); }
                    else if (subsublines[0] =="tank4g") { unit = new Military.Unit(Military.UnitName.Name.tank4g, hp); }
                    else if (subsublines[0] =="fighterA") { unit = new Military.Unit(Military.UnitName.Name.fighterA, hp); }
                    else if (subsublines[0] =="fighterR") { unit = new Military.Unit(Military.UnitName.Name.fighterR, hp); }
                    else if (subsublines[0] =="fighterG") { unit = new Military.Unit(Military.UnitName.Name.fighterG, hp); }
                    else if (subsublines[0] =="strikeAircraftA") { unit = new Military.Unit(Military.UnitName.Name.strikeAircraftA, hp); }
                    else if (subsublines[0] =="strikeAircraftR") { unit = new Military.Unit(Military.UnitName.Name.strikeAircraftR, hp); }
                    else if(subsublines[0] == "strikeAircraftG") { unit = new Military.Unit(Military.UnitName.Name.strikeAircraftG, hp); }
                    else { throw new ArgumentException(); }

                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[sublines[1]].AddUnit(unit, i);
                }
            }
        }
        public static void ReadFile_NamesPoints()
        {
            PaxApocalypticaGame.Dictionary_NamesPoints = new Dictionary<string, Point[]>(); 
            string[] lines = Resources.Name_Points.Split("\r\n");
            string lastLine = lines[0];
            List<Point> pointsList = new List<Point>();
            foreach (var line in lines)
            {
                if (line == "") { break; }
                try
                {
                    int num = Convert.ToInt32(line[0]);
                    string[] numsStr = line.Split(" "); 
                    pointsList.Add(new Point(Convert.ToInt32(numsStr[0]), Convert.ToInt32(numsStr[1])));
                    //PaxApocalypticaGame.Dictionary_NamesPoints[lastLine].Add(new Point(Convert.ToInt32(numsStr[0]), Convert.ToInt32(numsStr[1])));
                }
                catch
                {
                    PaxApocalypticaGame.Dictionary_NamesPoints[lastLine] = pointsList.ToArray();
                    pointsList.Clear();
                    lastLine = line;
                }
                finally
                {

                }
            }
            PaxApocalypticaGame.Dictionary_NamesPoints[lastLine] = pointsList.ToArray();
        }
        public static void ReadFile_NameAirfield()
        {
            PaxApocalypticaGame.Dictionary_NameAirfield = new Dictionary<string, Airfield>();
            string[] lines; 
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_Airfield.txt");
            }
            else
            {
                lines = Resources.Name_Airfield.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_NameAirfield.Add(sublines[0], new Airfield(Convert.ToByte(sublines[1])));
                for (int i=2; i < sublines.Length; i++) 
                {
                    if (sublines[i] == "") { continue; }
                    if (sublines[i] == "fighterA") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterA)); }
                    else if (sublines[i] == "fighterR") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterR)); }
                    else if (sublines[i] == "fighterG") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterG)); }
                    else if (sublines[i] == "strikeAircraftA") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftA)); }
                    else if (sublines[i] == "strikeAircraftR") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftR)); }
                    else if (sublines[i] == "strikeAircraftG") { PaxApocalypticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftG)); }
                    else { throw new ArgumentException(); }
                }
            }
        }
        public static void ReadFile_CountrynameMilResources()
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources = new Dictionary<string, int[]>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_MilitaryResources.txt");
            }
            else
            {
                lines = Resources.CountryName_MilitaryResources.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources.Add(sublines[0], new int[27]);
                for (int i = 1; i < sublines.Length; i++)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[sublines[0]][i-1] = Convert.ToInt32(sublines[i]);
                }
            }
        }
        public static void ReadFile_CountrynameSimpleResources()
        {
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources = new Dictionary<string, int[]>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_SimpleResources.txt");
            }
            else
            {
                lines = Resources.CountryName_SimpleResources.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_CountrynameSimpleResources.Add(sublines[0], new int[10]);
                for (int i = 0; i < sublines.Length-1; i++)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[sublines[0]][i] = Convert.ToInt32(sublines[i+1]);
                }
            }
        }
        public static void ReadFile_CountrynameSimpleResources_Trade()
        {
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade = new Dictionary<string, int[]>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "CountryName_SimpleResources_Trade.txt");
            }
            else
            {
                lines = Resources.CountryName_SimpleResources_Trade.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade.Add(sublines[0], new int[10]);
                for (int i = 0; i < sublines.Length - 1; i++)
                {
                    PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[sublines[0]][i] = Convert.ToInt32(sublines[i + 1]);
                }
            }
        }
        public static void ReadFile_NamePort()
        {
            PaxApocalypticaGame.Dictionary_NamePort = new Dictionary<string, int>(); 
            string[] lines = Resources.Name_Port.Split("\r\n");

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] substrings = line.Split(";");
                PaxApocalypticaGame.Dictionary_NamePort.Add(substrings[0], Convert.ToInt32(substrings[1]));
            }
        }
        public static void ReadFile_NameNeighbours()
        {
            PaxApocalypticaGame.Dictionary_NameNeighbours = new Dictionary<string, string[]>();
            string[] lines = Resources.Name_Neighbours.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                if (sublines[1] == "")
                {
                    PaxApocalypticaGame.Dictionary_NameNeighbours.Add(sublines[0], null);
                }
                else
                {
                    string[] subsublines = sublines[1].Split(",");
                    PaxApocalypticaGame.Dictionary_NameNeighbours.Add(sublines[0], subsublines);
                }
            }
        }
        public static void ReadFile_CountrynameCharacterstics()
        {
            PaxApocalypticaGame.Dictionary_CountrynameCharacteristics = new Dictionary<string, CountryCharacteristics>(); 
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Countryname_Characterstics.txt");
            }
            else
            {
                lines = Resources.CountryName_Characteristics.Split("\r\n");
            }
            foreach (var line in lines)
            {
                if (line == "") { break; }
                Color countryColor;
                MilitaryFactoryType.Type type;

                string[] sublines = line.Split(";");

                string[] colorString = sublines[1].Split(",");
                countryColor = Color.FromArgb(Convert.ToInt32(colorString[0]), Convert.ToInt32(colorString[1]), Convert.ToInt32(colorString[2]));

                if (sublines[2] == "NATO")
                {
                    type = MilitaryFactoryType.Type.NATO;
                }
                else if (sublines[2] == "Soviet")
                {
                    type = MilitaryFactoryType.Type.Soviet;
                }
                else
                {
                    type = MilitaryFactoryType.Type.Generic;
                }
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics.Add
                (
                    sublines[0],
                    new CountryCharacteristics
                    (
                        countryColor,
                        type,
                        Convert.ToInt32(sublines[3]),
                        Convert.ToInt32(sublines[4]),
                        Convert.ToByte(sublines[5])
                    )
                );
            }
        }
        public static void ReadFile_NameOwner()
        {
            PaxApocalypticaGame.Dictionary_NameOwner = new Dictionary<string, string>(); 
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_Owner.txt");
            }
            else
            {
                lines = Resources.Name_Owner.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_NameOwner.Add(sublines[0], sublines[1]);
            }
        }
        public static void ReadFile_NameOccupant()
        {
            PaxApocalypticaGame.Dictionary_NameOccupant = new Dictionary<string, string>(); 
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_Occupant.txt");
            }
            else
            {
                lines = Resources.Name_Occupant.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalypticaGame.Dictionary_NameOccupant.Add(sublines[0], sublines[1]);
            }
        }
        public static void ReadFile_ColorName()
        {
            PaxApocalypticaGame.Dictionary_ColorName = new Dictionary<Color, string>();
            string[] lines = Resources.Color_Name.Split("\r\n");

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] colorData = sublines[0].Split(",");
                PaxApocalypticaGame.Dictionary_ColorName.Add(Color.FromArgb(Convert.ToInt32(colorData[0]), Convert.ToInt32(colorData[1]), Convert.ToInt32(colorData[2])), sublines[1]);
            }
        }
        public static void ReadFile_NameSimpleFactory()
        {
            PaxApocalypticaGame.Dictionary_NameSFactory = new Dictionary<string, SimpleFactory>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_SimpleFactory.txt");
            }
            else
            {
                lines = Resources.Name_SimpleFactory.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");

                if (sublines[1] == "Random")
                {
                    PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], GenerateSFactory());
                }
                else
                {
                    if (sublines[1] == "Oil") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Oil, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Steel") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Steel, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Copper") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Copper, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Uranium") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Uranium, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Livestock") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Livestock, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Grain") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Grain, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Coal") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Coal, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Gold") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gold, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Gas") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gas, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Aluminium") { PaxApocalypticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Aluminium, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else { throw new ArgumentException(); }
                }
            }
        }
        public static void ReadFile_NameMilitaryFactory()
        {
            PaxApocalypticaGame.Dictionary_NameMFactory = new Dictionary<string, MilitaryFactory>(); 
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_MilitaryFactory.txt");
            }
            else
            {
                lines = Resources.Name_MilitaryFactory.Split("\r\n");
            }

            foreach (var line in lines)
            {
                string[] sublines = line.Split(";");

                if (sublines[1] == "")
                {
                    PaxApocalypticaGame.Dictionary_NameMFactory.Add(sublines[0], null);
                }
                else
                {
                    if (sublines[1] == "Weaponry")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.Weaponry, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72B")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72B, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T90A")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T90A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T90M")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T90M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T14")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T14, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP2")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP3")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMD1")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMD1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMD2")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMD2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterR")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftR")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A1")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A2")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A2C")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M3A1")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M3A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M3A3")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M3A3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterA")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftA")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T55")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T55, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T55M")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T55M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72A")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72M")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP1")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP23")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP23, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterG")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftG")
                    {
                        PaxApocalypticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else { throw new ArgumentException(); }

                }
            }
        }
        public static void ReadFile_NameCharacteristics()
        {
            Random random = new Random(); ;
            bool pathNull = false;
            PaxApocalypticaGame.Dictionary_NameCharacteristics = new Dictionary<string, ProvinceCharacteristics>();
            string[] lines;
            if (Form1.path != null)
            {
                lines = File.ReadAllLines(Form1.path + "Name_Characteristics.txt");
            }
            else
            {
                pathNull = true;
                lines = Resources.Name_Characteristics.Split("\r\n");
            }

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                if (pathNull)
                {
                    ulong populMult = (ulong)random.Next(80, 120);
                    byte edMult = (byte)random.Next(-2, 4);
                    uint mpMult = (uint)random.Next(60, 90);
                    PaxApocalypticaGame.Dictionary_NameCharacteristics.Add(sublines[0],
                        new ProvinceCharacteristics
                        (
                            (ulong)(Convert.ToUInt64(sublines[1])*populMult/100),
                            (byte)(Convert.ToByte(sublines[2]) + edMult),
                            (uint)(Convert.ToUInt32(sublines[3]) * mpMult/1000),
                            (byte)(Convert.ToByte(sublines[2])))
                        );
                }
                else 
                {
                    PaxApocalypticaGame.Dictionary_NameCharacteristics.Add(sublines[0],
                        new ProvinceCharacteristics
                        (
                            Convert.ToUInt64(sublines[1]),
                            Convert.ToByte(sublines[2]),
                            Convert.ToUInt32(sublines[3]),
                            Convert.ToByte(sublines[4]))
                        );
                }
            }
        }
        public static SimpleFactory GenerateSFactory()
        {
            Random random = new Random();
            int resource = random.Next(1, 100);
            byte eL = (byte)random.Next(1, 3);
            byte tL = (byte)random.Next(1, 2);
            if (resource >= 1 && resource <= 10) //steel 10%
            {
                return new SimpleFactory(SimpleResources.Names.Steel, eL, tL);
            }
            if (resource >= 11 && resource <= 25) //copper 15%
            {
                return new SimpleFactory(SimpleResources.Names.Copper, eL, tL);
            }
            if (resource >= 26 && resource <= 28) //gold 3%
            {
                return new SimpleFactory(SimpleResources.Names.Gold, eL, tL);
            }
            if (resource >= 29 && resource <= 39) //aluminium 10%
            {
                return new SimpleFactory(SimpleResources.Names.Aluminium, eL, tL);
            }
            if (resource >= 40 && resource <= 49) //coal 10%
            {
                return new SimpleFactory(SimpleResources.Names.Coal, eL, tL);
            }
            if (resource >= 50 && resource <= 54) //oil 5%
            {
                return new SimpleFactory(SimpleResources.Names.Oil, eL, tL);
            }
            if (resource >= 55 && resource <= 70) //Livestock 16%
            {
                return new SimpleFactory(SimpleResources.Names.Livestock, eL, tL);
            }
            if (resource >= 71 && resource <= 99) //Grain 29%
            {
                return new SimpleFactory(SimpleResources.Names.Grain, eL, tL);
            }
            return new SimpleFactory(SimpleResources.Names.Uranium, 1, 1);
        }
    }
}
