﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.Military
{
    public class Army
    {
        public bool IsMoved
        {
            get;
            set;
        }
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

        public Army(string owner, bool isMoved)
        {
            this.Owner = owner;
            Units = new Unit[16];
            this.IsMoved = isMoved;
        }

        public void AddUnit(Unit unit, int index)
        {
            this.Units[index] = unit;
        }

        public void DeleteUnit(int index)
        {
            this.Units[index] = null;
        }

        public bool CheckAllDead()
        {
            foreach (var unit in Units)
            {
                if (unit != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
