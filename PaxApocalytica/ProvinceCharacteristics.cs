using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Military;
using System.Collections.Generic;
using System.Drawing;

namespace PaxApocalytica
{
    public class ProvinceCharacteristics
    {
        public ulong Population { get; set; }
        public byte Eductaion { get; set; }
        public uint Manpower { get; set; }
        public byte EductaionEffort { get; set; }

        public ProvinceCharacteristics(ulong popul, byte ed, uint mp,byte edEff) 
        {
            this.Population = popul;
            this.Eductaion = ed; 
            if (Eductaion > 100) { Eductaion = 100; }
            if (Eductaion < 1) { Eductaion = 1; }


            this.EductaionEffort = edEff;
            if (EductaionEffort > 100) { EductaionEffort = 100; }
            if (EductaionEffort < 1) { EductaionEffort = 1; }
            this.Manpower = mp;
        }

        public int GetTaxes() 
        {
            return (int)(Population * 0.0001);
        }

        public void ChangeEductaion() 
        {
            if (EductaionEffort > Eductaion) { Eductaion++; }
            else if(EductaionEffort < Eductaion) { Eductaion--; }
        }
    }
}