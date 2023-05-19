using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.FactoriesAndResources
{
    public class SimpleFactory
    {
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
            if (ExtensionLevel > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsTUpgradePossible(byte educationLevel)
        {
            if (ExtensionLevel < 10)
            {
                return true;
            }
            return false;
        }
        public bool IsTDegradePossible(byte educationLevel)
        {
            if (ExtensionLevel > 0)
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
        }
        public void EDegrade()
        {
            ExtensionLevel--;
        }

        public void TUpgrade()
        {
            TechnologyLevel++;
        }
        public void TDegrade()
        {
            TechnologyLevel--;
        }

        public void Produce(ref Dictionary<SimpleResources.Names, float> resources)
        {
            resources[ProducedRecourceName] += CalculateProduction();
        }
    }
}
