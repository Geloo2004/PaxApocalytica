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
    public partial class PaxApocalypticaGame : Form
    {
        static int x;
        static int y;
        public PaxApocalypticaGame()
        {
            InitializeComponent();
        }

        private void PaxApocalypticaGame_Load(object sender, EventArgs e)
        {
            x = this.ClientSize.Width;
            y = this.ClientSize.Height;
            textBox1.Text = "width" + Convert.ToString(x);
            textBox2.Text = "width" + Convert.ToString(y);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
