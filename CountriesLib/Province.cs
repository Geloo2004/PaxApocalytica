using System.Collections.Generic;
using System.Drawing;

namespace ProvincesLib
{
    public class Province
    {
        public List<Point> OriginPoints 
        {
            get { return OriginPoints; }
            private set 
            {
                OriginPoints = value;
                if(OriginPoints.Count == 0) 
                {
                    throw new ArgumentException();
                }
            }
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

        

        public Province(Point[] OriginPoints, string name, SimpleFactory simpleFactory, MilitaryFactory militaryFactory, byte educationLevel, uint population) 
        {
            this.OriginPoints = new List<Point>(OriginPoints);            
            this.Name = name;
            this.SimpleFactory = simpleFactory;
            this.MilitaryFactory = militaryFactory;
            this.EducationLevel = educationLevel;
        }

        public void IncreaseEducation(byte increment) 
        {
            EducationLevel += increment;
        }

        public void IncreasePopulation(int increment) 
        {
            Population+= increment;
        }

        public bool HasMilFactory() 
        {
            if(MilitaryFactory != null) 
            {
                return true;
            }
            return false;
        }
        public void BuildMilitaryFactory(MilitaryFactoryType.Type type, MilitaryResources.Names resource) 
        {
            MilitaryFactory = new MilitaryFactory(resource, 1, 1, 70, type);
        }
    }   
    
}