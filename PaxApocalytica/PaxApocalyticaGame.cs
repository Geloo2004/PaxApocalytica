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
        static Bitmap baseBitmap = new Bitmap(@"C:\Users\Comrade Thursday\source\repos\PaxApocalytica\PaxApocalytica\iv74j8jqih881_1.png", true);
        //static Bitmap copyBitmap = new Bitmap(baseBitmap);


        static Rectangle rect = new Rectangle(0, 0, 1, 1);
        Bitmap map;
        public PaxApocalyticaGame()
        {
            InitializeComponent();
            //подготовка 
            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height; 

            rect.Width = mapBox.Width;
            rect.Height = mapBox.Height;

            map = baseBitmap.Clone(rect, 0);
            mapBox.Image = map;
        }

        private void ChangeMap()
        {
            map = baseBitmap.Clone(rect, 0);
            if(mapBox.Image!=null){mapBox.Image.Dispose();}
            mapBox.Image = new Bitmap(map);

            map.Dispose();
        }
        protected override void OnResize(EventArgs e)
        {
            ResizeSplitter();
            ResizeHorizontalScrollbar();
            ResizeVerticalScrollbar();
            ResizeMapBox();
            ResizeRectangle();
            ChangeMap();
        }
        private void splitterVertical_SplitterMoved(object sender, SplitterEventArgs e)
        {

        } //ничего не делает

        //resizы


        private void ResizeRectangle() 
        {
            rect.Width = splitterVertical.Panel1.Width;
            rect.Height = splitterVertical.Panel1.Height;
        }
        private void ResizeMapBox() 
        {
            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height;
        }
        private void ResizeSplitter()
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
        private void ResizeHorizontalScrollbar()
        {
            hScrollBar1.Width = splitterVertical.Panel1.Width;
            hScrollBar2.Width = splitterVertical.Panel1.Width;
            hScrollBar2.Location = new Point(0, splitterVertical.Height - 17);
        }
        private void ResizeVerticalScrollbar()
        {
            vScrollBar1.Height = splitterVertical.Height - 34;
            vScrollBar2.Height = splitterVertical.Height - 34;
            vScrollBar2.Location = new Point(splitterVertical.Panel1.Width - 14, 17);
        }



        private void map_Click(object sender, EventArgs e)      //покрас
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            int x = mea.X;
            int y = mea.Y;
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
            mapBox.Refresh();
        }   //покрасАлг
    }
}
