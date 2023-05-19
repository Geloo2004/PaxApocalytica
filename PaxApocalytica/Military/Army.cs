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

        public List<Unit> Units
        {
            get;
            private set;
        }

        public Army(string name)
        {
            Owner = name;
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            Units.Remove(unit);
        }
    }
}
