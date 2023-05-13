using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Military;
using System.Collections.Generic;
using System.Drawing;

namespace PaxApocalytica
{
    public class Province
    {
        public List<Point> OriginPoints
        {
            get { return OriginPoints; }
            private set
            {
                OriginPoints = value;
                if (OriginPoints.Count == 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        public List<Army> Armies
        {
            get;
            private set;
        }

        public List<ProvincesName.Name> Neighbours
        {
            get;
            private set;
        }

        public bool HasAirfield
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public SimpleFactory SimpleFactory
        {
            get;
            private set;
        }

        public MilitaryFactory MilitaryFactory
        {
            get;
            private set;
        }

        public byte EducationLevel
        {
            get { return EducationLevel; }
            private set
            {
                if (value > 0 && value <= 100)
                {
                    EducationLevel = value;
                }
                else if (value <= 0)
                {
                    EducationLevel = 1;
                }
                else
                {
                    EducationLevel = 100;
                }
            }
        }

        public long Population
        {
            get { return Population; }
            set
            {
                if (value < 0)
                {
                    Population = 0;
                }
                else { Population = value; }
            }
        }

        public Country.Name OwnerCountry
        {
            get;
            private set;
        }

        public Country.Name OccupantCountry
        {
            get;
            private set;
        }

        public byte AIWeight
        {
            get;
            private set;
        }

        public byte PortLevel
        {
            get;
            private set;
        }

        public Province(Point[] OriginPoints,
            string name,
            SimpleFactory simpleFactory,
            MilitaryFactory militaryFactory,
            byte educationLevel,
            uint population,
            Country.Name owner,
            ProvincesName.Name[] neighbours)
        {
            this.OriginPoints = new List<Point>(OriginPoints);
            Neighbours = new List<ProvincesName.Name>(neighbours);
            Name = name;
            SimpleFactory = simpleFactory;
            MilitaryFactory = militaryFactory;
            EducationLevel = educationLevel;
            OwnerCountry = owner;
            OccupantCountry = owner;
            PortLevel = 0;
            CalculateAiWeight();
        }

        public Province(Point[] OriginPoints,
            string name,
            SimpleFactory simpleFactory,
            MilitaryFactory militaryFactory,
            byte educationLevel,
            uint population,
            Country.Name owner,
            ProvincesName.Name[] neighbours,
            byte portLevel)
        {
            this.OriginPoints = new List<Point>(OriginPoints);
            Neighbours = new List<ProvincesName.Name>(neighbours);
            Name = name;
            SimpleFactory = simpleFactory;
            MilitaryFactory = militaryFactory;
            EducationLevel = educationLevel;
            OwnerCountry = owner;
            OccupantCountry = owner;
            PortLevel = portLevel;
            CalculateAiWeight();
        }

        public void CalculateAiWeight()
        {
            for (int i = 0; i < SimpleFactory.ExtensionLevel; i++)
            {
                AIWeight++;
            }
            for (int i = 0; i < SimpleFactory.TechnologyLevel; i++)
            {
                AIWeight += 3;
            }
            if (MilitaryFactory != null)
            {
                for (int i = 0; i < MilitaryFactory.ExtensionLevel; i++)
                {
                    AIWeight += 2;
                }
                for (int i = 0; i < MilitaryFactory.TechnologyLevel; i++)
                {
                    AIWeight += 6;
                }
            }
            if (HasAirfield) { AIWeight += 30; }
            AIWeight += PortLevel;
        }

        public void Occupy(Country.Name occupant)
        {
            OccupantCountry = occupant;
        }

        public void Conquer(Country.Name conqueror)
        {
            OwnerCountry = conqueror;
        }

        public void IncreaseEducation(byte increment)
        {
            EducationLevel += increment;
        }

        public void IncreasePopulation(int increment)
        {
            Population += increment;
        }

        public bool HasMilFactory()
        {
            if (MilitaryFactory != null)
            {
                return true;
            }
            return false;
        }
        public void BuildMilitaryFactory(MilitaryFactoryType.Type type, MilitaryResources.Names resource)
        {
            MilitaryFactory = new MilitaryFactory(resource, 1, 1, type);
        }
    }
    public static class ProvincesName
    {
        public enum Name
        {
            yorkshire,
            london,
            alaska
        }
    }
}