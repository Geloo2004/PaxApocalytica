using PaxApocalytica.Politics;
using System.Drawing;

namespace CountriesLib
{
    public class Country
    {
        static bool flag = true;
        private static Dictionary<string, CountryCharacteristics> countries = new Dictionary<string, CountryCharacteristics>
        {
            {
                "Russia",
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
                    0
                )
            },
        };

        public static CountryCharacteristics GetCC(string countryCode)
        {
            if (flag)
            {
                for (int i = 0; i < 300; i++)
                {
                    countries.Add(countryCode + Convert.ToString(i), new CountryCharacteristics
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
                        0
                    ));
                }
                flag = false;
            }
            if (countries.ContainsKey(countryCode))
            {
                return countries[countryCode];
            }
            throw new ArgumentException();
        }
    }

    public class CountryCharacteristics 
    {
        public Color Color { get; set; }
        public Ideology Ideology { get; set; }

        public byte TechGroup { get; set; }
        public uint Manpower { get; set; }
        public int Cash { get; set; }
        public CountryCharacteristics(Color color,Ideology ideology, byte techGroup)
        {
            this.Ideology = ideology;
            this.Color = color;
            this.TechGroup = techGroup;
        }
    }
}