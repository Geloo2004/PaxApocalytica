using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.Military
{
    public class Army
    {
        public string Owner
        {
            get;
            private set;
        }

        public Unit[] Units
        {
            get;
            private set;
        }

        public Army(string name)
        {
            Owner = name;
            Units = new Unit[16];
        }

        public void AddUnit(Unit unit,int index)
        {
            this.Units[index] = unit;
        }

        public void DeleteUnit(int index)
        {
            //this.Units[index].
            this.Units[index] = null;
        }
    }
}
