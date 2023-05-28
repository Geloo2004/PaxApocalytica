using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaxApocalytica
{
    public partial class Add_Plane : Form
    {
        static string countryOwner;
        static string provinceName;
        static Button launcherButton;
        public Add_Plane(string countryName, string provName, Button bttn)
        {
            InitializeComponent();
            this.MinimumSize = new Size(778, 196);
            this.MaximumSize = new Size(778, 196);
            countryOwner = countryName;
            provinceName = provName;
            launcherButton = bttn;
            label1.Text = "Sov. Fighters:        " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][9];
            label2.Text = "Sov. Strike Aicrafts: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][10];
            label3.Text = "NATO Fighters:        " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][17];
            label4.Text = "NATO Strike Aicrafts: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][18];
            label5.Text = "Generic Fighters:        " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][25];
            label6.Text = "Generic Strike Aicrafts: " + PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryName][26];

            button1.Text = "S.F. div.";
            button2.Text = "S.S.A. div.";
            button3.Text = "N.F. div.";
            button4.Text = "N.S.A. div.";
            button5.Text = "G.F. div.";
            button6.Text = "G.S.F. div.";

            Calculator.RecalculateCanBuildUnit(countryName);
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][23]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][20]) { button2.Enabled = true; }
            else { button2.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][22]) { button3.Enabled = true; }
            else { button3.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][19]) { button4.Enabled = true; }
            else { button4.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][24]) { button5.Enabled = true; }
            else { button5.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][21]) { button6.Enabled = true; }
            else { button6.Enabled = false; }
        }

        private void Add_Plane_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][9] -= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterR));
            launcherButton.Text = "Sov. Fighter";
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][10] -= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftR));
            launcherButton.Text = "Sov. Strike Aircraft";
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][17] -= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterA));
            launcherButton.Text = "NATO Fighter";
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][18] -= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftA));
            launcherButton.Text = "NATO Strike Aircraft";
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][25]-= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.fighterG));
            launcherButton.Text = "Generic Fighter";
            this.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameMilitaryResources[countryOwner][26] -= 50;
            PaxApocalypticaGame.Dictionary_NameAirfield[provinceName].AddPlanesDivision(new Military.Unit(Military.UnitName.Name.strikeAircraftG));
            launcherButton.Text = "Generic Strike Aircraft";
            this.Close();
        }
    }
}
