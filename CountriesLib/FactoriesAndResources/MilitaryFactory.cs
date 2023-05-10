using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesLib.FactoriesAndResources
{
    public class MilitaryFactory
    {
        public int BaseCost
        {
            get { return 10000; }
        }

        public byte MinEducation
        {
            get { return MinEducation; }
            private set
            {
                if (value >= 70 && value <= 100)
                {
                    MinEducation = value;
                }
                else if (value < 70)
                {
                    MinEducation = 70;
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

        public MilitaryResources.Names ProducedResourceName
        {
            get;
            private set;
        }

        public MilitaryFactoryType.Type FactoryType
        {
            get;
            private set;
        }

        public MilitaryFactory(MilitaryResources.Names name, byte extensionLevel, byte intensionLevel, byte minEducation, MilitaryFactoryType.Type factoryType)
        {
            ExtensionLevel = extensionLevel;
            TechnologyLevel = intensionLevel;
            ProducedResourceName = name;
            MinEducation = minEducation;
            FactoryType = factoryType;
        }

        public bool IsProduceable(MilitaryResources.Names name)
        {
            if (FactoryType == MilitaryFactoryType.Type.Soviet)
            {
                return IsProduceableR(name);
            }
            else if (FactoryType == MilitaryFactoryType.Type.NATO)
            {
                return IsProduceableA(name);
            }
            return false;
        }

        public bool IsProduceableR(MilitaryResources.Names name)
        {
            if (name == MilitaryResources.Names.Weaponry)
            {
                return true;
            }
            if (TechnologyLevel >= 8)
            {
                return true;
            }
            if (TechnologyLevel >= 2 && (name == MilitaryResources.Names.T1R || name == MilitaryResources.Names.BMP2 || name == MilitaryResources.Names.BMD1))
            {
                return true;
            }
            if (TechnologyLevel >= 4 && (name == MilitaryResources.Names.T2R || name == MilitaryResources.Names.BMP3 || name == MilitaryResources.Names.BMD2))
            {
                return true;
            }
            if (TechnologyLevel >= 6 && name == MilitaryResources.Names.T3R)
            {
                return true;
            }
            return false;
        }

        public bool IsProduceableA(MilitaryResources.Names name)
        {
            if (name == MilitaryResources.Names.Weaponry)
            {
                return true;
            }
            if (TechnologyLevel >= 8)
            {
                return true;
            }
            if (TechnologyLevel >= 2 && (name == MilitaryResources.Names.M1 || name == MilitaryResources.Names.M3A1))
            {
                return true;
            }
            if (TechnologyLevel >= 4 && (name == MilitaryResources.Names.M1A1 || name == MilitaryResources.Names.M3A3))
            {
                return true;
            }
            if (TechnologyLevel >= 6 && name == MilitaryResources.Names.M1A2)
            {
                return true;
            }
            return false;
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
                if (educationLevel >= 90 - 5 * (10 - TechnologyLevel + 1))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        // 90 - 5 * (10 - techLevel) ----- формула расчета минимально необходимого образования для пр-ва

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
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
        }
        public void TDegrade(ref CountryCharacteristics occupantCountryCharacteristics)
        {
            TechnologyLevel--;
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
            occupantCountryCharacteristics.Cash+=1000;
        }

        public void Produce(ref Dictionary<SimpleResources.Names, float> sr, ref Dictionary<MilitaryResources.Names, float> mr, ref bool noResources)
        {
            if (ProducedResourceName == MilitaryResources.Names.Weaponry)    //infantry weaponry
            {
                if (sr[SimpleResources.Names.Steel] >= ExtensionLevel)
                {
                    sr[SimpleResources.Names.Steel] -= ExtensionLevel;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.T1R        //tanks
                || ProducedResourceName == MilitaryResources.Names.T2R
                || ProducedResourceName == MilitaryResources.Names.T3R
                || ProducedResourceName == MilitaryResources.Names.T4R
                || ProducedResourceName == MilitaryResources.Names.M1
                || ProducedResourceName == MilitaryResources.Names.M1A1
                || ProducedResourceName == MilitaryResources.Names.M1A2
                || ProducedResourceName == MilitaryResources.Names.M1A2C)
            {
                if (sr[SimpleResources.Names.Steel] >= ExtensionLevel * 3
                    && sr[SimpleResources.Names.Copper] >= ExtensionLevel)
                {
                    sr[SimpleResources.Names.Steel] -= ExtensionLevel * 3;
                    sr[SimpleResources.Names.Copper] -= ExtensionLevel;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.BMP2    //lavs
                || ProducedResourceName == MilitaryResources.Names.BMP3
                || ProducedResourceName == MilitaryResources.Names.M3A1
                || ProducedResourceName == MilitaryResources.Names.M3A3)
            {
                if (sr[SimpleResources.Names.Steel] >= ExtensionLevel * 2
                    && sr[SimpleResources.Names.Copper] >= ExtensionLevel
                    && sr[SimpleResources.Names.Aluminium] >= ExtensionLevel)
                {
                    sr[SimpleResources.Names.Steel] -= ExtensionLevel * 2;
                    sr[SimpleResources.Names.Aluminium] -= ExtensionLevel;
                    sr[SimpleResources.Names.Copper] -= ExtensionLevel;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.BMD1
                || ProducedResourceName == MilitaryResources.Names.BMD2)
            {
                if (sr[SimpleResources.Names.Copper] >= ExtensionLevel
                    && sr[SimpleResources.Names.Aluminium] >= ExtensionLevel * 2)
                {
                    sr[SimpleResources.Names.Aluminium] -= ExtensionLevel * 2;
                    sr[SimpleResources.Names.Copper] -= ExtensionLevel;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA
                || ProducedResourceName == MilitaryResources.Names.StrikeAircraftR)
            {
                if (sr[SimpleResources.Names.Aluminium] >= ExtensionLevel * 4)
                {
                    sr[SimpleResources.Names.Aluminium] -= ExtensionLevel * 4;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else
            {
                throw new Exception("WTF");
            }
        }
    }
}
