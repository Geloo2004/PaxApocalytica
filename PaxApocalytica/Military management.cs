using PaxApocalytica.Military;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaxApocalytica
{
    public partial class Military_management : Form
    {
        static int selectedIndex = -1;
        static string country;
        static PaxApocalypticaGame pagLauncher;

        public Military_management(string owner, PaxApocalypticaGame PAGLauncher)
        {
            InitializeComponent();
            this.MinimumSize = new Size(586, 420);
            this.MaximumSize = new Size(586, 420);
            location.Text = "";
            pagLauncher = PAGLauncher;
            country = owner;

            armyNumber.Minimum = 1;
            armyNumber.Maximum = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].MaxLeaders;

            UpdateArmyUnits();
            UpdateMResources();
            {
                button1.Text = "Infantry";
                button2.Text = "Sov. Tanks I";
                button3.Text = "Sov. Tanks II";
                button4.Text = "Sov. Tanks III";
                button5.Text = "Sov. Tanks IV";
                button6.Text = "Sov. Inf I";
                button7.Text = "Sov. Inf II";
                button8.Text = "VDV I";
                button9.Text = "VDV II";
                button10.Text = "NATO Tanks I";
                button11.Text = "NATO Tanks II";
                button12.Text = "NATO Tanks III";
                button13.Text = "NATO Tanks IV";
                button14.Text = "NATO Inf I";
                button15.Text = "NATO Inf II";
                button16.Text = "G. Tanks I";
                button17.Text = "G. Tanks II";
                button18.Text = "G. Tanks III";
                button19.Text = "G. Tanks IV";
                button20.Text = "G. Inf I";
                button21.Text = "G. Inf II";
            }
            Calculator.RecalculateCanBuildUnit(country);

            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(country + " Army " + 1))
            {
                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[country + " Army " + 1].Units.Contains(null)) { ShowCanBuild(); }
                else { HideCanBuild(); }
            }
            else { ShowCanBuild(); }

            DeployReinforceButtonCheck(country + " Army " + 1);
        }

        public void UpdateArmyUnits()
        {
            armyUnits.Items.Clear();
            if (country != "")
            {
                armyUnits.Items.Clear();

                string armyName = country + " Army " + armyNumber.Value;
                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                {
                    foreach (var unit in PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units)
                    {
                        if (unit != null)
                        {
                            if (unit.Name == Military.UnitName.Name.unmotorizedInfantry) { armyUnits.Items.Add("Infantry" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry1r) { armyUnits.Items.Add("Sov. Inf. I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry2r) { armyUnits.Items.Add("Sov. Inf. II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank1r) { armyUnits.Items.Add("Sov. Tanks I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank2r) { armyUnits.Items.Add("Sov. Tanks II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank3r) { armyUnits.Items.Add("Sov. Tanks III" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank4r) { armyUnits.Items.Add("Sov. Tanks IV" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.vdv1) { armyUnits.Items.Add("VDV I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.vdv2) { armyUnits.Items.Add("VDV II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry1a) { armyUnits.Items.Add("NATO Inf. I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry2a) { armyUnits.Items.Add("NATO Inf. II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank1a) { armyUnits.Items.Add("NATO Tanks I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank2a) { armyUnits.Items.Add("NATO Tanks II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank3a) { armyUnits.Items.Add("NATO Tanks III" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank4a) { armyUnits.Items.Add("NATO Tanks IV" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry1g) { armyUnits.Items.Add("Generic Inf. I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.infantry2g) { armyUnits.Items.Add("Generic Inf. II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank1g) { armyUnits.Items.Add("Generic Tanks I" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank2g) { armyUnits.Items.Add("Generic Tanks II" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank3g) { armyUnits.Items.Add("Generic Tanks III" + " HP: " + unit.HP); }
                            else if (unit.Name == Military.UnitName.Name.tank4g) { armyUnits.Items.Add("Generic Tanks IV" + " HP: " + unit.HP); }
                            else { throw new ArgumentException(); }
                        }
                    }
                }
                else
                {
                    armyUnits.Items.Add("");
                }
                if (armyUnits.Items.Count < 16) { ShowCanBuild(); }
                else { HideCanBuild(); }
            }
        }

        public void UpdateMResources()
        {
            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label2.Text = "T-72B: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1];
            label3.Text = "T-90A: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][2];
            label4.Text = "T-90M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][3];
            label5.Text = "T-14: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][4];
            label6.Text = "BMP-2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5];
            label7.Text = "BMP-3: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][6];
            label8.Text = "BMD-1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][7];
            label9.Text = "BMD-2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][8];
            label12.Text = "M1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11];
            label13.Text = "M1A1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][12];
            label14.Text = "M1A2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][13];
            label15.Text = "M1A2C: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][14];
            label16.Text = "M3A1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15];
            label17.Text = "M3A3: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][16];
            label20.Text = "T-55: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19];
            label21.Text = "T-55M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][20];
            label22.Text = "T-72A: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][21];
            label23.Text = "T-72M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][22];
            label24.Text = "BMP-1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23];
            label25.Text = "BMP-23: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][24];
        }

        private void ShowCanBuild()
        {
            button1.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][0];
            button6.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][1];
            button7.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][2];
            button14.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][3];
            button15.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][4];
            button20.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][5];
            button21.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][6];
            button10.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][7];
            button11.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][8];
            button12.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][9];
            button13.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][10];
            button2.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][11];
            button3.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][12];
            button4.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][13];
            button5.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][14];
            button16.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][15];
            button17.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][16];
            button18.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][17];
            button19.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][18];

            button8.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][25];
            button9.Enabled = PaxApocalypticaGame.Dictionary_CanBuildUnit[country][26];
        }
        private void HideCanBuild()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
        }

        private void DeployReinforceButtonCheck(string armyName)
        {
            if (Calculator.CheckArmyDeployed(armyName))
            {
                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].IsMoved) { deployReinforceBttn.Enabled = false; }
                else { deployReinforceBttn.Enabled = true; }
                deployReinforceBttn.Text = "Move army";
                location.Text = Calculator.FindArmyStartProv(armyName);

                if (PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[country][0] <= Calculator.CalculateMovingCost(armyName))
                {
                    deployReinforceBttn.Enabled = false;
                }
            }
            else if (Calculator.CheckArmyCreated(armyName))
            {
                deployReinforceBttn.Text = "Deploy";
                armyNumber.Enabled = false;
                deployReinforceBttn.Enabled = true;
                location.Hide();
            }
            else
            {
                deployReinforceBttn.Text = "Army not created";
                deployReinforceBttn.Enabled = false;
                location.Hide();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            armyUnits.Items.Clear();

            string armyName = country + " Army " + armyNumber.Value;

            DeployReinforceButtonCheck(armyName);
            UpdateArmyUnits();
        }

        private void deployReinforceBttn_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            if (deployReinforceBttn.Text == "Deploy")
            {

                PaxApocalypticaGame.deployingArmy = true;
                PaxApocalypticaGame.deployingArmyName = armyName;
                this.Hide();
                armyNumber.Enabled = true;
            }
            else if (deployReinforceBttn.Text == "Move army")
            {
                this.Hide();
                PaxApocalypticaGame.movingArmy = true;
                PaxApocalypticaGame.movingArmyName = armyName;
                PaxApocalypticaGame.armyStartProv = Calculator.FindArmyStartProv(armyName);

                Color targetColor = PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Color;
                foreach (var point in PaxApocalypticaGame.Dictionary_NamesPoints[PaxApocalypticaGame.armyStartProv])
                {
                    pagLauncher.FloodFill(PaxApocalypticaGame.baseBitmap, point, targetColor, Color.White);
                }

            }
            else if (deployReinforceBttn.Text == "Disband unit")
            {
                if (armyUnits.SelectedItem != null)
                {
                    string pickedUnit = armyUnits.SelectedItem.ToString();
                    string[] subStrings = pickedUnit.Split(" HP: ");
                    int hp = Convert.ToInt32(subStrings[1]);
                    Military.UnitName.Name unitname;

                    if (subStrings[0] == "Infantry") { unitname = Military.UnitName.Name.unmotorizedInfantry; }
                    else if (subStrings[0] == "Sov. Tanks I") { unitname = Military.UnitName.Name.tank1r; }
                    else if (subStrings[0] == "Sov. Tanks II") { unitname = Military.UnitName.Name.tank2r; }
                    else if (subStrings[0] == "Sov. Tanks III") { unitname = Military.UnitName.Name.tank3r; }
                    else if (subStrings[0] == "Sov. Tanks IV") { unitname = Military.UnitName.Name.tank4r; }
                    else if (subStrings[0] == "Sov. Inf. I") { unitname = Military.UnitName.Name.infantry1r; }
                    else if (subStrings[0] == "Sov. Inf. II") { unitname = Military.UnitName.Name.infantry2r; }
                    else if (subStrings[0] == "VDV I") { unitname = Military.UnitName.Name.vdv1; }
                    else if (subStrings[0] == "VDV II") { unitname = Military.UnitName.Name.vdv2; }
                    else if (subStrings[0] == "NATO Tanks I") { unitname = Military.UnitName.Name.tank1a; }
                    else if (subStrings[0] == "NATO Tanks II") { unitname = Military.UnitName.Name.tank2a; }
                    else if (subStrings[0] == "NATO Tanks III") { unitname = Military.UnitName.Name.tank3a; }
                    else if (subStrings[0] == "NATO Tanks IV") { unitname = Military.UnitName.Name.tank4a; }
                    else if (subStrings[0] == "NATO Inf. I") { unitname = Military.UnitName.Name.infantry1a; }
                    else if (subStrings[0] == "NATO Inf. II") { unitname = Military.UnitName.Name.infantry2a; }
                    else if (subStrings[0] == "Generic Tanks I") { unitname = Military.UnitName.Name.tank1g; }
                    else if (subStrings[0] == "Generic Tanks II") { unitname = Military.UnitName.Name.tank2g; }
                    else if (subStrings[0] == "Generic. Tanks III") { unitname = Military.UnitName.Name.tank3g; }
                    else if (subStrings[0] == "Generic Tanks IV") { unitname = Military.UnitName.Name.tank4g; }
                    else if (subStrings[0] == "Generic Inf. I") { unitname = Military.UnitName.Name.infantry1g; }
                    else if (subStrings[0] == "Generic Inf. II") { unitname = Military.UnitName.Name.infantry2g; }
                    else { throw new ArgumentException(); }

                    for (int i = 0; i < 16; i++)
                    {
                        if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null) { continue; }
                        if (unitname == PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i].Name
                            && hp == PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i].HP)
                        {
                            PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i].Disband(country);
                            PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].DeleteUnit(i);
                            break;
                        }

                    }
                    Calculator.CheckArmyDeath(armyName);
                }
            }
            DeployReinforceButtonCheck(armyName);
            UpdateArmyUnits();
            UpdateMResources();
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); }
            else { HideCanBuild(); }
        }
        private void armyUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            int si = (int)armyUnits.SelectedIndex;
            deployReinforceBttn.Text = "Disband unit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Infantry" + " HP: " + 40);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];


            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.unmotorizedInfantry);
                    break;
                }
            }
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Tanks I" + " HP: " + 200);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label2.Text = "T-72B: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][1];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank1r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Tanks II" + " HP: " + 250);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][2] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label3.Text = "T-90A: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][2];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank2r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Tanks III" + " HP: " + 300);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][3] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label4.Text = "T-90M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][3];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank3r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Tanks IV" + " HP: " + 400);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][4] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label5.Text = "T-14: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][4];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank4r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Inf. I" + " HP: " + 110);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label6.Text = "BMP-2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][5];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry1r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Sov. Inf. II" + " HP: " + 110);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][6] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label7.Text = "BMP-3: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][6];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry2r);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("VDV I" + " HP: " + 120);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][7] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label8.Text = "BMD-1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][7];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.vdv1);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("VDV II" + " HP: " + 140);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][8] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label9.Text = "BMD-2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][8];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.vdv2);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);

            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Tanks I" + " HP: " + 200);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label12.Text = "M1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank1a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Tanks II" + " HP: " + 250);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][12] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label13.Text = "M1A1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][12];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank2a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Tanks III" + " HP: " + 350);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][13] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label14.Text = "M1A2: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][13];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank3a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Tanks IV" + " HP: " + 400);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][14] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label15.Text = "M1A2C: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][11];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank4a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Inf. I" + " HP: " + 100);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label16.Text = "M3: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][15];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry1a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("NATO Inf. II" + " HP: " + 130);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][16] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label17.Text = "M3A3: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][16];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry2a);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Tanks I" + " HP: " + 120);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label20.Text = "T-55: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][19];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank1g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Tanks II" + " HP: " + 150);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][20] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label21.Text = "T-55M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][20];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank2g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Tanks III" + " HP: " + 180);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][21] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label22.Text = "T-72A: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][21];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank3g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Tanks IV" + " HP: " + 220);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][22] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label23.Text = "T-72M: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][22];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.tank4g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Inf. I" + " HP: " + 80);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label24.Text = "BMP-1: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][23];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry1g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string armyName = country + " Army " + armyNumber.Value;
            armyUnits.Items.Add("Generic Inf. II" + " HP: " + 100);
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0] -= 10;
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][24] -= 50;
            Calculator.RandomManpowerDecrease(country, 10000);

            manpowerLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[country].Manpower);
            label1.Text = "Weaponry: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][0];
            label25.Text = "BMP-23: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[country][24];

            for (int i = 0; i < 16; i++)
            {
                if (!PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.ContainsKey(armyName))
                { PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics.Add(armyName, new Military.Army(country, false)); }

                if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] == null)
                {
                    PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units[i] = new Military.Unit(Military.UnitName.Name.infantry2g);
                    break;
                }
            }
            Calculator.RecalculateCanBuildUnit(country);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); } }
            else { HideCanBuild(); }

            DeployReinforceButtonCheck(armyName);
            if (PaxApocalypticaGame.Dictionary_ArmynameArmycharacteristics[armyName].Units.Contains(null)) { ShowCanBuild(); } else { HideCanBuild(); }
        }
    }
}