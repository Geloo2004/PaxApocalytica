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
using CountriesLib;
using PaxApocalytica.Politics;

namespace PaxApocalytica
{
    public partial class PaxApocalyticaGame : Form
    {
        Bitmap baseBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp; //bmp мало памяти
        Bitmap baseBitmap;      //png много памяти
        Bitmap map;
        Bitmap copyBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp;

        static Color water;
        static Color fakeBlack;
        static Color borderGray;
        static float hMovementMultiplier = 100;
        static float vMovementMultiplier = 100;

        static Rectangle rect = new Rectangle(0, 0, 1, 1);
        public PaxApocalyticaGame()
        {
            baseBitmap = CreateNonIndexedBitmap(baseBitmapIndexed);
            baseBitmapIndexed.Dispose();

            water = baseBitmap.GetPixel(1, 1);
            fakeBlack = baseBitmap.GetPixel(0, 420);
            borderGray = baseBitmap.GetPixel(887,468);

            InitializeComponent();
            splitterVertical.IsSplitterFixed = true;

            mapBox.Image = baseBitmap;
            mapBox.SizeMode = PictureBoxSizeMode.Normal;


            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height;

            rect.Width = mapBox.Width;
            rect.Height = mapBox.Height;

            map = baseBitmap.Clone(rect, 0);
            mapBox.Image = map;

            button1.Location = mapBox.Location;
            button2.Location = new Point(mapBox.Location.X, mapBox.Location.Y + mapBox.Height - button2.Height);
            button3.Location = button1.Location;
            button4.Location = new Point(mapBox.Location.X + mapBox.Width - button4.Width-15, mapBox.Location.Y);

            var startCC = CountriesLib.Country.GetAllCC();
        }

        private Bitmap UniteBitmaps(Bitmap oldBmp)
        {
            Bitmap newBmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int width = 8186 - rect.X; //до прав края левой бмп


            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                PointF pt = new PointF((float)rect.X, (float)rect.Y);
                SizeF sz = new SizeF((float)width, (float)rect.Height);
                RectangleF rf = new RectangleF(pt, sz);
                gfx.DrawImage(oldBmp, 0, 0, rf, GraphicsUnit.Pixel);
            }
            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                PointF pt = new PointF(0f, (float)rect.Y);
                SizeF sz = new SizeF((float)(rect.X - width), (float)rect.Height);
                RectangleF rf = new RectangleF(pt, sz);
                gfx.DrawImage(oldBmp, (float)width, 0, rf, GraphicsUnit.Pixel);
            }
            return newBmp;
        }
        private void UpdateMap()
        {
            if (map != null)
            {
                map.Dispose();
            }

            if ((rect.Y + rect.Height) >= baseBitmap.Height)
            {
                rect.Y = baseBitmap.Height - rect.Height - 1;
            }

            if (rect.X + rect.Width >= baseBitmap.Width)
            {
                map = UniteBitmaps(baseBitmap);
            }
            else
            {
                map = baseBitmap.Clone(rect, 0);
            }
            mapBox.Image = map;
        }
        protected override void OnResize(EventArgs e)
        {
            ResizeSplitter();
            ResizeMapBox();
            ResizeRectangle();
            ResizeButtons();
            UpdateMap();
        }

        private void splitterVertical_SplitterMoved(object sender, SplitterEventArgs e)
        {

        } //ничего не делает

        //resizы

        private void ResizeRectangle()
        {
            rect.Width = mapBox.Width;
            rect.Height = mapBox.Height;
        }
        private void ResizeMapBox()
        {
            mapBox.Width = splitterVertical.Panel1.Width;
            mapBox.Height = splitterVertical.Panel1.Height;
        }
        private void ResizeSplitter()
        {
            splitterVertical.Width = this.Width;
            if (this.Width < 640)
            {
                this.Width = 640;
            }
            if (this.Height < 480)
            {
                this.Height = 480;
            }

            if (!this.Visible)
            {
                splitterVertical.SplitterDistance = (this.Width - 360);
            }
        }
        private void ResizeButtons()
        {
            button1.Location = mapBox.Location;
            button2.Location = new Point(mapBox.Location.X, mapBox.Location.Y + mapBox.Height - button2.Height);
            button3.Location = button1.Location;
            button4.Location = new Point(mapBox.Location.X + mapBox.Width - button4.Width-2, mapBox.Location.Y);

            button1.Width = splitterVertical.Panel1.Width;
            button2.Width = splitterVertical.Panel1.Width;
            button3.Height = splitterVertical.Height;
            button4.Height = splitterVertical.Height;
        }



        private void map_Click(object sender, EventArgs e)      //покрас
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            int x = mea.X + rect.X;
            int y = mea.Y + rect.Y;
            while (x >= 8192)
            {
                x -= 8192;
            }
            while(x< 0) 
            {
                x += 8192;
            }

            if (GetProvinceId(x,y) != 0)
            {
                FloodFill(baseBitmap, new Point(x, y), baseBitmap.GetPixel(x, y), Color.Red);
            }
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
            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(oldBmp, 0, 0);
            }
            return newBmp;
        }
        //двигалки

        private int GetProvinceId(int x, int y) 
        {
            if (baseBitmap.GetPixel(x, y)    == water 
                || baseBitmap.GetPixel(x,y)  == fakeBlack 
                || baseBitmap.GetPixel(x, y) == borderGray)
            {
                return 0;
            }
            return 1;
        }
    }
}