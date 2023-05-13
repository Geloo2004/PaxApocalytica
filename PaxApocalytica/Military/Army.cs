using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.Military
{
    public class Army
    {
        public Country.Name Owner
        {
            get;
            private set;
        }

        public List<Unit> Units
        {
            get;
            private set;
        }

        public Army(Country.Name name)
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
