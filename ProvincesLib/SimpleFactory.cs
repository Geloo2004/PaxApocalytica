using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincesLib
{
    public class SimpleFactory
    {
        public int BaseCost
        {
            get { return 4000; }
        }

        public byte MinEducation
        {
            get { return MinEducation; }
            private set
            {
                if (value >= 10 && value <= 100)
                {
                    MinEducation = value;
                }
                else if (value < 10)
                {
                    MinEducation = 10;
                }
                else
                {
                    MinEducation = 100;
                }
            }
        }

        public byte ExtensionLevel
        {
            get { return ExtensionLevel; }
            private set
            {
                if (value > 0 && value <= 10)
                {
                    ExtensionLevel = value;
                }
                else if (value <= 0)
                {
                    ExtensionLevel = 1;
                }
                else
                {
                    ExtensionLevel = 10;
                }
            }
        }

        public byte TechnologyLevel
        {
            get { return TechnologyLevel; }
            private set
            {
                if (value > 0 && value <= 10)
                {
                    TechnologyLevel = value;
                }
                else if (value <= 0)
                {
                    TechnologyLevel = 1;
                }
                else
                {
                    TechnologyLevel = 10;
                }
            }
        }

        public SimpleResources.Names ProducedRecourceName
        {
            get;
            private set;
        }

        public SimpleFactory(SimpleResources.Names name, byte extensionLevel, byte intensionLevel, byte minEducation)
        {
            this.ExtensionLevel = extensionLevel;
            this.TechnologyLevel = intensionLevel;
            this.ProducedRecourceName = name;
            this.MinEducation = minEducation;
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
            return (int)(BaseCost / 4 * TechnologyLevel * ExtensionLevel * ExtensionLevel * educationLevel / 100);
        }

        public int CalculateTUpgradeCost(byte educationLevel)
        {
            return (int)(BaseCost * ExtensionLevel * TechnologyLevel / 100 / educationLevel);
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
            resources[ProducedRecourceName]+=CalculateProduction();
        }
    }
}
