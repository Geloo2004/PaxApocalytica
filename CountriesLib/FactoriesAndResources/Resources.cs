using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesLib.FactoriesAndResources
{
    public class SimpleResources
    {
        public enum Names : byte
        {
            Oil,
            Steel,
            Copper,
            Uranium,
            Coal,   //
            Grain,  //
            Livestock,  //
            Gas,    //
            Aluminium,
            Wood,   //
            Gold    //
        }
    }

    public class MilitaryResources
    {
        public enum Names : byte
        {
            Weaponry,   //Союз нерушимый республик свободных...
            T1R,
            T2R,
            T3R,
            T4R,
            BMP2,
            BMP3,
            BMD1,
            BMD2,
            FighterR,
            StrikeAircraftR,
            //USA! USA! USA!
            M1,
            M1A1,
            M1A2,
            M1A2C,
            M3A1,
            M3A3,
            FighterA,
            StrikeAircraftA,//Ching cheng hanji?
        }
    }

    public class MilitaryFactoryType
    {
        public enum Type : byte
        {
            Soviet,
            NATO,
            none
        }
    }
}
