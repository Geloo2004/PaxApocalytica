using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.FactoriesAndResources
{
    public class SimpleFactory
    {
        public bool IsFunctioning { get; set; }
        public int BaseCost
        {
            get 
            {
                if (ProducedResourceName == SimpleResources.Names.Gas) { return 8000; }
                if (ProducedResourceName == SimpleResources.Names.Oil) { return 8000; }
                if (ProducedResourceName == SimpleResources.Names.Gold) { return 6000; }
                if (ProducedResourceName == SimpleResources.Names.Grain) { return 2000; }
                if (ProducedResourceName == SimpleResources.Names.Livestock) { return 2000; }
                if (ProducedResourceName == SimpleResources.Names.Steel) { return 5000; }
                if (ProducedResourceName == SimpleResources.Names.Coal) { return 4000; }
                if (ProducedResourceName == SimpleResources.Names.Uranium) { return 10000; }
                if (ProducedResourceName == SimpleResources.Names.Aluminium) { return 4000; }
                if (ProducedResourceName == SimpleResources.Names.Copper) { return 4000; }
                return 0;
            }
        }
        public float Production { get; set; }
        public byte ExtensionLevel
        {
            get;
            private set;
        }

        public byte TechnologyLevel
        {
            get;
            private set;
        }

        public SimpleResources.Names ProducedResourceName
        {
            get;
            private set;
        }

        public SimpleFactory(SimpleResources.Names name, byte technologyLevel, byte extensionLevel)
        {
            if (extensionLevel <= 0) { ExtensionLevel = 1; }
            else if (extensionLevel > 10) { ExtensionLevel = 10; }
            else { ExtensionLevel = extensionLevel; }

            if (technologyLevel <= 0) { TechnologyLevel = 1; }
            else if (technologyLevel > 10) { TechnologyLevel = 10; }
            else { TechnologyLevel = technologyLevel; }

            ProducedResourceName = name;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel); 
            IsFunctioning=false;
        }

        public bool IsEUpgradePossible()
        {
            if (ExtensionLevel != 10)
            {
                return false;
            }
            return true;
        }
        public bool IsEDegradePossible()
        {
            if (ExtensionLevel > 1)
            {
                return true;
            }
            return false;
        }

        public bool IsTUpgradePossible()
        {
            if (TechnologyLevel < 10)
            {
                return true;
            }
            return false;
        }
        public bool IsTDegradePossible()
        {
            if (TechnologyLevel > 1)
            {
                return true;
            }
            return false;
        }
        public int CalculateEUpgradeCost(byte educationLevel)
        {
            return Convert.ToInt32(BaseCost / 4 * TechnologyLevel * ExtensionLevel * ExtensionLevel * ((decimal)educationLevel / 100));
        }

        public int CalculateTUpgradeCost(byte educationLevel)
        {
            return Convert.ToInt32(BaseCost * ExtensionLevel * TechnologyLevel  / (((decimal)educationLevel / 100)));
        }

        private float CalculateProductionGrowthT()
        {
            return ExtensionLevel * (float)Math.Log(TechnologyLevel + 1) - Production;
        }
        private float CalculateProductionGrowthE()
        {
            return (ExtensionLevel + 1) * (float)Math.Log(TechnologyLevel) - Production;
        }

        public void EUpgrade()
        {
            ExtensionLevel++;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }
        public void EDegrade()
        {
            ExtensionLevel--;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }

        public void TUpgrade()
        {
            TechnologyLevel++;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }
        public void TDegrade()
        {
            TechnologyLevel--;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }
        public void Produce(string owner)
        {
            if (IsFunctioning)
            {
                if (ProducedResourceName == SimpleResources.Names.Oil) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][0] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Steel) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Copper) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Uranium) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][3] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Coal) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][4] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Grain) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][5] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Livestock) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][6] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Gas) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][7] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Aluminium) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] += (int)Production; }
                else if (ProducedResourceName == SimpleResources.Names.Gold) { PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][9] += (int)Production; }
                else throw new ArgumentException();
            }
        }
    }
}
