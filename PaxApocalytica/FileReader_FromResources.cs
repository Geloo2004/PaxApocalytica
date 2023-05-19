using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    public static class FileReader_FromResources
    {
        public static void ReadFile_NamesPoints()
        {
            PaxApocalyticaGame.Dictionary_NamesPoints = new Dictionary<string, List<Point>>();
            string[] lines = Resources.Name_Points.Split("\r\n");
            string lastLine = lines[0];
            foreach (var line in lines)
            {
                if (line == "") { break; }
                try
                {
                    int num = Convert.ToInt32(line[0]);
                    string[] numsStr = line.Split(" ");
                    PaxApocalyticaGame.Dictionary_NamesPoints[lastLine].Add(new Point(Convert.ToInt32(numsStr[0]), Convert.ToInt32(numsStr[1])));
                }
                catch
                {
                    PaxApocalyticaGame.Dictionary_NamesPoints.Add(line, new List<Point>());
                    lastLine = line;
                }
                finally
                {

                }
            }
        }

        public static void ReadFile_NameAirfield()
        {
            PaxApocalyticaGame.Dictionary_NameAirfield = new Dictionary<string, Airfield>();
            string[] lines = Resources.Name_Airfield.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalyticaGame.Dictionary_NameAirfield.Add(sublines[0], new Airfield(Convert.ToByte(sublines[1])));
                for (int i=1; i < sublines.Length; i++) 
                {
                    if (sublines[i] == "fighterA") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterA)); }
                    else if (sublines[i] == "fighterR") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterR)); }
                    else if (sublines[i] == "fighterG") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterG)); }
                    else if (sublines[i] == "strikeAircraftA") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftA)); }
                    else if (sublines[i] == "strikeAircraftR") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftR)); }
                    else if (sublines[i] == "strikeAircraftG") { PaxApocalyticaGame.Dictionary_NameAirfield[sublines[0]].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftG)); }
                    else { throw new ArgumentException(); }
                }
            }
        }
        public static void ReadFile_CountrynameMilResources()
        {
            PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources = new Dictionary<string, int[]>();
            string[] lines = Resources.CountryName_MilitaryResources.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources.Add(sublines[0], new int[27]);
                for (int i = 1; i < sublines.Length - 1; i++)
                {
                    PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[sublines[0]][i] = Convert.ToInt32(sublines[i]);
                }
            }
        }
        public static void ReadFile_CountrynameSimpleResources()
        {
            PaxApocalyticaGame.Dictionary_CountrynameSimpleResources = new Dictionary<string, int[]>();
            string[] lines = Resources.CountryName_SimpleResources.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalyticaGame.Dictionary_CountrynameSimpleResources.Add(sublines[0], new int[11]);
                for (int i = 1; i < sublines.Length - 1; i++)
                {
                    PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[sublines[0]][i] = Convert.ToInt32(sublines[i]);
                }
            }
        }
        public static void ReadFile_NamePort()
        {
            PaxApocalyticaGame.Dictionary_NamePort = new Dictionary<string, int>();
            string[] lines = Resources.Name_Port.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] substrings = line.Split(";");
                PaxApocalyticaGame.Dictionary_NamePort.Add(substrings[0], Convert.ToInt32(substrings[1]));
            }
        }
        public static void ReadFile_NameNeighbours()
        {
            PaxApocalyticaGame.Dictionary_NameNeighbours = new Dictionary<string, string[]>();
            string[] lines = Resources.Name_Neighbours.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                if (sublines[1] == "")
                {
                    PaxApocalyticaGame.Dictionary_NameNeighbours.Add(sublines[0], null);
                }
                else
                {
                    string[] subsublines = sublines[1].Split(",");
                    PaxApocalyticaGame.Dictionary_NameNeighbours.Add(sublines[0], subsublines);
                }
            }
        }
        public static void ReadFile_CountrynameCharacterstics()
        {
            PaxApocalyticaGame.Dictionary_CountrynameCharacteristics = new Dictionary<string, CountryCharacteristics>();
            string[] lines = Resources.CountryName_Characteristics.Split("\r\n");
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
                PaxApocalyticaGame.Dictionary_CountrynameCharacteristics.Add
                (
                    sublines[0],
                    new CountryCharacteristics
                    (
                        countryColor,
                        type,
                        Convert.ToUInt32(sublines[3]),
                        Convert.ToInt32(sublines[4]),
                        Convert.ToInt32(sublines[5]),
                        Convert.ToByte(sublines[6])
                    )
                );
            }
        }
        public static void ReadFile_NameOwner()
        {
            PaxApocalyticaGame.Dictionary_NameOwner = new Dictionary<string, string>();
            string[] lines = Resources.Name_Owner.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalyticaGame.Dictionary_NameOwner.Add(sublines[0], sublines[1]);
            }
        }
        public static void ReadFile_NameOccupant()
        {
            PaxApocalyticaGame.Dictionary_NameOccupant = new Dictionary<string, string>();
            string[] lines = Resources.Name_Occupant.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                PaxApocalyticaGame.Dictionary_NameOccupant.Add(sublines[0], sublines[1]);
            }
        }
        public static void ReadFile_ColorName()
        {
            PaxApocalyticaGame.Dictionary_ColorName = new Dictionary<Color, string>();
            string[] lines = Resources.Color_Name.Split("\r\n");

            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");
                string[] colorData = sublines[0].Split(",");
                PaxApocalyticaGame.Dictionary_ColorName.Add(Color.FromArgb(Convert.ToInt32(colorData[0]), Convert.ToInt32(colorData[1]), Convert.ToInt32(colorData[2])), sublines[1]);
            }
        }
        public static void ReadFile_NameSimpleFactory()
        {
            PaxApocalyticaGame.Dictionary_NameSFactory = new Dictionary<string, SimpleFactory>();
            string[] lines = Resources.Name_SimpleFactory.Split("\r\n");
            foreach (var line in lines)
            {
                if (line == "") { break; }
                string[] sublines = line.Split(";");

                if (sublines[1] == "Random")
                {
                    PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], GenerateSFactory());
                }
                else
                {
                    if (sublines[1] == "Oil") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Oil, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Steel") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Steel, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Copper") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Copper, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Uranium") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Uranium, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Livestock") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Livestock, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Grain") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Grain, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Coal") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Coal, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Gold") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gold, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Gas") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Gas, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else if (sublines[1] == "Aluminium") { PaxApocalyticaGame.Dictionary_NameSFactory.Add(sublines[0], new SimpleFactory(SimpleResources.Names.Aluminium, (byte)Convert.ToInt32(sublines[2]), (byte)Convert.ToInt32(sublines[3]))); }
                    else { throw new ArgumentException(); }
                }
            }
        }
        public static void ReadFile_NameMilitaryFactory()
        {
            PaxApocalyticaGame.Dictionary_NameMFactory = new Dictionary<string, MilitaryFactory>();
            string[] lines = Resources.Name_MilitaryFactory.Split("\r\n");
            foreach (var line in lines)
            {
                string[] sublines = line.Split(";");

                if (sublines[1] == "")
                {
                    PaxApocalyticaGame.Dictionary_NameMFactory.Add(sublines[0], null);
                }
                else
                {
                    if (sublines[1] == "Weaponry")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.Weaponry, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72B")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72B, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T90A")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T90A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T90M")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T90M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T14")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T14, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP2")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP3")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMD1")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMD1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMD2")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMD2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterR")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftR")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftR, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A1")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A2")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M1A2C")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M1A2, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M3A1")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M3A1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "M3A3")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.M3A3, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterA")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftA")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftA, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T55")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T55, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T55M")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T55M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72A")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72A, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "T72M")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.T72M, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP1")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP1, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "BMP23")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.BMP23, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "FighterG")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.FighterG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else if (sublines[1] == "StrikeAircraftG")
                    {
                        PaxApocalyticaGame.Dictionary_NameMFactory.Add
                        (sublines[0],
                        new MilitaryFactory(MilitaryResources.Names.StrikeAircraftG, Convert.ToByte(sublines[2]), Convert.ToByte(sublines[3]), PaxApocalyticaGame.Dictionary_CountrynameCharacteristics[PaxApocalyticaGame.Dictionary_NameOwner[sublines[0]]].TechGroup));
                    }
                    else { throw new ArgumentException(); }

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
