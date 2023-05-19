﻿using PaxApocalytica.Properties;
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
using System.IO;
using System.Drawing.Drawing2D;
using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Military;

namespace PaxApocalytica
{
    public partial class PaxApocalyticaGame : Form
    {
        Bitmap baseBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp; //bmp мало памяти
        Bitmap baseBitmap;      //png много памяти
        Bitmap map;
        Bitmap baseBitmapRegions = PaxApocalytica.Properties.Resources.bitmapRegions;

        static Rectangle rect = new Rectangle(0, 0, 1, 1);

        static Color water;
        static Color fakeBlack;
        static Color borderGray = Color.FromArgb(63, 63, 63);
        static Color otherBorderGray = Color.FromArgb(64, 64, 64);
        static Color black = Color.Black;
        static Color white = Color.White;


        public static Dictionary<string, List<Point>> Dictionary_NamesPoints;
        public static Dictionary<Color, string> Dictionary_ColorName;
        public static Dictionary<string, string[]> Dictionary_NameNeighbours;
        public static Dictionary<string, int> Dictionary_NamePort;


        public static Dictionary<string, string> Dictionary_NameOwner;
        public static Dictionary<string, string> Dictionary_NameOccupant;
        public static Dictionary<string, CountryCharacteristics> Dictionary_CountrynameCharacteristics;
        public static Dictionary<string, int[]> Dictionary_CountrynameSimpleResources;
        public static Dictionary<string, int[]> Dictionary_CountrynameMilitaryResources;
        public static Dictionary<string, Airfield> Dictionary_NameAirfield;
        public static Dictionary<string, SimpleFactory> Dictionary_NameSFactory;
        public static Dictionary<string, MilitaryFactory> Dictionary_NameMFactory;

        //Dictionary<string, string> Dictionary_NameController;     //  ai/player
        string playerCountry = null;

        public PaxApocalyticaGame()
        {
            baseBitmap = CreateNonIndexedBitmap(baseBitmapIndexed);
            baseBitmapIndexed.Dispose();

            water = baseBitmap.GetPixel(1, 1);
            fakeBlack = baseBitmap.GetPixel(0, 420);

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

            provinceName.Hide();
            ownerCountry.Hide();
            occupantCountry.Hide();
            producedResource.Hide();
            producedMilitaryResource.Hide();




            FileReader.ReadFile_NameOwner();
            FileReader.ReadFile_NameOccupant();
            FileReader.ReadFile_CountrynameCharacterstics();
            FileReader.ReadFile_CountrynameMilResources();
            FileReader.ReadFile_CountrynameSimpleResources();
            FileReader.ReadFile_NameAirfield();
            FileReader.ReadFile_NameSimpleFactory();
            FileReader.ReadFile_NameMilitaryFactory();

            //не меняются
            FileReader.ReadFile_ColorName();
            FileReader.ReadFile_NamePort();
            FileReader.ReadFile_NameNeighbours();
            FileReader.ReadFile_NamesPoints();

            DrawStartMap();
            UpdateMap();
        }
        /* 
 public bool ColorsRepeat()
 {
     List<Color> colors = new List<Color>();
     foreach (var country in Dictionary_CountrynameCharacteristics)
     {
         if (colors.Contains(country.Value.Color))
         {
             return true;
         }
     }
     return false;
 }

 public void PaintRegionsMap()
 {
     int a = 0;
     int g = 0;
     int b = 10;
     foreach (var province in Dictionary_NamesPoints)
     {
         foreach (var point in province.Value)
         {
             FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.FromArgb(a, g, b));
         }
         b += 10;
         if (b >= 256)
         {
             b -= 256;
             g += 10;
         }
         if (g >= 256)
         {
             g -= 256;
             a += 10;
         }
     }
     baseBitmap.Save("bitmap.bmp");
 }*/
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
            ResizeLabelsAndButtons();
            ResizeTabControl();
            UpdateMap();
        }

        private void splitterVertical_SplitterMoved(object sender, SplitterEventArgs e)
        {

        } //ничего не делает

        //resizы
        private void ResizeTabControl()
        {
            tabControl1.Width = splitterVertical.Panel2.Width;
            tabControl1.Height = splitterVertical.Panel2.Height - tabControl1.Location.Y;
        }

        private void ResizeLabelsAndButtons()
        {
            provinceName.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 9);
            ownerCountry.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 49);
            occupantCountry.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 79);
            producedResource.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 119);
            producedMilitaryResource.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 149);
        }

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
                int offsetX = (int)(rect.Width / 2 - e.X);
                rect.X -= offsetX;

                while (rect.X < 0)
                {
                    rect.X += 8192;
                }
                while (rect.X >= 8192)
                {
                    rect.X -= 8192;
                }

                int offsetY = (int)(rect.Height / 2 - e.Y);
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
                if (baseBitmap.GetPixel(x, y) != black &&
                    baseBitmap.GetPixel(x, y) != water &&
                    baseBitmap.GetPixel(x, y) != fakeBlack &&
                    baseBitmap.GetPixel(x, y) != white &&
                    baseBitmap.GetPixel(x, y) != borderGray &&
                    baseBitmap.GetPixel(x, y) != otherBorderGray)
                {
                    provinceName.Show();
                    ownerCountry.Show();
                    provinceName.Text = Dictionary_ColorName[baseBitmapRegions.GetPixel(x, y)];
                    ownerCountry.Text = "Owner: " + Dictionary_NameOwner[provinceName.Text];


                    int importBonus = 0;
                    if (Dictionary_NamePort.Keys.Contains(provinceName.Text))
                    {
                        importBonus += Dictionary_NamePort[provinceName.Text];
                    }
                    if (Dictionary_NameAirfield.Keys.Contains(provinceName.Text))
                    {
                        importBonus += Dictionary_NameAirfield[provinceName.Text].Planes.Length;
                        plane0.Show();
                        if (Dictionary_NameAirfield[provinceName.Text].Planes[0] != null)
                        {
                            plane0.Text = ConvertUnitNameToString(Dictionary_NameAirfield[provinceName.Text].Planes[0].Name);
                        }

                        plane1.Show();
                        if (Dictionary_NameAirfield[provinceName.Text].Planes[1] != null)
                        {
                            plane1.Text = ConvertUnitNameToString(Dictionary_NameAirfield[provinceName.Text].Planes[1].Name);
                        }

                        if (Dictionary_NameAirfield[provinceName.Text].Planes.Length == 5)
                        {
                            plane2.Show();
                            if (Dictionary_NameAirfield[provinceName.Text].Planes[2] != null)
                            {
                                plane2.Text = ConvertUnitNameToString(Dictionary_NameAirfield[provinceName.Text].Planes[2].Name);
                            }

                            plane3.Show();
                            if (Dictionary_NameAirfield[provinceName.Text].Planes[3] != null)
                            {
                                plane3.Text = ConvertUnitNameToString(Dictionary_NameAirfield[provinceName.Text].Planes[3].Name);
                            }

                            plane4.Show();
                            if (Dictionary_NameAirfield[provinceName.Text].Planes[4] != null)
                            {
                                plane4.Text = ConvertUnitNameToString(Dictionary_NameAirfield[provinceName.Text].Planes[4].Name);
                            }
                        }

                    }
                    if (importBonus > 0)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    provinceName.Hide();
                    ownerCountry.Hide();
                }

            }/*
            else if (e.Button == MouseButtons.XButton1)
            {
                if (baseBitmap.GetPixel(x, y) != black &&
                    baseBitmap.GetPixel(x, y) != water &&
                    baseBitmap.GetPixel(x, y) != fakeBlack &&
                    baseBitmap.GetPixel(x, y) != white &&
                    baseBitmap.GetPixel(x, y) != borderGray &&
                    baseBitmap.GetPixel(x, y) != otherBorderGray)
                {
                    
                    PaintItBack(new List<string>() { button1.Text });
                    PaintItBack(Dictionary_NameNeighbours[button1.Text]);
                    button1.Text = Dictionary_ColorName[baseBitmapRegions.GetPixel(x,y)];
                    PaintAdded1(new List<string>() { button1.Text });
                    PaintAdded(Dictionary_NameNeighbours[button1.Text]);
                }
            }
            else if (e.Button == MouseButtons.XButton2)
            {
                string path = @"C:\Users\Comrade Thursday\Documents\TXT1.txt";
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    foreach (var name in Dictionary_NameNeighbours.Keys)
                    {
                        outputFile.Write(name + ";");
                        if (Dictionary_NameNeighbours[name].Count > 0)
                        {
                            for (int i = 0; i < Dictionary_NameNeighbours[name].Count - 1; i++)
                            {
                                outputFile.Write(Dictionary_NameNeighbours[name][i] + ",");
                            }
                            outputFile.WriteLine(Dictionary_NameNeighbours[name][Dictionary_NameNeighbours[name].Count - 1]);
                        }
                        else outputFile.WriteLine();
                    }
                }
            }*/
            UpdateMap();
        }

        public void PaintAdded(List<string> neighbours)
        {
            foreach (var name in neighbours)
            {
                foreach (var point in Dictionary_NamesPoints[name])
                {
                    FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.Red);
                }
            }
        }
        public void PaintAdded1(List<string> neighbours)
        {
            foreach (var name in neighbours)
            {
                foreach (var point in Dictionary_NamesPoints[name])
                {
                    FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.Green);
                }
            }
        }

        public void PaintItBack(List<string> neighbours)
        {
            foreach (var name in neighbours)
            {
                foreach (var point in Dictionary_NamesPoints[name])
                {
                    string owner = Dictionary_NameOwner[name];
                    FloodFill(baseBitmap, point, Color.Red, Dictionary_CountrynameCharacteristics[owner].Color);
                }
            }
        }

        public string ConvertUnitNameToString(UnitName.Name name)
        {
            if (name == UnitName.Name.fighterG) { return "Generic fighter"; }
            if (name == UnitName.Name.fighterA) { return "Western fighter"; }
            if (name == UnitName.Name.fighterR) { return "Soviet fighter"; }
            if (name == UnitName.Name.strikeAircraftA) { return "American strike aircraft"; }
            if (name == UnitName.Name.strikeAircraftR) { return "Soviet strike aircraft"; }
            if (name == UnitName.Name.strikeAircraftG) { return "Generic strike aircraft"; }

            throw new ArgumentException();
        }

        private void PaxApocalyticaGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string savePath = folderBrowserDialog1.SelectedPath + "\\"; 
            if (folderBrowserDialog1.SelectedPath != "")
            {
                FileWriter.SaveEverything(savePath);
            }
        }

        private void DrawStartMap() 
        {
            foreach(var province in Dictionary_NameOwner.Keys) 
            {
                foreach(var point in Dictionary_NamesPoints[province]) 
                {
                    if (baseBitmap.GetPixel(point.X, point.Y) == Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[province]].Color) { break; }
                    else
                    {
                        FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[province]].Color);
                    }
                }
            }
        }
    }
}