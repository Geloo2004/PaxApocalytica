using PaxApocalytica.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.FactoriesAndResources
{
    public class MilitaryFactory
    {
        public bool IsFunctioning { get; set; }
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
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
            IsFunctioning = true;
        }

        public void ChangeProducedResource(MilitaryResources.Names newName) 
        {
            this.ProducedResourceName = newName;
        }
        private float CalculateProfitT()
        {
            return ExtensionLevel * (float)Math.Log(TechnologyLevel + 1);
        }
        private float CalculateProfitE()
        {
            return (ExtensionLevel + 1) * (float)Math.Log(TechnologyLevel);
        }

        public bool IsProduceable(MilitaryResources.Names name, MilitaryFactoryType.Type ownerFactoryType)
        {
            if(ownerFactoryType != FactoryType) { return false; } //нельзя производить на оккупированных территориях
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
            if (TechnologyLevel < 10)
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
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
            if (MinEducation < 70) { MinEducation = 70; }
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }
        public void TDegrade()
        {
            TechnologyLevel--;
            MinEducation = (byte)(90 - 5 * (10 - TechnologyLevel));
            if (MinEducation < 70) { MinEducation = 70; }
            Production = ExtensionLevel * (float)Math.Log(TechnologyLevel);
        }

        public void Produce(string owner)
        {
            if (IsFunctioning)
            {
                if (ProducedResourceName == MilitaryResources.Names.Weaponry)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] >= ExtensionLevel)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] -= ExtensionLevel;
                        PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)Production;
                    }
                    else { throw new Exception(); }
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
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] >= ExtensionLevel * 3
                        && PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] >= ExtensionLevel)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] -= ExtensionLevel * 3;
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] -= ExtensionLevel;
                        if (ProducedResourceName == MilitaryResources.Names.T72B) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][1] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T90A) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][2] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T90M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][3] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T14) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][4] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][11] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M1A1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][12] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M1A2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][13] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M1A2C) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][14] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T55) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][19] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T55M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][20] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T72A) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][21] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.T72M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][22] += (int)Production; }
                    }
                    else { throw new Exception(); }
                }
                else if (ProducedResourceName == MilitaryResources.Names.BMP2    //lavs
                    || ProducedResourceName == MilitaryResources.Names.BMP3
                    || ProducedResourceName == MilitaryResources.Names.M3A1
                    || ProducedResourceName == MilitaryResources.Names.M3A3
                    || ProducedResourceName == MilitaryResources.Names.BMP1
                    || ProducedResourceName == MilitaryResources.Names.BMP23)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] >= ExtensionLevel * 2
                            && PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] >= ExtensionLevel
                            && PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] >= ExtensionLevel)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1] -= ExtensionLevel * 2;
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] -= ExtensionLevel;
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] -= ExtensionLevel;
                        if (ProducedResourceName == MilitaryResources.Names.BMP2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][5] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.BMP3) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][6] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M3A1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][15] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.M3A3) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][16] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.BMP1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][23] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.BMP23) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][24] += (int)Production; }
                    }
                    else { throw new Exception(); }
                }
                else if (ProducedResourceName == MilitaryResources.Names.BMD1
                    || ProducedResourceName == MilitaryResources.Names.BMD2)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] >= ExtensionLevel
                        && PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] >= ExtensionLevel * 2)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] -= ExtensionLevel * 2;
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2] -= ExtensionLevel;
                        if (ProducedResourceName == MilitaryResources.Names.BMD1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][7] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.BMD2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][8] += (int)Production; }
                    }
                    else { throw new Exception(); }
                }
                else if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA
                    || ProducedResourceName == MilitaryResources.Names.StrikeAircraftR
                    || ProducedResourceName == MilitaryResources.Names.StrikeAircraftG)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] >= ExtensionLevel * 4)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] -= ExtensionLevel * 4;
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][10] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][18] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][26] += (int)Production; }
                    }
                    else { throw new Exception(); }
                }
                else if (ProducedResourceName == MilitaryResources.Names.FighterA
                    || ProducedResourceName == MilitaryResources.Names.FighterR
                    || ProducedResourceName == MilitaryResources.Names.FighterG)
                {
                    if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] >= ExtensionLevel * 3)
                    {
                        PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8] -= ExtensionLevel * 3;
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][9] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][17] += (int)Production; }
                        if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][25] += (int)Production; }
                    }
                    else { throw new Exception(); }
                }
                else
                {
                    throw new Exception("WTF");
                }
            }
        }
        public void Produce_Start(string owner)
        {
            if (ProducedResourceName == MilitaryResources.Names.Weaponry)
            {
                    PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)Production;
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
                
                    if (ProducedResourceName == MilitaryResources.Names.T72B) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][1] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T90A) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][2] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T90M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][3] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T14) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][4] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][11] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M1A1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][12] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M1A2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][13] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M1A2C) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][14] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T55) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][19] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T55M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][20] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T72A) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][21] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.T72M) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][22] += (int)Production; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.BMP2    //lavs
                || ProducedResourceName == MilitaryResources.Names.BMP3
                || ProducedResourceName == MilitaryResources.Names.M3A1
                || ProducedResourceName == MilitaryResources.Names.M3A3
                || ProducedResourceName == MilitaryResources.Names.BMP1
                || ProducedResourceName == MilitaryResources.Names.BMP23)
            {
                    if (ProducedResourceName == MilitaryResources.Names.BMP2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][5] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.BMP3) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][6] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M3A1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][15] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.M3A3) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][16] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.BMP1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][23] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.BMP23) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][24] += (int)Production; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.BMD1
                || ProducedResourceName == MilitaryResources.Names.BMD2)
            {
                    if (ProducedResourceName == MilitaryResources.Names.BMD1) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][7] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.BMD2) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][8] += (int)Production; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA
                || ProducedResourceName == MilitaryResources.Names.StrikeAircraftR
                || ProducedResourceName == MilitaryResources.Names.StrikeAircraftG)
            {
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][10] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][18] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][26] += (int)Production; }
            }
            else if (ProducedResourceName == MilitaryResources.Names.FighterA
                || ProducedResourceName == MilitaryResources.Names.FighterR
                || ProducedResourceName == MilitaryResources.Names.FighterG)
            {
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][9] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][17] += (int)Production; }
                    if (ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[owner][25] += (int)Production; }
            }
            else
            {
                throw new Exception("WTF");
            }
        }        
    }
}
