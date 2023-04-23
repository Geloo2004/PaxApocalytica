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
        static Bitmap bitmap = new Bitmap(@"C:\Users\Comrade Thursday\source\repos\PaxApocalytica\PaxApocalytica\iv74j8jqih881_1.png", true);

        bool toggleUp = false;
        bool toggleDown = false;
        public PaxApocalyticaGame()
        {
            InitializeComponent();
            map.Image = bitmap;
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeSplitter();
            ResizeHorizontalScrollbar();
            ResizeVerticalScrollbar();
            //ResizeMap();
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

        private void ResizeHorizontalScrollbar()
        {
            hScrollBar1.Width = splitterVertical.Panel1.Width;
            hScrollBar2.Width = splitterVertical.Panel1.Width;
        }

        private void ResizeVerticalScrollbar()
        {
            vScrollBar1.Height = splitterVertical.Height - 34;
            hScrollBar2.Location = new Point(0, splitterVertical.Height-17);
        }
        private void map_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            int x = mea.X;
            int y = mea.Y;
            Color oldColor = bitmap.GetPixel(x, y);
            FloodFill(bitmap, new Point(x, y), oldColor, Color.Red);
        }

        private void FloodFill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            targetColor = bmp.GetPixel(pt.X, pt.Y);
            if (targetColor.ToArgb().Equals(replacementColor.ToArgb()))
            {
                return;
            }

            Stack<Point> pixels = new Stack<Point>();

            pixels.Push(pt);
            while (pixels.Count != 0)
            {
                Point temp = pixels.Pop();
                int y1 = temp.Y;
                while (y1 >= 0 && bmp.GetPixel(temp.X, y1) == targetColor)
                {
                    y1--;
                }
                y1++;
                bool spanLeft = false;
                bool spanRight = false;
                while (y1 < bmp.Height && bmp.GetPixel(temp.X, y1) == targetColor)
                {
                    bmp.SetPixel(temp.X, y1, replacementColor);

                    if (!spanLeft && temp.X > 0 && bmp.GetPixel(temp.X - 1, y1) == targetColor)
                    {
                        pixels.Push(new Point(temp.X - 1, y1));
                        spanLeft = true;
                    }
                    else if (spanLeft && temp.X - 1 >= 0 && bmp.GetPixel(temp.X - 1, y1) != targetColor)
                    {
                        spanLeft = false;
                    }
                    if (!spanRight && temp.X < bmp.Width - 1 && bmp.GetPixel(temp.X + 1, y1) == targetColor)
                    {
                        pixels.Push(new Point(temp.X + 1, y1));
                        spanRight = true;
                    }
                    else if (spanRight && temp.X < bmp.Width - 1 && bmp.GetPixel(temp.X + 1, y1) != targetColor)
                    {
                        spanRight = false;
                    }
                    y1++;
                }

            }
            map.Refresh();
        }
    }
}
