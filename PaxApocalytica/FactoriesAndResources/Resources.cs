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
            Oil,        //im 180        ex 60   0
            Steel,      //im 120        ex 40   1
            Copper,     //im 150        ex 50   2
            Uranium,    //im 1000       ex 100  3
            Coal,   //  //im 120        ex 40   4
            Grain,  //  //im 60         ex 20   5
            Livestock,  //im 75         ex 25   6
            Gas,    //  //im 150        ex 50   7
            Aluminium,  //im 120        ex 40   8
            Gold    //  //im 180        ex 60   9
        }
    }

    public class MilitaryResources
    {
        public enum Names : byte
        {
            Weaponry,           //0
            T72B,               //1
            T90A,               //2
            T90M,               //3
            T14,                //4
            BMP2,               //5
            BMP3,               //6
            BMD1,               //7
            BMD2,               //8
            FighterR,           //9
            StrikeAircraftR,    //10
            M1,                 //11
            M1A1,               //12
            M1A2,               //13
            M1A2C,              //14
            M3A1,               //15
            M3A3,               //16
            FighterA,           //17
            StrikeAircraftA,    //18
            T55,                //19
            T55M,               //20
            T72A,               //21
            T72M,               //22
            BMP1,               //23
            BMP23,              //24
            FighterG,           //25
            StrikeAircraftG,    //26
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
