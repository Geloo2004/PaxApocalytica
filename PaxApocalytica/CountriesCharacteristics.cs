using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Politics;
using System.Drawing;

namespace PaxApocalytica
{
    public class CountryCharacteristics
    {
        public Color Color { get; set; }
        public Ideology Ideology { get; set; }
        public byte TechGroup { get; set; }
        public uint Manpower { get; set; }
        public int Cash { get; set; }
        public MilitaryFactoryType.Type Type { get; private set; }
        public CountryCharacteristics(Color color, Ideology ideology, byte techGroup, MilitaryFactoryType.Type type)
        {
            Ideology = ideology;
            Color = color;
            TechGroup = techGroup;
            Type = type;
        }
    }

    public class Country
    {
        public enum Name
        {
            Russia,
            USA,
            China
        }
    }
}