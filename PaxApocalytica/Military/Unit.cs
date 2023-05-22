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

        public void Disband(string owner) 
        {
            if (Name == UnitName.Name.unmotorizedInfantry)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
            }     //0
            else if( Name == UnitName.Name.infantry1r) 
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][5] += (int)(50 * (HP / MaxHP));
            }         //1
            else if (Name == UnitName.Name.infantry2r)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][6] += (int)(50 * (HP / MaxHP));
            }         //2
            else if (Name == UnitName.Name.infantry1a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][15] += (int)(50 * (HP / MaxHP));
            }         //3
            else if (Name == UnitName.Name.infantry2a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][16] += (int)(50 * (HP / MaxHP));
            }         //4
            else if (Name == UnitName.Name.infantry1g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][23] += (int)(50 * (HP / MaxHP));
            }         //5
            else if (Name == UnitName.Name.infantry2g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][24] += (int)(50 * (HP / MaxHP));
            }         //6
                                                                  //
            else if (Name == UnitName.Name.tank1a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][11] += (int)(50 * (HP / MaxHP));
            }             //7
            else if (Name == UnitName.Name.tank2a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][12] += (int)(50 * (HP / MaxHP));
            }             //8
            else if (Name == UnitName.Name.tank3a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][13] += (int)(50 * (HP / MaxHP));
            }             //9
            else if (Name == UnitName.Name.tank4a)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][14] += (int)(50 * (HP / MaxHP));
            }             //10
                                                                  //
            else if (Name == UnitName.Name.tank1r)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][1] += (int)(50 * (HP / MaxHP));
            }             //11
            else if (Name == UnitName.Name.tank2r)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][2] += (int)(50 * (HP / MaxHP));
            }             //12
            else if (Name == UnitName.Name.tank3r)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][3] += (int)(50 * (HP / MaxHP));
            }             //13
            else if (Name == UnitName.Name.tank4r)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][4] += (int)(50 * (HP / MaxHP));
            }             //14
                                                                  //
            else if (Name == UnitName.Name.tank1g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][19] += (int)(50 * (HP / MaxHP));
            }             //15
            else if (Name == UnitName.Name.tank2g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][20] += (int)(50 * (HP / MaxHP));
            }             //16
            else if (Name == UnitName.Name.tank3g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][21] += (int)(50 * (HP / MaxHP));
            }             //17
            else if (Name == UnitName.Name.tank4g)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][22] += (int)(50 * (HP / MaxHP));
            }             //18
                                                                  //
            else if (Name == UnitName.Name.strikeAircraftA)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][18] += (int)(10 * (HP / MaxHP));
            }    //19
            else if (Name == UnitName.Name.strikeAircraftR)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][10] += (int)(10 * (HP / MaxHP));
            }    //20
            else if (Name == UnitName.Name.strikeAircraftG)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][26] += (int)(10 * (HP / MaxHP));
            }    //21
                                                                  //
            else if (Name == UnitName.Name.fighterA)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][17] += (int)(10 * (HP / MaxHP));
            }           //22
            else if (Name == UnitName.Name.fighterR)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][9] += (int)(10 * (HP / MaxHP));
            }           //23
            else if (Name == UnitName.Name.fighterG)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][56] += (int)(10 * (HP / MaxHP));
            }           //24
                                                                  //
            else if (Name == UnitName.Name.vdv1)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][7] += (int)(50 * (HP / MaxHP));
            }               //25
            else if (Name == UnitName.Name.vdv2)
            {
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][0] += (int)(10 * (HP / MaxHP));
                PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][8] += (int)(50 * (HP / MaxHP));
            }               //26
            //PaxApocalyticaGame.Dictionary_CountrynameMilitaryResources[owner][]
        }
    }

    public class Units
    {
        public static Dictionary<UnitName.Name, UnitCharacteristics> unitsCharacteristics = new Dictionary<UnitName.Name, UnitCharacteristics>
        {
            {
                UnitName.Name.unmotorizedInfantry,
                new UnitCharacteristics(10,100)
            },

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
            unmotorizedInfantry,
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
