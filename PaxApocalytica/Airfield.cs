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

        public void AddPlanesDivision(Unit unit) 
        {
            for(int i = 0; i < this.Planes.Length; i++) 
            {
                if (Planes[i] == null) 
                {
                    Planes[i] = unit; 
                    break;
                }
            }
        }
    }
}
