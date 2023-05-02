using PaxApocalytica.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaxApocalytica
{
    public partial class PaxApocalyticaGame : Form
    {
        Bitmap baseBitmapIndexed = PaxApocalytica.Properties.Resources.baseMap; //bmp мало памяти
        Bitmap baseBitmap;      //png много памяти

        Bitmap copyBitmapIndexed = PaxApocalytica.Properties.Resources.baseMap;

        static int hMovementMultiplier;
        static int vMovementMultiplier;

        static Rectangle rect = new Rectangle(0, 0, 1, 1);
        Bitmap map;
        public PaxApocalyticaGame()
        {
            baseBitmap = CreateNonIndexedBitmap(baseBitmapIndexed);
            baseBitmapIndexed.Dispose();

            InitializeComponent();
            //DoubleBuffered = true;
            Color a = copyBitmapIndexed.GetPixel(1, 1);

            mapBox.Image = baseBitmap;
            mapBox.SizeMode = PictureBoxSizeMode.Normal;


            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height;

            rect.Width = mapBox.Width;
            rect.Height = mapBox.Height;

            map = baseBitmap.Clone(rect, 0);
            mapBox.Image = map;
        }

        private void UpdateMap()
        {
            if (map != null)
            {
                map.Dispose();
            }
            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height;

            rect.Width = mapBox.Width;
            rect.Height = mapBox.Height;

            map = baseBitmap.Clone(rect, 0);
            mapBox.Image = map;
        }
        protected override void OnResize(EventArgs e)
        {
            ResizeSplitter();
            ResizeHorizontalScrollbar();
            ResizeVerticalScrollbar();
            ResizeMapBox();
            ResizeRectangle();
            UpdateMap();
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
            hMovementMultiplier =(int)(splitterVertical.Panel1.Width / 100);
            mapBox.Height = splitterVertical.Panel1.Height;
            vMovementMultiplier = (int)(splitterVertical.Panel1.Height / 100);
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
            int x = mea.X + rect.X;
            int y = mea.Y + rect.Y;
            FloodFill(baseBitmap, new Point(x, y), baseBitmap.GetPixel(x, y), Color.Red);
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
            UpdateMap();
        }

        //чтоб работало
        private Bitmap CreateNonIndexedBitmap(Bitmap oldBmp)
        {
            //https://stackoverflow.com/questions/25984458/why-im-getting-exception-when-using-setpixel-setpixel-is-not-supported-for-ima

            Bitmap newBmp = new Bitmap(oldBmp.Width, oldBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using(Graphics gfx = Graphics.FromImage(newBmp)) 
            {
                gfx.DrawImage(oldBmp, 0, 0);
            }
            return newBmp;
        }
        //двигалки
        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            rect.Y = vMovementMultiplier * vScrollBar2.Value;
            vScrollBar1.Value = vScrollBar2.Value;
            UpdateMap();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            rect.Y = vMovementMultiplier * vScrollBar1.Value;
            vScrollBar2.Value = vScrollBar1.Value;
            UpdateMap();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            rect.X = 70 * hScrollBar1.Value;
            hScrollBar2.Value = hScrollBar1.Value;
            UpdateMap();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            rect.X = 70 * hScrollBar2.Value;
            hScrollBar1.Value = hScrollBar2.Value;
            UpdateMap();
        }
    }
}