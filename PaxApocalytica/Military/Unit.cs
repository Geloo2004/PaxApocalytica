using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.Military
{
    public class Unit
    {
        public UnitName.Name Name
        {
            get;
            private set;
        }

        public float HP
        {
            get;
            private set;
        }
        public int MaxHP
        {
            get;
            private set;
        }

        public Unit(UnitName.Name name)
        {
            Name = name;
            HP = Units.unitsCharacteristics[name].HP;
            MaxHP = (int)HP;
        }

        public float GetDamage()
        {
            return Units.unitsCharacteristics[Name].Damage * (float)HP;
        }

        public void ApplyDamage(float damage)
        {
            HP -= damage;
        }
    }

    public class Units
    {
        public static Dictionary<UnitName.Name, UnitCharacteristics> unitsCharacteristics = new Dictionary<UnitName.Name, UnitCharacteristics>
        {
            {
                UnitName.Name.infantry1r,
                new UnitCharacteristics(10,100)
            },

            {
                UnitName.Name.infantry2r,
                new UnitCharacteristics(20,120)
            },

            {
                UnitName.Name.tank1r,
                new UnitCharacteristics(30,200)
            },

            {
                UnitName.Name.tank2r,
                new UnitCharacteristics(30,250)
            },

            {
                UnitName.Name.tank3r,
                new UnitCharacteristics(30,300)
            },

            {
                UnitName.Name.tank4r,
                new UnitCharacteristics(50,500)
            },

            {
                UnitName.Name.vdv1,
                new UnitCharacteristics(20,120)
            },

            {
                UnitName.Name.vdv2,
                new UnitCharacteristics(20,140)
            },




            
            {
                UnitName.Name.infantry1a,
                new UnitCharacteristics(10,100)
            },

            {
                UnitName.Name.infantry2a,
                new UnitCharacteristics(15,120)
            },

            {
                UnitName.Name.tank1a,
                new UnitCharacteristics(30,200)
            },

            {
                UnitName.Name.tank2a,
                new UnitCharacteristics(30,300)
            },

            {
                UnitName.Name.tank3a,
                new UnitCharacteristics(40,350)
            },

            {
                UnitName.Name.tank4a,
                new UnitCharacteristics(40,400)
            },


            {
                UnitName.Name.infantry1g,
                new UnitCharacteristics(10,80)
            },

            {
                UnitName.Name.infantry2g,
                new UnitCharacteristics(15,100)
            },

            {
                UnitName.Name.tank1g,
                new UnitCharacteristics(25,120)
            },

            {
                UnitName.Name.tank2g,
                new UnitCharacteristics(25,150)
            },

            {
                UnitName.Name.tank3g,
                new UnitCharacteristics(30,180)
            },

            {
                UnitName.Name.tank4g,
                new UnitCharacteristics(30,220)
            },

            {
                UnitName.Name.fighterA,
                new UnitCharacteristics(10,100)
            },

            {
                UnitName.Name.fighterR,
                new UnitCharacteristics(10,100)
            },

            {
                UnitName.Name.fighterG,
                new UnitCharacteristics(8,80)
            },
            {
                UnitName.Name.strikeAircraftA,
                new UnitCharacteristics(25,120)
            },

            {
                UnitName.Name.strikeAircraftR,
                new UnitCharacteristics(20,120)
            },

            {
                UnitName.Name.strikeAircraftG,
                new UnitCharacteristics(20,100)
            }
        };

    }

    public static class UnitName
    {
        public enum Name
        {
            infantry1r,
            infantry2r,
            tank1r,
            tank2r,
            tank3r,
            tank4r,
            vdv1,
            vdv2,
            infantry1a,
            infantry2a,
            tank1a,
            tank2a,
            tank3a,
            tank4a,
            infantry1g,
            infantry2g,
            tank1g,
            tank2g,
            tank3g,
            tank4g,
            fighterA, 
            fighterR, 
            fighterG,
            strikeAircraftA,
            strikeAircraftR,
            strikeAircraftG
        }
    }

    public class UnitCharacteristics
    {
        public int Damage
        {
            get;
            private set;
        }
        public int HP
        {
            get;
            private set;
        }

        public UnitCharacteristics(int damage, int hp)
        {
            if (damage <= 0 || hp <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                HP = hp;
                Damage = damage;
            }
        }

        public int GetHP()
        {
            return HP;
        }

        public int GetDmg()
        {
            return Damage;
        }
    }
}
