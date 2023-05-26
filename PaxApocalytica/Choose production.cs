using PaxApocalytica.FactoriesAndResources;
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
    public partial class Choose_production : Form
    {
        static string name;
        public Choose_production(string provName)
        {
            InitializeComponent();
            this.MinimumSize = new Size(553, 312);
            this.MaximumSize = new Size(553, 312);
            prod1.Text = "Weaponry";
            name = provName;

            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.Weaponry) { prod1.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T72B) { prod2.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T90A) { prod3.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T90M) { prod4.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T14) { prod5.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMP2) { prod6.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMP3) { prod7.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMD1) { prod8.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMD2) { prod9.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.FighterR) { prod10.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { prod11.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M1) { prod2.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M1A1) { prod3.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M1A2) { prod4.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M1A2C) { prod5.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M3A1) { prod6.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.M3A3) { prod7.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.FighterA) { prod10.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { prod11.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T55) { prod2.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T55M) { prod3.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T72A) { prod4.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.T72M) { prod5.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMP1) { prod6.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.BMP23) { prod7.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.FighterG) { prod10.Enabled = false; }
            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { prod11.Enabled = false; }

            if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].FactoryType == MilitaryFactoryType.Type.Soviet)
            {
                prod2.Text = "T-72B";
                prod3.Text = "T-90A";
                prod4.Text = "T-90M";
                prod5.Text = "T-14";
                prod6.Text = "BMP-2";
                prod7.Text = "BMP-3";
                prod8.Text = "BMD-1";
                prod9.Text = "BMD-2";
                prod10.Text = "Sov. Fighter";
                prod11.Text = "Sov. Strike Aircraft";

                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T72B, MilitaryFactoryType.Type.Soviet)) { prod2.Enabled = true; } else { prod2.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T90A, MilitaryFactoryType.Type.Soviet)) { prod3.Enabled = true; } else { prod3.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T90M, MilitaryFactoryType.Type.Soviet)) { prod4.Enabled = true; } else { prod4.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T14, MilitaryFactoryType.Type.Soviet)) { prod5.Enabled = true; } else { prod5.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMP2, MilitaryFactoryType.Type.Soviet)) { prod6.Enabled = true; } else { prod6.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMP3, MilitaryFactoryType.Type.Soviet)) { prod7.Enabled = true; } else { prod7.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMD1, MilitaryFactoryType.Type.Soviet)) { prod8.Enabled = true; } else { prod8.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMD2, MilitaryFactoryType.Type.Soviet)) { prod9.Enabled = true; } else { prod9.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.FighterR, MilitaryFactoryType.Type.Soviet)) { prod10.Enabled = true; } else { prod10.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.StrikeAircraftR, MilitaryFactoryType.Type.Soviet)) { prod11.Enabled = true; } else { prod11.Enabled = false; }

            }
            else if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].FactoryType == FactoriesAndResources.MilitaryFactoryType.Type.NATO)
            {
                prod2.Text = "M1";
                prod3.Text = "M1A1";
                prod4.Text = "M1A2";
                prod5.Text = "M1A2C";
                prod6.Text = "M3A1";
                prod7.Text = "M3A3";
                prod8.Hide();
                prod9.Hide();
                prod10.Text = "NATO Fighter";
                prod11.Text = "NATO Strike Aircraft";

                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M1, MilitaryFactoryType.Type.NATO)) { prod2.Enabled = true; } else { prod2.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M1A1, MilitaryFactoryType.Type.NATO)) { prod3.Enabled = true; } else { prod3.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M1A2, MilitaryFactoryType.Type.NATO)) { prod4.Enabled = true; } else { prod4.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M1A2C, MilitaryFactoryType.Type.NATO)) { prod5.Enabled = true; } else { prod5.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M3A1, MilitaryFactoryType.Type.NATO)) { prod6.Enabled = true; } else { prod6.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.M3A3, MilitaryFactoryType.Type.NATO)) { prod7.Enabled = true; } else { prod7.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.FighterA, MilitaryFactoryType.Type.NATO)) { prod10.Enabled = true; } else { prod10.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.StrikeAircraftA, MilitaryFactoryType.Type.NATO)) { prod11.Enabled = true; } else { prod11.Enabled = false; }

            }
            else if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].FactoryType == FactoriesAndResources.MilitaryFactoryType.Type.Generic)
            {
                prod2.Text = "T-55";
                prod3.Text = "T-55M";
                prod4.Text = "T-72A";
                prod5.Text = "T-72M";
                prod6.Text = "BMP-1";
                prod7.Text = "BMP-23";
                prod8.Hide();
                prod9.Hide();
                prod10.Text = "Generic Fighter";
                prod11.Text = "Generic Strike Aircraft";

                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T55, MilitaryFactoryType.Type.Generic)) { prod2.Enabled = true; } else { prod2.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T55M, MilitaryFactoryType.Type.Generic)) { prod3.Enabled = true; } else { prod3.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T72A, MilitaryFactoryType.Type.Generic)) { prod4.Enabled = true; } else { prod4.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.T72M, MilitaryFactoryType.Type.Generic)) { prod5.Enabled = true; } else { prod5.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMP1, MilitaryFactoryType.Type.Generic)) { prod6.Enabled = true; } else { prod6.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.BMP23, MilitaryFactoryType.Type.Generic)) { prod7.Enabled = true; } else { prod7.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.FighterG, MilitaryFactoryType.Type.Generic)) { prod10.Enabled = true; } else { prod10.Enabled = false; }
                if (PaxApocalypticaGame.Dictionary_NameMFactory[provName].IsProduceable(MilitaryResources.Names.StrikeAircraftG, MilitaryFactoryType.Type.Generic)) { prod11.Enabled = true; } else { prod11.Enabled = false; }
            }
            else { throw new ArgumentException(); }
        }

        private void Choose_production_Load(object sender, EventArgs e)
        {

        }

        private void prod1_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.Weaponry,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            this.Close();
        }
        private void prod2_Click(object sender, EventArgs e)
        {
            if (prod2.Text == "M1")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M1,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod2.Text == "T-72B")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T72B,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod2.Text == "T-55")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T55,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }
        private void prod3_Click(object sender, EventArgs e)
        {
            if (prod3.Text == "M1A1")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M1A1,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod3.Text == "T-90A")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T90A,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod3.Text == "T-55M")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T55M,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod4_Click(object sender, EventArgs e)
        {
            if (prod4.Text == "M1A2")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M1A2,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod4.Text == "T-90M")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T90M,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod4.Text == "T-72A")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T72A,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod5_Click(object sender, EventArgs e)
        {
            if (prod5.Text == "M1A2C")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M1A2C,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod5.Text == "T-14")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T14,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod5.Text == "T-72M")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.T72M,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod6_Click(object sender, EventArgs e)
        {
            if (prod6.Text == "M3A1")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M3A1,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod6.Text == "BMP-2")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMP2,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod6.Text == "BMP-1")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMP1,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod7_Click(object sender, EventArgs e)
        {
            if (prod7.Text == "M3A3")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.M3A3,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "BMP-3")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMP3,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "BMP-23")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMP23,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod8_Click(object sender, EventArgs e)
        {
            if (prod7.Text == "BMD-1")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMD1,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod9_Click(object sender, EventArgs e)
        {
            if (prod7.Text == "BMD-2")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.BMD2,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod10_Click(object sender, EventArgs e)
        {
            if (prod7.Text == "NATO Fighter")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.FighterA,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "Sov. Fighter")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.FighterR,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "Generic Fighter")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.FighterG,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }

        private void prod11_Click(object sender, EventArgs e)
        {
            if (prod7.Text == "NATO Strike Aircraft")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.StrikeAircraftA,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "Sov. Strike Aircraft")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.StrikeAircraftR,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else if (prod7.Text == "Generic Strike Aircraft")
            {
                PaxApocalypticaGame.Dictionary_UpgradeQueue_MFactory.Add(6 + "," + name, new MilitaryFactory(MilitaryResources.Names.StrikeAircraftG,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].TechnologyLevel,
                    PaxApocalypticaGame.Dictionary_NameMFactory[name].ExtensionLevel,
                    PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[PaxApocalypticaGame.Dictionary_NameOwner[name]].TechGroup));
            }
            else { throw new ArgumentException(); }
            this.Close();
        }
    }
}
