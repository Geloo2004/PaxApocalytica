using CountriesLib.FactoriesAndResources;
using PaxApocalytica.Politics;
using System.Drawing;

namespace CountriesLib
{
    public class Country
    {
        static bool flag = true;
        private static Dictionary<Names, CountryCharacteristics> countries = new Dictionary<Names, CountryCharacteristics>
        {
            {
                Names.Russia,
                new CountryCharacteristics
                (
                    Color.ForestGreen,
                    new Ideology
                    (
                        10,
                        20,
                        60,
                        10,
                        IdeologyEnum.Name.Liberalism
                        ),
                    0,
                    MilitaryFactoryType.Type.Soviet
                )
            },
        };

        public static Dictionary<Names, CountryCharacteristics> GetAllCC()
        {
            return countries;
        }

        public enum Names 
        {
            Russia,
            USA,
            China
        }
    }

    public class CountryCharacteristics 
    {
        public Color Color { get; set; }
        public Ideology Ideology { get; set; }
        public byte TechGroup { get; set; }
        public uint Manpower { get; set; }
        public int Cash { get; set; }
        public MilitaryFactoryType.Type Type { get; private set; }
        public CountryCharacteristics(Color color,Ideology ideology, byte techGroup, MilitaryFactoryType.Type type)
        {
            this.Ideology = ideology;
            this.Color = color;
            this.TechGroup = techGroup;
            this.Type = type;
        }
    }
}