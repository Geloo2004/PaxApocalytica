using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Politics;
using System.Drawing;

namespace PaxApocalytica
{
    public class CountryCharacteristics
    {
        public Color Color { get; set; }
        public MilitaryFactoryType.Type TechGroup { get; private set; }
        public ulong Manpower { get; set; }
        public int Cash { get; set; }
        public byte MaxLeaders {get; private set;}
        public int MaxTradeSlots { get; set; }
        public int DiploPoints { get; private set; }
        public CountryCharacteristics(Color color, MilitaryFactoryType.Type techGroup, int cash, int diploPoints, byte leaders)
        {
            this.Color = color;
            this.TechGroup = techGroup;
            this.Cash = cash;
            this.MaxLeaders = leaders;
            this.DiploPoints = diploPoints;
            this.MaxTradeSlots = 5;
        }
    }
}