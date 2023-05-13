using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaxApocalytica.FactoriesAndResources;

namespace PaxApocalytica
{
    public static class StartGenerator
    {
        public static Dictionary<Color, ProvincesName.Name> color_name = new Dictionary<Color, ProvincesName.Name>
        {
            {
                Color.FromArgb(1,0,0),
                ProvincesName.Name.alaska
            },

            {
                Color.FromArgb(2,0,0),
                ProvincesName.Name.yorkshire
            },

            {
                Color.FromArgb(3,0,0),
                ProvincesName.Name.london
            }
        };

        public static Dictionary<ProvincesName.Name, Province> name_province = new Dictionary<ProvincesName.Name, Province>
        {
            {
                ProvincesName.Name.alaska,
                new Province
                (
                    new Point[]
                    {
                        new Point(527,538)
                    },
                    "Alaska",
                    new SimpleFactory(SimpleResources.Names.Oil,2,5),
                    null,
                    90,
                    700000,
                    Country.Name.USA,
                    new ProvincesName.Name[]
                    {
                        ProvincesName.Name.yorkshire
                    }
                )
            }

        };
    }
}
