using PaxApocalytica.Military;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica
{
    public class Airfield
    {
        public Unit[] Planes 
        {
            get;
            private set;
        }

        public Airfield(byte size) 
        {
            this.Planes = new Unit[size];
            for(int i=0; i< size;i++) 
            {
                Planes[i] = null;
            }
        }

        public bool HasBombers() 
        {
            foreach(var plane in  Planes) 
            {
                if( plane.Name == UnitName.Name.strikeAircraftA || 
                    plane.Name == UnitName.Name.strikeAircraftR || 
                    plane.Name == UnitName.Name.strikeAircraftG) { return true; }
            }
            return false;
        }
        public bool HasFighters()
        {
            foreach (var plane in Planes)
            {
                if (plane.Name == UnitName.Name.fighterA ||
                    plane.Name == UnitName.Name.fighterR ||
                    plane.Name == UnitName.Name.fighterG) { return true; }
            }
            return false;
        }
        public void SendBomber(int id) 
        {
            
        }

        public void SendFighter(int id)
        {
            
        }

        public bool AllSlotsFilled() 
        { 
            foreach(var plane in Planes) 
            {
                if (plane == null) { return false; }
            }
            return true;
        }

        public void AddPlanesDivision(Unit unit) 
        {
            
        }

        public void Reinforce() 
        {
            foreach(var plane in Planes) 
            {
                if (plane.HP < plane.MaxHP) 
                {
                    
                }
            }
        }
    }
}
