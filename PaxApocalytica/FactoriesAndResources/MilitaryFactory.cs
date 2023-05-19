using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.FactoriesAndResources
{
    public class MilitaryFactory
    {
        public int BaseCost
        {
            get { return 10000; }
        }

        public float Production 
        {
            get;
            set;
        }

        public byte MinEducation
        {
            get;
            private set;
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

        public MilitaryFactory(MilitaryResources.Names name, byte technologyLevel, byte extensionLevel, MilitaryFactoryType.Type factoryType)
        {
            if (extensionLevel <= 0) { ExtensionLevel = 1; }
            else if (extensionLevel > 10) { ExtensionLevel = 10; }
            else { ExtensionLevel = extensionLevel; }

            if (technologyLevel <= 0) { TechnologyLevel = 1; }
            else if (technologyLevel > 10) { TechnologyLevel = 10; }
            else { TechnologyLevel = technologyLevel; }

            ProducedResourceName = name;
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
            if (MinEducation < 70) { MinEducation = 70; }
            FactoryType = factoryType;
        }

        public void ChangeProducedResource(MilitaryResources.Names newName) 
        {
            this.ProducedResourceName = newName;
        }

        public bool IsProduceable(MilitaryResources.Names name, MilitaryFactoryType.Type ownerFactoryType)
        {
            if(ownerFactoryType != FactoryType) { return false; }//нельзя производить на оккупированных территориях
            if (FactoryType == MilitaryFactoryType.Type.Soviet)
            {
                return IsProduceableR(name);
            }
            else if (FactoryType == MilitaryFactoryType.Type.NATO)
            {
                return IsProduceableA(name);
            }
            else 
            {
                return IsProduceableG(name);
            }
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
            if (TechnologyLevel >= 2 && (name == MilitaryResources.Names.T72B || name == MilitaryResources.Names.BMP2 || name == MilitaryResources.Names.BMD1))
            {
                return true;
            }
            if (TechnologyLevel >= 4 && (name == MilitaryResources.Names.T90A || 
                name == MilitaryResources.Names.BMP3 || 
                name == MilitaryResources.Names.BMD2||
                name == MilitaryResources.Names.FighterR ||
                name == MilitaryResources.Names.StrikeAircraftR))
            {
                return true;
            }
            if (TechnologyLevel >= 6 && name == MilitaryResources.Names.T90M)
            {
                return true;
            }
            return false;
        }
        public bool IsProduceableG(MilitaryResources.Names name)
        {
            if (name == MilitaryResources.Names.Weaponry)
            {
                return true;
            }
            if (TechnologyLevel >= 8)
            {
                return true;
            }
            if (TechnologyLevel >= 2 && (name == MilitaryResources.Names.T55 || name == MilitaryResources.Names.BMP1))
            {
                return true;
            }
            if (TechnologyLevel >= 4 && (name == MilitaryResources.Names.T55M || 
                name == MilitaryResources.Names.BMP23 || 
                name==MilitaryResources.Names.FighterG || 
                name == MilitaryResources.Names.StrikeAircraftG))
            {
                return true;
            }
            if (TechnologyLevel >= 6 && name == MilitaryResources.Names.T72A)
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
            if (TechnologyLevel >= 4 && (name == MilitaryResources.Names.M1A1 || 
                name == MilitaryResources.Names.M3A3 ||
                name == MilitaryResources.Names.FighterA ||
                name == MilitaryResources.Names.StrikeAircraftA))
            {
                return true;
            }
            if (TechnologyLevel >= 6 && name == MilitaryResources.Names.M1A2)
            {
                return true;
            }
            return false;
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

        public bool IsTDegradePossible(byte educationLevel) //edLev - ур образования в провинции
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
            if (MinEducation < 70) { MinEducation = 70; }
        }
        public void TDegrade(ref CountryCharacteristics occupantCountryCharacteristics)
        {
            TechnologyLevel--;
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
            if (MinEducation < 70) { MinEducation = 70; }
            occupantCountryCharacteristics.Cash += 1000;
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
            else if (ProducedResourceName == MilitaryResources.Names.T72B        //tanks
                || ProducedResourceName == MilitaryResources.Names.T90A
                || ProducedResourceName == MilitaryResources.Names.T90M
                || ProducedResourceName == MilitaryResources.Names.T14
                || ProducedResourceName == MilitaryResources.Names.M1
                || ProducedResourceName == MilitaryResources.Names.M1A1
                || ProducedResourceName == MilitaryResources.Names.M1A2
                || ProducedResourceName == MilitaryResources.Names.M1A2C
                || ProducedResourceName == MilitaryResources.Names.T55
                || ProducedResourceName == MilitaryResources.Names.T55M
                || ProducedResourceName == MilitaryResources.Names.T72A
                || ProducedResourceName == MilitaryResources.Names.T72M)
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
                || ProducedResourceName == MilitaryResources.Names.M3A3
                || ProducedResourceName == MilitaryResources.Names.BMP1
                || ProducedResourceName == MilitaryResources.Names.BMP23)
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
                || ProducedResourceName == MilitaryResources.Names.StrikeAircraftR
                || ProducedResourceName == MilitaryResources.Names.StrikeAircraftG)
            {
                if (sr[SimpleResources.Names.Aluminium] >= ExtensionLevel * 4)
                {
                    sr[SimpleResources.Names.Aluminium] -= ExtensionLevel * 4;
                    mr[ProducedResourceName] += CalculateProduction();
                }
                else { noResources = true; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.FighterA
                || ProducedResourceName == MilitaryResources.Names.FighterG
                || ProducedResourceName == MilitaryResources.Names.FighterR)
            {
                if (sr[SimpleResources.Names.Aluminium] >= ExtensionLevel * 3)
                {
                    sr[SimpleResources.Names.Aluminium] -= ExtensionLevel * 3;
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
