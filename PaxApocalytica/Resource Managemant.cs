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
    public partial class Resource_Management : Form
    {
        static decimal sum = 0;
        static string owner;

        static decimal oldValue0;
        static decimal oldValue1;
        static decimal oldValue2;
        static decimal oldValue3;
        static decimal oldValue4;
        static decimal oldValue5;
        static decimal oldValue6;
        static decimal oldValue7;
        static decimal oldValue8;
        static decimal oldValue9;
        public Resource_Management(string playerCountry)
        {
            this.MaximumSize = new Size(471, 517);
            this.MinimumSize = new Size(471, 517);
            owner = playerCountry;
            InitializeComponent();
            maxTradeSlotsLabel.Text = "Max trade slots: " + PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots;

            goldLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][9]);
            aluminiumLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][8]);
            gasLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][7]);
            livestockLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][6]);
            grainLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][5]);
            coalLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][4]);
            uraniumLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][3]);
            copperLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][2]);
            steelLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][1]);
            oilLabel.Text = Convert.ToString(PaxApocalypticaGame.Dictionary_CountrynameSimpleResources[owner][0]);

            goldTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][9];
            aluminiumTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][8];
            gasTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][7];
            livestockTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][6];
            grainTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][5];
            coalTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][4];
            uraniumTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][3];
            copperTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][2];
            steelTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][1];
            oilTradeNumericsUD.Value = PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][0];

            oldValue0 = goldTradeNumericsUD.Value;
            oldValue1 = aluminiumTradeNumericsUD.Value;
            oldValue2 = gasTradeNumericsUD.Value;
            oldValue3 = livestockTradeNumericsUD.Value;
            oldValue4 = grainTradeNumericsUD.Value;
            oldValue5 = coalTradeNumericsUD.Value;
            oldValue6 = uraniumTradeNumericsUD.Value;
            oldValue7 = copperTradeNumericsUD.Value;
            oldValue8 = steelTradeNumericsUD.Value;
            oldValue9 = oilTradeNumericsUD.Value;
            RecalculateSum();
            usedTradeSlotsLabel.Text = "Used trade slots: " + sum;
        }

        private void RecalculateSum()
        {
            sum = 0;
            if (goldTradeNumericsUD.Value < 0) { sum -= goldTradeNumericsUD.Value; }
            else
            {
                sum += goldTradeNumericsUD.Value;
            }
            if (aluminiumTradeNumericsUD.Value < 0) { sum -= aluminiumTradeNumericsUD.Value; }
            else
            {
                sum += aluminiumTradeNumericsUD.Value;
            }
            if (gasTradeNumericsUD.Value < 0) { sum -= gasTradeNumericsUD.Value; }
            else
            {
                sum += gasTradeNumericsUD.Value;
            }
            if (livestockTradeNumericsUD.Value < 0) { sum -= livestockTradeNumericsUD.Value; }
            else
            {
                sum += livestockTradeNumericsUD.Value;
            }
            if (grainTradeNumericsUD.Value < 0) { sum -= grainTradeNumericsUD.Value; }
            else
            {
                sum += grainTradeNumericsUD.Value;
            }
            if (coalTradeNumericsUD.Value < 0) { sum -= coalTradeNumericsUD.Value; }
            else
            {
                sum += coalTradeNumericsUD.Value;
            }
            if (uraniumTradeNumericsUD.Value < 0) { sum -= uraniumTradeNumericsUD.Value; }
            else
            {
                sum += uraniumTradeNumericsUD.Value;
            }
            if (copperTradeNumericsUD.Value < 0) { sum -= copperTradeNumericsUD.Value; }
            else
            {
                sum += copperTradeNumericsUD.Value;
            }
            if (steelTradeNumericsUD.Value < 0) { sum -= steelTradeNumericsUD.Value; }
            else
            {
                sum += steelTradeNumericsUD.Value;
            }
            if (oilTradeNumericsUD.Value < 0) { sum -= oilTradeNumericsUD.Value; }
            else
            {
                sum += oilTradeNumericsUD.Value;
            }
            usedTradeSlotsLabel.Text = "Used trade slots: " + sum;
        }

        private void steelTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                steelTradeNumericsUD.Value = oldValue8;
                RecalculateSum();
            }
            else { oldValue8 = steelTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][1] = Convert.ToInt32(steelTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (steelTradeNumericsUD.Value < 0) { steelImExLabel.Text = "Importing"; }
            else if (steelTradeNumericsUD.Value < 0) { steelImExLabel.Text = "Exporting"; }
            else { steelImExLabel.Text = ""; }
        }
        private void goldTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                goldTradeNumericsUD.Value = oldValue0;
                RecalculateSum();
            }
            else { oldValue0 = goldTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][9] = Convert.ToInt32(goldTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (goldTradeNumericsUD.Value < 0) { goldImExLabel.Text = "Importing"; }
            else if (goldTradeNumericsUD.Value < 0) { goldImExLabel.Text = "Exporting"; }
            else { goldImExLabel.Text = ""; }
        }
        private void copperTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                copperTradeNumericsUD.Value = oldValue7;
                RecalculateSum();
            }
            else { oldValue7 = copperTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][2] = Convert.ToInt32(copperTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (copperTradeNumericsUD.Value < 0) { copperImExLabel.Text = "Importing"; }
            else if (copperTradeNumericsUD.Value < 0) { copperImExLabel.Text = "Exporting"; }
            else { copperImExLabel.Text = ""; }
        }
        private void uraniumTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                uraniumTradeNumericsUD.Value = oldValue6;
                RecalculateSum();
            }
            else { oldValue6 = uraniumTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][3] = Convert.ToInt32(uraniumTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (uraniumTradeNumericsUD.Value < 0) { uraniumImExLabel.Text = "Importing"; }
            else if (uraniumTradeNumericsUD.Value < 0) { uraniumImExLabel.Text = "Exporting"; }
            else { uraniumImExLabel.Text = ""; }
        }
        private void oilTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                oilTradeNumericsUD.Value = oldValue9;
                RecalculateSum();
            }
            else { oldValue9 = oilTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][0] = Convert.ToInt32(oilTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (oilTradeNumericsUD.Value < 0) { oilImExLabel.Text = "Importing"; }
            else if (oilTradeNumericsUD.Value < 0) { oilImExLabel.Text = "Exporting"; }
            else { oilImExLabel.Text = ""; }
        }
        private void coalTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                coalTradeNumericsUD.Value = oldValue5;
                RecalculateSum();
            }
            else { oldValue5 = coalTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][4] = Convert.ToInt32(coalTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (coalTradeNumericsUD.Value < 0) { coalImExLabel.Text = "Importing"; }
            else if (coalTradeNumericsUD.Value < 0) { coalImExLabel.Text = "Exporting"; }
            else { coalImExLabel.Text = ""; }
        }
        private void grainTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                grainTradeNumericsUD.Value = oldValue4;
                RecalculateSum();
            }
            else { oldValue4 = aluminiumTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][5] = Convert.ToInt32(grainTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (grainTradeNumericsUD.Value < 0) { grainImExLabel.Text = "Importing"; }
            else if (grainTradeNumericsUD.Value < 0) { grainImExLabel.Text = "Exporting"; }
            else { grainImExLabel.Text = ""; }
        }
        private void gasTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                gasTradeNumericsUD.Value = oldValue2;
                RecalculateSum();
            }
            else { oldValue2 = gasTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][7] = Convert.ToInt32(gasTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (gasTradeNumericsUD.Value < 0) { gasImExLabel.Text = "Importing"; }
            else if (gasTradeNumericsUD.Value < 0) { gasImExLabel.Text = "Exporting"; }
            else { gasImExLabel.Text = ""; }
        }
        private void livestockTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                livestockTradeNumericsUD.Value = oldValue3;
                RecalculateSum();
            }
            else { oldValue3 = livestockTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][6] = Convert.ToInt32(livestockTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (livestockTradeNumericsUD.Value < 0) { livestockImExLabel.Text = "Importing"; }
            else if (livestockTradeNumericsUD.Value < 0) { livestockImExLabel.Text = "Exporting"; }
            else { livestockImExLabel.Text = ""; }
        }
        private void aluminiumTradeNumericsUD_ValueChanged(object sender, EventArgs e)
        {
            RecalculateSum();
            if (sum > PaxApocalypticaGame.Dictionary_CountrynameCharacteristics[owner].MaxTradeSlots)
            {
                aluminiumTradeNumericsUD.Value = oldValue1;
                RecalculateSum();
            }
            else { oldValue1 = aluminiumTradeNumericsUD.Value; }
            PaxApocalypticaGame.Dictionary_CountrynameSimpleResources_Trade[owner][8] = Convert.ToInt32(aluminiumTradeNumericsUD.Value);
            income.Text = "Trade income: " + Convert.ToString(Calculator.CalculateTradeIncome(owner));

            if (aluminiumTradeNumericsUD.Value < 0) { aluminiumImExLabel.Text = "Importing"; }
            else if (aluminiumTradeNumericsUD.Value < 0) { aluminiumImExLabel.Text = "Exporting"; }
            else { aluminiumImExLabel.Text = ""; }
        }
    }
}
