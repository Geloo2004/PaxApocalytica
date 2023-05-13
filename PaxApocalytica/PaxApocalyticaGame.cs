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
using PaxApocalytica.Politics;
using System.Threading;

namespace PaxApocalytica
{
    public partial class PaxApocalyticaGame : Form
    {
        Bitmap baseBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp; //bmp мало памяти
        Bitmap baseBitmap;      //png много памяти
        Bitmap map;
        Bitmap copyBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp;


        /*
        static bool switch_bgwR = false;
        static bool switch_bgwL = false;
        static bool switch_bgwU = false;
        static bool switch_bgwD = false;
        */
        static Color water;
        static Color fakeBlack;
        static Color borderGray;
        static Color black = Color.Black;

        /*
        Dictionary<Color, ProvincesName.Name> color_nameDict;
        Dictionary<ProvincesName.Name, Province> name_provinceDict;
        */
        static Rectangle rect = new Rectangle(0, 0, 1, 1);
        public PaxApocalyticaGame()
        {
            baseBitmap = CreateNonIndexedBitmap(baseBitmapIndexed);
            baseBitmapIndexed.Dispose();

            water = baseBitmap.GetPixel(1, 1);
            fakeBlack = baseBitmap.GetPixel(0, 420);
            borderGray = baseBitmap.GetPixel(887, 468);

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



            /*
            color_nameDict = new Dictionary<Color, ProvincesName.Name>(StartGenerator.color_name);
            name_provinceDict = new Dictionary<ProvincesName.Name, Province>(StartGenerator.name_province);*/
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



        private void map_Click(object sender, EventArgs e)      //покрас
        {
            


            /*
            Province clickedProvince = GetProvinceId(x, y);
            if (clickedProvince != null)
            {
                
            }*/
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
        }        //двигалки

        private void MouseMoveMap()
        {

        }


        private Province GetProvinceId(int x, int y)
        {
            if (baseBitmap.GetPixel(x, y) == water
                || baseBitmap.GetPixel(x, y) == fakeBlack
                || baseBitmap.GetPixel(x, y) == borderGray
                || baseBitmap.GetPixel(x, y) == black)
            {
                return null;
            }
            return null;//color_nameDict[baseBitmap.GetPixel(x, y)];
        }

        private void mapBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X + rect.X;
            int y = e.Y + rect.Y;
            while (x >= 8192)
            {
                x -= 8192;
            }
            while (x < 0)
            {
                x += 8192;
            }
            if (e.Button == MouseButtons.Right)
            {
                int offsetX = (int)(rect.Width/2 - e.X);
                rect.X -= offsetX;

                while (rect.X < 0) 
                {
                    rect.X += 8192;
                }
                while (rect.X >= 8192)
                {
                    rect.X -= 8192;
                }

                int offsetY =(int)(rect.Height/2 - e.Y);
                rect.Y -= offsetY;
                
                if (rect.Y + rect.Width < map.Height)
                {
                    rect.Y = map.Height - rect.Height;
                }
                if (rect.Y < 0) 
                {
                    rect.Y = 0;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {


                //рисовашки
            }
            UpdateMap();
        }
    }
}