using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincesLib
{
    public class ProvincesDictionary
    {
        public static Dictionary<Color, Province> provinces = new Dictionary<Color, Province> 
        {
            { Color.FromArgb(0,0,0,1),new Province
                (
                new Point[]
                {
                    new Point(0,0),new Point(1,0)
                },
                "Ocean",
                new SimpleFactory(  SimpleResources.Names.Steel     ,1,1,20),
                new MilitaryFactory(MilitaryResources.Names.Weaponry,1,1,70, MilitaryFactoryType.Type.NATO),
                40,
                1000000
                )
            }
        };
    }
}
