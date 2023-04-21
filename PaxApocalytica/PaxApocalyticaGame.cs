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
    public partial class PaxApocalyticaGame : Form
    {
        static Bitmap bitmap = new Bitmap(@"C:\Users\Comrade Thursday\source\repos\PaxApocalytica\PaxApocalytica\mapExperimental.bmp", true);
        public PaxApocalyticaGame()
        {
            InitializeComponent();
            map.Image = bitmap;
            map.Height = splitterVertical.Panel1.Height;
            map.Width = splitterVertical.Panel1.Width;
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeSplitter();
            ResizeMap();
        }
        private void splitterVertical_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        public void ResizeSplitter()
        {
            if (this.Width >= 640)
            {
                splitterVertical.Width = this.Width - 16;
            }
            else
            {
                this.Width = 640;
            }
            if (this.Height >= 480)
            {
                splitterVertical.Height = this.Height - 39;
            }
            else
            {
                this.Height = 480;
            }
            splitterVertical.SplitterDistance = (this.Width - 360);
        }
        public void ResizeMap() 
        {
            map.Height = splitterVertical.Panel1.Height;
            map.Width = splitterVertical.Panel1.Width;
        }
        private void map_Click(object sender, EventArgs e)
        {

        }
    }
}
