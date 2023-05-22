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
                if (ProducedRecourceName == SimpleResources.Names.Gas) { return 8000; }
                if (ProducedRecourceName == SimpleResources.Names.Oil) { return 8000; }
                if (ProducedRecourceName == SimpleResources.Names.Gold) { return 6000; }
                if (ProducedRecourceName == SimpleResources.Names.Grain) { return 2000; }
                if (ProducedRecourceName == SimpleResources.Names.Livestock) { return 2000; }
                if (ProducedRecourceName == SimpleResources.Names.Steel) { return 5000; }
                if (ProducedRecourceName == SimpleResources.Names.Coal) { return 4000; }
                if (ProducedRecourceName == SimpleResources.Names.Uranium) { return 10000; }
                if (ProducedRecourceName == SimpleResources.Names.Aluminium) { return 4000; }
                if (ProducedRecourceName == SimpleResources.Names.Copper) { return 4000; }
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

        public SimpleResources.Names ProducedRecourceName
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

            ProducedRecourceName = name;
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel); 
            IsFunctioning=true;
        }

        public bool IsEUpgradePossible(byte educationLevel)
        {
            if (ExtensionLevel != 10)
            {
                return false;
            }
            return true;
        }
        public bool IsEDegradePossible(byte educationLevel)
        {
            if (ExtensionLevel > 1)
            {
                return true;
            }
            return false;
        }

        public bool IsTUpgradePossible(byte educationLevel)
        {
            if (TechnologyLevel < 10)
            {
                return true;
            }
            return false;
        }
        public bool IsTDegradePossible(byte educationLevel)
        {
            if (TechnologyLevel > 1)
            {
                return true;
            }
            return false;
        }
        public int CalculateEUpgradeCost(byte educationLevel)
        {
            return BaseCost / 4 * TechnologyLevel * ExtensionLevel * ExtensionLevel * educationLevel / 100;
        }

        public int CalculateTUpgradeCost(byte educationLevel)
        {
            return BaseCost * ExtensionLevel * TechnologyLevel / 100 / educationLevel;
        }

        private float CalculateProduction()
        {
            return ExtensionLevel * (float)Math.Log(TechnologyLevel);
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
                if (ProducedRecourceName == SimpleResources.Names.Oil) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][0] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Steel) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][1] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Copper) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][2] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Uranium) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][3] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Coal) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][4] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Grain) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][5] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Livestock) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][6] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Gas) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][7] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Aluminium) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][8] += (int)Production; }
                else if (ProducedRecourceName == SimpleResources.Names.Gold) { PaxApocalyticaGame.Dictionary_CountrynameSimpleResources[owner][9] += (int)Production; }
                else throw new ArgumentException();
            }
        }
    }
}
