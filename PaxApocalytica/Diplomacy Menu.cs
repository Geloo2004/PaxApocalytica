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
    public partial class Diplomacy_Menu : Form
    {
        static string PlayerCountry;
        int allies_Index = -1;
        int rival_Index = -1;
        int friend_Index = -1;
        int warEnemy_Index = -1;

        static List<string> war;
        public Diplomacy_Menu(string playerCountry)
        {
            InitializeComponent();
            PlayerCountry = playerCountry;
            this.MinimumSize = new Size(637, 699);
            this.MaximumSize = new Size(637, 699);
            war = new List<string>();

            breakAllianceBttn.Enabled = false;
            declareWarBttn.Enabled = false;
            offerAllianceBttn.Enabled = false;
            setAsRivalBttn.Enabled = false;
            offerPeace.Enabled = false;

            UpdateRivals();
            UpdateAllies();
            UpdateFriends();
            UpdateWars();
        }

        private void Diplomacy_Menu_Load(object sender, EventArgs e)
        {

        }

        private void UpdateRivals()
        {
            rivalsListBox.Items.Clear();
            if (PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry].Count > 0)
            {
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry])
                {
                    if (country == "") { continue; }
                    rivalsListBox.Items.Add(country);
                }
            }
        }
        private void UpdateFriends()
        {
            friendsListBox.Items.Clear();
            foreach (var country in PaxApocalypticaGame.ExistingCountriesList)
            {
                if (country == "") { continue; }
                if (country == PlayerCountry) { continue; }
                if (PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry].Contains(country)) { continue; }
                else if (Calculator.CheckAtWar(country, PlayerCountry)) { continue; }
                friendsListBox.Items.Add(country);
            }
        }
        private void UpdateAllies()
        {
            alliesListBox.Items.Clear();
            if (PaxApocalypticaGame.Dictionary_CountrynameAllies[PlayerCountry].Count > 0)
            {
                foreach (var country in PaxApocalypticaGame.Dictionary_CountrynameAllies[PlayerCountry])
                {
                    if (country == "") { continue; }
                    alliesListBox.Items.Add(country);
                }
            }
        }
        private void UpdateWars()
        {
            foreach (var side0 in PaxApocalypticaGame.Dictionary_WarSides.Keys)
            {
                if (side0.Contains(PlayerCountry))
                {
                    foreach (var country in PaxApocalypticaGame.Dictionary_WarSides[side0])
                    {
                        if (Calculator.IsCountry0Winning(PlayerCountry, country))
                        {
                            warEnemies.Items.Add(country + " - We are winning");
                        }
                        else
                        {
                            warEnemies.Items.Add(country + " - We are losing");
                        }
                    }
                }
                else if (PaxApocalypticaGame.Dictionary_WarSides[side0].Contains(PlayerCountry))
                {
                    foreach (var country in side0)
                    {
                        if (Calculator.IsCountry0Winning(PlayerCountry, country))
                        {
                            warEnemies.Items.Add(country + " - We are winning");
                        }
                        else
                        {
                            warEnemies.Items.Add(country + " - We are losing");
                        }
                    }
                }
            }
        }

        private void alliesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            declareWarBttn.Enabled = false;
            offerAllianceBttn.Enabled = false;
            setAsRivalBttn.Enabled = false;
            offerPeace.Enabled = false;

            allies_Index = alliesListBox.SelectedIndex;
            if (allies_Index >= 0)
            {
                breakAllianceBttn.Enabled = true;
            }
            else
            {
                breakAllianceBttn.Enabled = false;
            }
        }
        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            declareWarBttn.Enabled = false;
            breakAllianceBttn.Enabled = false;
            offerPeace.Enabled = false;

            friend_Index = friendsListBox.SelectedIndex;
            if (friend_Index >= 0)
            {
                offerAllianceBttn.Enabled = true;
                setAsRivalBttn.Enabled = true;
            }
            else
            {
                offerAllianceBttn.Enabled = false;
                setAsRivalBttn.Enabled = false;
            }
        }
        private void rivalsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            breakAllianceBttn.Enabled = false;
            offerAllianceBttn.Enabled = false;
            setAsRivalBttn.Enabled = false;
            offerPeace.Enabled = false;

            rival_Index = rivalsListBox.SelectedIndex;
            if (rival_Index >= 0)
            {
                string enemy = rivalsListBox.Items[rival_Index].ToString();
                declareWarBttn.Enabled = true;
                foreach (var pact in PaxApocalypticaGame.Dictionary_PactCountrynames.Keys)
                    {
                        if (PaxApocalypticaGame.Dictionary_PactCountrynames[pact].Contains(PlayerCountry))
                        {
                            foreach (var ally in PaxApocalypticaGame.Dictionary_PactCountrynames[pact])
                            {
                                if (ally == enemy)
                                {
                                    declareWarBttn.Enabled = false;
                                }
                            }
                        }
                    }
                
            }
            else
            {
                declareWarBttn.Enabled = false;
            }
        }
        private void warEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            declareWarBttn.Enabled = false;
            breakAllianceBttn.Enabled = false;
            offerAllianceBttn.Enabled = false;
            setAsRivalBttn.Enabled = false;

            warEnemy_Index = warEnemies.SelectedIndex;
            if (warEnemy_Index >= 0)
            {
                offerPeace.Enabled = true; 
            }
            else
            {
                offerPeace.Enabled = false;
            }
        }

        private void setAsRivalBttn_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry].Add(friendsListBox.Items[friend_Index].ToString());
            PaxApocalypticaGame.Dictionary_CountrynameRivals[friendsListBox.Items[friend_Index].ToString()].Add(PlayerCountry);
            UpdateRivals();
            UpdateFriends();
        }

        private void offerAllianceBttn_Click(object sender, EventArgs e)
        {
            if (HasOurRivalsInAllies(friendsListBox.Items[friend_Index].ToString())) { }
            else if (HasCommonRivals(friendsListBox.Items[friend_Index].ToString()))
            {
                PaxApocalypticaGame.Dictionary_CountrynameAllies[PlayerCountry].Add(friendsListBox.Items[friend_Index].ToString());
                PaxApocalypticaGame.Dictionary_CountrynameAllies[friendsListBox.Items[friend_Index].ToString()].Add(PlayerCountry);
            }
            UpdateAllies();
            UpdateFriends();

        }

        private void breakAllianceBttn_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame.Dictionary_CountrynameAllies[PlayerCountry].Remove(alliesListBox.Items[allies_Index].ToString());
            PaxApocalypticaGame.Dictionary_CountrynameAllies[alliesListBox.Items[allies_Index].ToString()].Remove(PlayerCountry);
            PaxApocalypticaGame.Dictionary_CountrynameRivals[alliesListBox.Items[allies_Index].ToString()].Add(PlayerCountry);
            allies_Index = -1;
            UpdateAllies();
            UpdateFriends();
        }

        private void declareWarBttn_Click(object sender, EventArgs e)
        {

            
            var enemy = rivalsListBox.Items[rival_Index].ToString();

            List<string> allies = new List<string>();
            allies.Add(PlayerCountry);
            foreach (var ally in PaxApocalypticaGame.Dictionary_CountrynameAllies[PlayerCountry])
            {
                if (!PaxApocalypticaGame.Dictionary_CountrynameAllies[ally].Contains(enemy))
                {
                    allies.Add(ally);
                }
            }
            foreach (var pact in PaxApocalypticaGame.Dictionary_PactCountrynames.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_PactCountrynames[pact].Contains(PlayerCountry))
                {
                    foreach (var ally in PaxApocalypticaGame.Dictionary_PactCountrynames[pact])
                    {
                        if (!PaxApocalypticaGame.Dictionary_CountrynameAllies[ally].Contains(enemy))
                        {
                            allies.Add(ally);
                        }
                    }
                }
            }

            List<string> enemies = new List<string>();
            enemies.Add(enemy);


            foreach(var ally in PaxApocalypticaGame.Dictionary_CountrynameAllies[enemy]) 
            {
                enemies.Add(ally);
            }
            foreach (var pact in PaxApocalypticaGame.Dictionary_PactCountrynames.Keys)
            {
                if (PaxApocalypticaGame.Dictionary_PactCountrynames[pact].Contains(enemy))
                {
                    foreach (var ally in PaxApocalypticaGame.Dictionary_PactCountrynames[pact])
                    {
                        enemies.Add(ally);
                    }
                }
            }
            PaxApocalypticaGame.Dictionary_WarSides.Add(allies, enemies);
            UpdateFriends();
            UpdateRivals();
            UpdateWars();
            UpdateAllies();
        }

        public bool HasOurRivalsInAllies(string otherCountry)
        {
            foreach (var rival in PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry])
            {
                if (PaxApocalypticaGame.Dictionary_CountrynameAllies[otherCountry].Contains(rival))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasCommonRivals(string otherCountry)
        {
            foreach (var rival in PaxApocalypticaGame.Dictionary_CountrynameRivals[PlayerCountry])
            {
                if (PaxApocalypticaGame.Dictionary_CountrynameRivals[otherCountry].Contains(rival))
                {
                    return true;
                }
            }
            return false;
        }

        private void offerPeace_Click(object sender, EventArgs e)
        {
           // if()
        }

    }
}
