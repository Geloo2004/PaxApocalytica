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
        public Add_Plane(string countryName)
        {
            InitializeComponent();
            this.MinimumSize = new Size(778, 196);
            this.MaximumSize = new Size(778, 196);
            countryOwner = countryName;
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
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][19]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][20]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][21]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][22]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][23]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_CanBuildUnit[countryName][24]) { button1.Enabled = true; }
            else { button1.Enabled = false; }
        }

        private void Add_Plane_Load(object sender, EventArgs e)
        {

        }
    }
}
