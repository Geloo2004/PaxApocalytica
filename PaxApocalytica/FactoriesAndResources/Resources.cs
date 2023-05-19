using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.FactoriesAndResources
{
    public class SimpleResources
    {
        public enum Names : byte
        {
            Oil,        //im 180        ex 60
            Steel,      //im 120        ex 40
            Copper,     //im 150        ex 50
            Uranium,    //im 1000       ex 100
            Coal,   //  //im 120        ex 40
            Grain,  //  //im 60         ex 20
            Livestock,  //im 75         ex 25
            Gas,    //  //im 150        ex 50
            Aluminium,  //im 120        ex 40
            Gold    //  //im 180        ex 60
        }
    }

    public class MilitaryResources
    {
        public enum Names : byte
        {
            Weaponry,   //Союз нерушимый республик свободных...
            T72B,
            T90A,
            T90M,
            T14,
            BMP2,
            BMP3,
            BMD1,
            BMD2,
            FighterR,
            StrikeAircraftR,         //USA! USA! USA!
            M1,
            M1A1,
            M1A2,
            M1A2C,
            M3A1,
            M3A3,
            FighterA,
            StrikeAircraftA,            //Generic
            T55,
            T55M,
            T72A,
            T72M,
            BMP1,
            BMP23,
            FighterG,
            StrikeAircraftG,
        }
    }

    public class MilitaryFactoryType
    {
        public enum Type : byte
        {
            Soviet,
            NATO,
            Generic
        }
    }
}
