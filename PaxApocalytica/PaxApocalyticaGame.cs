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
using System.IO;
using System.Drawing.Drawing2D;
using PaxApocalytica.FactoriesAndResources;
using PaxApocalytica.Military;
using System.Media;

namespace PaxApocalytica
{
    public partial class PaxApocalypticaGame : Form
    {
        static byte month = 12;
        static int year = 1991;
        static bool countryIsChosen = false;
        static string chosenCountry = "";

        public static bool deployingArmy = false;
        public static string deployingArmyName;

        public static bool movingArmy = false;
        public static string movingArmyName;
        public static string armyStartProv;

        static bool sendingInterceptors = false;
        static string fighterName;

        static string bomberName;
        static bool sendingBombers = false;

        private static Form1 mainMenu;

        Bitmap baseBitmapIndexed = PaxApocalytica.Properties.Resources.baseMapBmp; //bmp мало памяти
        public static Bitmap baseBitmap;      //png много памяти
        Bitmap map;
        public static Bitmap baseBitmapRegions = PaxApocalytica.Properties.Resources.bitmapRegions;

        static Rectangle rect = new Rectangle(0, 0, 1, 1);

        static Color water;
        static Color fakeBlack;
        static Color borderGray = Color.FromArgb(63, 63, 63);
        static Color otherBorderGray = Color.FromArgb(64, 64, 64);
        static Color black = Color.Black;
        static Color white = Color.White;



        public static Dictionary<string, int[]> AI_SimpleResources;





        public static Dictionary<string, Point[]> Dictionary_NamesPoints;
        public static Dictionary<Color, string> Dictionary_ColorName;
        public static Dictionary<string, string[]> Dictionary_NameNeighbours;
        public static Dictionary<string, int> Dictionary_NamePort;

        /*  allies
         *  rivals
         *  enemies
         *  player/ai
         */

        public static List<string> ExistingCountriesList;
        public static Dictionary<string, SimpleFactory> Dictionary_UpgradeQueue_SFactory;
        public static Dictionary<string, MilitaryFactory> Dictionary_UpgradeQueue_MFactory;
        public static Dictionary<string, string> Dictionary_CreationQueue_Army;
        public static Dictionary<string, List<string>> Dictionary_PactCountrynames;
        public static Dictionary<string, List<string>> Dictionary_NameInterceptors;
        public static Dictionary<string, List<string>> Dictionary_CountrynameFriends;
        public static Dictionary<string, List<string>> Dictionary_CountrynameAllies;
        public static Dictionary<List<string>, List<string>> Dictionary_WarSides;
        public static Dictionary<string, List<string>> Dictionary_CountrynameRivals;

        public static SoundPlayer spShooting;
        public static SoundPlayer spRedArmy;

        public static Dictionary<string, ProvinceCharacteristics> Dictionary_NameCharacteristics;
        public static Dictionary<string, List<string>> Dictionary_NameArmynames;
        public static Dictionary<string, Army> Dictionary_ArmynameArmycharacteristics;
        public static Dictionary<string, List<string>> Dictionary_AIAgentProvinces;
        public static Dictionary<string, string> Dictionary_NameOwner;
        public static Dictionary<string, string> Dictionary_NameOccupant;
        public static Dictionary<string, CountryCharacteristics> Dictionary_CountrynameCharacteristics;
        public static Dictionary<string, int[]> Dictionary_CountrynameSimpleResources;
        public static Dictionary<string, int[]> Dictionary_CountrynameSimpleResources_Trade;
        public static Dictionary<string, int> Dictionary_CountrynameSimpleResources_Trade_ReduceTrade;

        public static Dictionary<string, int[]> Dictionary_CountrynameMilitaryResources;
        public static Dictionary<string, Airfield> Dictionary_NameAirfield;
        public static Dictionary<string, SimpleFactory> Dictionary_NameSFactory;
        public static Dictionary<string, MilitaryFactory> Dictionary_NameMFactory;

        public static Dictionary<string, bool[]> Dictionary_CanBuildUnit;

        //Dictionary<string, string> Dictionary_NameController;     //  ai/player

        public PaxApocalypticaGame(Form1 MainMenuForm)
        {
            mainMenu = MainMenuForm;
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
            playerCountry.Text = "Choose your country";
            cash.Hide();
            provinceName.Hide();
            date.Hide();
            resourcesManagerBttn.Hide();
            increaseEL.Hide();
            increaseTL.Hide();
            decreaseEL.Hide();
            decreaseTL.Hide();
            extensionLevelLabel.Hide();
            technologicalLevelLabel.Hide();
            simpleResourcePBox.Hide();
            militaryManagementBttn.Hide();
            educationEffortTrack.Hide();
            educationLevelBar.Hide();
            educationEffortLabel.Hide();
            educationLevelLabel.Hide();
            increaseEL_MF.Hide();
            increaseTL_MF.Hide();
            decreaseEL_MF.Hide();
            decreaseTL_MF.Hide();
            militaryResourceTBox.Hide();
            extensionLevelLabel_MF.Hide();
            technologicalLevelLabel_MF.Hide();
            buildMilFactoryBttn.Hide();
            diplomacyMenuBttn.Hide();

            plane1.Hide();
            plane2.Hide();
            plane3.Hide();
            plane4.Hide();
            plane5.Hide();

            //spShooting = new SoundPlayer(Resources.shooting);

            splitterVertical.Panel2MinSize = splitterVertical.Panel2.Width;

            Dictionary_CountrynameSimpleResources_Trade_ReduceTrade = new Dictionary<string, int>();

            Dictionary_NameInterceptors = new Dictionary<string, List<string>>();

            FileReader.ReadFile_NameOwner();
            FileReader.ReadFile_NameOccupant();
            FileReader.ReadFile_CountrynameCharacterstics();
            FileReader.ReadFile_CountrynameMilResources();
            FileReader.ReadFile_CountrynameSimpleResources();
            FileReader.ReadFile_CountrynameSimpleResources_Trade();
            FileReader.ReadFile_NameAirfield();
            FileReader.ReadFile_NameSimpleFactory();
            FileReader.ReadFile_NameMilitaryFactory();
            FileReader.ReadFile_NameCharacteristics();
            FileReader.ReadFile_NameArmynames();
            FileReader.ReadFile_ArmynameArmycharacteristics();
            FileReader.ReadFile_CreationQueue_Army();
            FileReader.ReadFile_UpgradeQueue_MFactory();
            FileReader.ReadFile_UpgradeQueue_SFactory();

            FileReader.ReadFile_CountrynameFriends();
            FileReader.ReadFile_CountrynameAllies();
            FileReader.ReadFile_WarSides();
            FileReader.ReadFile_CountrynameRivals();

            FileReader.ReadFile_PactCountrynames();


            //не меняются
            FileReader.ReadFile_ColorName();
            FileReader.ReadFile_NamePort();
            FileReader.ReadFile_NameNeighbours();
            FileReader.ReadFile_NamesPoints();



            if (Form1.path == null)
            {
                StartCalcualtor.CalculateStartSResources();
                StartCalcualtor.CalculateStartMResources();
                StartCalcualtor.CalculateStartManpower();
                StartCalcualtor.CalculateStartCash();
                StartCalcualtor.GenerateRandomPlanes();
            }
            Calculator.RecalculateExistingCountries();
            Calculator.RecalculateTradeSlots();
            Calculator.RecalcualteManpower();
            Calculator.RecalcualteCash();
            Calculator.RecalculateIsFunctioning();


            foreach (var armyName in Dictionary_ArmynameArmycharacteristics.Keys)
            {
                if (Dictionary_ArmynameArmycharacteristics[armyName].CheckAllDead())
                {
                    Dictionary_ArmynameArmycharacteristics.Remove(armyName);
                }
            }


            Dictionary_CanBuildUnit = new Dictionary<string, bool[]>();
            foreach (var country in Dictionary_CountrynameCharacteristics.Keys)
            {
                Dictionary_CanBuildUnit.Add(country, new bool[27]);
                Calculator.RecalculateCanBuildUnit(country);
            }
            //spRedArmy = new SoundPlayer(Resources.JolyFox___Red_Army_Is_The_Strongest__TNO_Fan_made___128_kbps_);
            //spRedArmy.Play();
            DrawStartMap();
            UpdateMap();
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
            ResizeLabelsAndButtons();
            UpdateMap();
        }
        private void splitterVertical_SplitterMoved(object sender, SplitterEventArgs e)
        {

        } //ничего не делает
        //resizы
        private void ResizeLabelsAndButtons()
        {
            provinceName.Location = new Point(splitterVertical.Location.X + 3, splitterVertical.Location.Y + 229);
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
        }

        public void FloodFill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
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
            // spShooting.Play();
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
                    if(mapmode.Text == "2") { ShowMapmode2(); }

                    string clickedProvinceName = Dictionary_ColorName[baseBitmapRegions.GetPixel(x, y)];
                    if (movingArmy)
                    {

                        //добавить проверку на союзников, врагов


                        //startbattle
                        // if won {move}

                        if (Dictionary_NameNeighbours[armyStartProv].Contains(clickedProvinceName))     //тыкнутая пров-я сосед?
                        {
                            Dictionary_NameArmynames[clickedProvinceName].Add(movingArmyName);
                            Dictionary_NameArmynames[armyStartProv].Remove(movingArmyName);
                            Dictionary_ArmynameArmycharacteristics[movingArmyName].IsMoved = true;
                            movingArmy = false;
                            movingArmyName = null;

                            foreach (var point in Dictionary_NamesPoints[armyStartProv])
                            {
                                FloodFill(baseBitmap, point, Color.White, Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[armyStartProv]].Color);
                            }
                            armyStartProv = null;
                        }
                        else if (Dictionary_NamePort.ContainsKey(armyStartProv))        //здесь порт?
                        {
                            if (Dictionary_NamePort.ContainsKey(clickedProvinceName))       //тыкнутая порт?
                            {
                                Dictionary_NameArmynames[clickedProvinceName].Add(movingArmyName);
                                Dictionary_NameArmynames[armyStartProv].Remove(movingArmyName);
                                Dictionary_ArmynameArmycharacteristics[movingArmyName].IsMoved = true;
                                movingArmy = false;
                                movingArmyName = null;

                                foreach (var point in Dictionary_NamesPoints[armyStartProv])
                                {
                                    FloodFill(baseBitmap, point, Color.White, Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[armyStartProv]].Color);
                                }
                                armyStartProv = null;
                            }
                        }
                        else if (Dictionary_NameAirfield.ContainsKey(armyStartProv))    //есть аэродром здесь?
                        {
                            if (Calculator.CheckOnlyVDV(movingArmyName))        // вдв
                            {
                                Dictionary_NameArmynames[clickedProvinceName].Add(movingArmyName);
                                Dictionary_NameArmynames[armyStartProv].Remove(movingArmyName);
                                Dictionary_ArmynameArmycharacteristics[movingArmyName].IsMoved = true;
                                movingArmy = false;
                                movingArmyName = null;

                                foreach (var point in Dictionary_NamesPoints[armyStartProv])
                                {
                                    FloodFill(baseBitmap, point, Color.White, Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[armyStartProv]].Color);
                                }
                                armyStartProv = null;
                            }
                            else if (Dictionary_NameAirfield.ContainsKey(clickedProvinceName))      //есть аэродром там? (не вдв)
                            {
                                Dictionary_NameArmynames[clickedProvinceName].Add(movingArmyName);
                                Dictionary_NameArmynames[armyStartProv].Remove(movingArmyName);
                                Dictionary_ArmynameArmycharacteristics[movingArmyName].IsMoved = true;
                                movingArmy = false;
                                movingArmyName = null;

                                foreach (var point in Dictionary_NamesPoints[armyStartProv])
                                {
                                    FloodFill(baseBitmap, point, Color.White, Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[armyStartProv]].Color);
                                }
                                armyStartProv = null;
                            }
                        }
                    }
                    else if (deployingArmy)
                    {

                        if (Dictionary_NameOwner[clickedProvinceName] == playerCountry.Text)
                        {
                            Dictionary_CreationQueue_Army.Add(1 + "," + clickedProvinceName, deployingArmyName);
                            deployingArmy = false;
                        }
                    }
                    else if (sendingBombers)
                    {
                        if(Calculator.CheckAtWar(playerCountry.Text, Dictionary_NameOccupant[clickedProvinceName])) 
                        {
                            bool destroyed = false;
                            Calculator.BombingProvince(clickedProvinceName, bomberName, ref destroyed);
                            if (destroyed)
                            {
                                if (plane1.Text == bomberName) { plane1.Text = "Add Plane"; }
                                else if (plane2.Text == bomberName) { plane2.Text = "Add Plane"; }
                                else if (plane3.Text == bomberName) { plane3.Text = "Add Plane"; }
                                else if (plane4.Text == bomberName) { plane4.Text = "Add Plane"; }
                                else if (plane5.Text == bomberName) { plane5.Text = "Add Plane"; }
                            }
                        }
                        //enemies
                    }
                    else if (sendingInterceptors)
                    {
                        //allies , yourself
                    }
                    else
                    {
                        if (countryIsChosen)
                        {
                            provinceName.Show();
                            provinceName.Text = clickedProvinceName;
                            date.Text = Convert.ToString(Dictionary_NameCharacteristics[provinceName.Text].Manpower);

                            educationLevelBar.Value = Dictionary_NameCharacteristics[provinceName.Text].Eductaion;
                            educationLevelLabel.Text = Convert.ToString(educationLevelBar.Value);

                            if (Dictionary_NameAirfield.ContainsKey(provinceName.Text))
                            {
                                plane1.Show();
                                plane2.Show();

                                if (Dictionary_NameAirfield[provinceName.Text].Planes[0] == null) { plane1.Text = "Add plane"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.fighterA) { plane1.Text = "NATO Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.fighterR) { plane1.Text = "Sov. Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.fighterG) { plane1.Text = "Generic Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.strikeAircraftA) { plane1.Text = "NATO Strike Aircraft"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.strikeAircraftR) { plane1.Text = "Sov. Strike Aircraft"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[0].Name == UnitName.Name.strikeAircraftG) { plane1.Text = "Generic Strike Aircraft"; }
                                else { throw new ArgumentException(); }

                                if (Dictionary_NameAirfield[provinceName.Text].Planes[1] == null) { plane2.Text = "Add plane"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.fighterA) { plane2.Text = "NATO Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.fighterR) { plane2.Text = "Sov. Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.fighterG) { plane2.Text = "Generic Fighter"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.strikeAircraftA) { plane2.Text = "NATO Strike Aircraft"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.strikeAircraftR) { plane2.Text = "Sov. Strike Aircraft"; }
                                else if (Dictionary_NameAirfield[provinceName.Text].Planes[1].Name == UnitName.Name.strikeAircraftG) { plane2.Text = "Generic Strike Aircraft"; }
                                else { throw new ArgumentException(); }



                                if ((Dictionary_NameAirfield[provinceName.Text].Planes.Length == 5))
                                {
                                    plane3.Show();
                                    plane4.Show();
                                    plane5.Show();

                                    if (Dictionary_NameAirfield[provinceName.Text].Planes[2] == null) { plane3.Text = "Add plane"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.fighterA) { plane3.Text = "NATO Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.fighterR) { plane3.Text = "Sov. Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.fighterG) { plane3.Text = "Generic Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.strikeAircraftA) { plane3.Text = "NATO Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.strikeAircraftR) { plane3.Text = "Sov. Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[2].Name == UnitName.Name.strikeAircraftG) { plane3.Text = "Generic Strike Aircraft"; }
                                    else { throw new ArgumentException(); }

                                    if (Dictionary_NameAirfield[provinceName.Text].Planes[3] == null) { plane4.Text = "Add plane"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.fighterA) { plane4.Text = "NATO Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.fighterR) { plane4.Text = "Sov. Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.fighterG) { plane4.Text = "Generic Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.strikeAircraftA) { plane4.Text = "NATO Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.strikeAircraftR) { plane4.Text = "Sov. Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[3].Name == UnitName.Name.strikeAircraftG) { plane4.Text = "Generic Strike Aircraft"; }
                                    else { throw new ArgumentException(); }


                                    if (Dictionary_NameAirfield[provinceName.Text].Planes[4] == null) { plane5.Text = "Add plane"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.fighterA) { plane5.Text = "NATO Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.fighterR) { plane5.Text = "Sov. Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.fighterG) { plane5.Text = "Generic Fighter"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.strikeAircraftA) { plane5.Text = "NATO Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.strikeAircraftR) { plane5.Text = "Sov. Strike Aircraft"; }
                                    else if (Dictionary_NameAirfield[provinceName.Text].Planes[4].Name == UnitName.Name.strikeAircraftG) { plane5.Text = "Generic Strike Aircraft"; }
                                    else { throw new ArgumentException(); }
                                }
                                else
                                {
                                    plane4.Hide();
                                    plane5.Hide();
                                }

                                if (Dictionary_NameOwner[provinceName.Text] != playerCountry.Text)
                                {

                                    plane1.Enabled = false;
                                    plane2.Enabled = false;
                                    plane3.Enabled = false;
                                    plane4.Enabled = false;
                                    plane5.Enabled = false;
                                }
                                else if (!Calculator.CanSendAirRaids(playerCountry.Text))
                                {
                                    plane1.Enabled = false;
                                    plane2.Enabled = false;
                                    plane3.Enabled = false;
                                    plane4.Enabled = false;
                                    plane5.Enabled = false;
                                }
                                else
                                {
                                    plane1.Enabled = true;
                                    plane2.Enabled = true;
                                    plane3.Enabled = true;
                                    plane4.Enabled = true;
                                    plane5.Enabled = true;
                                }
                            }
                            else
                            {
                                plane1.Hide();
                                plane2.Hide();
                                plane3.Hide();
                                plane4.Hide();
                                plane5.Hide();
                            }

                            UpdateSFactoryInterface();
                            UpdateMFactoryInterface();
                        }
                        else
                        {
                            playerCountry.Show();
                            chosenCountry = Dictionary_NameOwner[clickedProvinceName];
                            playerCountry.Text = chosenCountry;
                            saveChoice.Text = "I want to play as this country";
                        }
                    }
                }
                else
                {
                    simpleResourcePBox.Hide();
                    provinceName.Hide();
                    increaseEL.Hide();
                    increaseTL.Hide();
                    decreaseEL.Hide();
                    decreaseTL.Hide();
                    extensionLevelLabel.Hide();
                    technologicalLevelLabel.Hide();
                    educationEffortTrack.Hide();
                    educationLevelBar.Hide();
                    educationEffortLabel.Hide();
                    educationLevelLabel.Hide();
                    increaseEL_MF.Hide();
                    increaseTL_MF.Hide();
                    decreaseEL_MF.Hide();
                    decreaseTL_MF.Hide();
                    militaryResourceTBox.Hide();
                    buildMilFactoryBttn.Hide();
                    if (!countryIsChosen)
                    {
                        playerCountry.Hide();
                        playerCountry.Text = "Choose your country";
                        chosenCountry = "";
                        saveChoice.Text = "I want to play as ...";
                    }
                }

            }
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

        private void PaxApocalyticaGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string savePath = folderBrowserDialog1.SelectedPath + "\\";
            if (folderBrowserDialog1.SelectedPath != "")
            {
                FileWriter.SaveEverything(savePath);
            }
            mainMenu.Close();
        }

        private void DrawStartMap()
        {
            foreach (var province in Dictionary_NameOwner.Keys)
            {
                foreach (var point in Dictionary_NamesPoints[province])
                {
                    if (baseBitmap.GetPixel(point.X, point.Y) == Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[province]].Color) { break; }
                    else
                    {
                        FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Dictionary_CountrynameCharacteristics[Dictionary_NameOwner[province]].Color);
                    }
                }
            }
        }

        private void saveChoice_Click(object sender, EventArgs e)
        {
            if (chosenCountry != "")
            {
                countryIsChosen = true;
                saveChoice.Hide();
                saveChoice.Dispose();
                cash.Show();
                UpdatePlayerData();
                resourcesManagerBttn.Show();
                militaryManagementBttn.Show();
                diplomacyMenuBttn.Show();
            }
        }

        public void UpdatePlayerData()
        {
            cash.Text = "Cash: " + Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash;

            /*
            if (month == 12) { date.Text = "December " + year; }
            if (month == 1) { date.Text = "January " + year; }
            if (month == 2) { date.Text = "February " + year; }
            if (month == 3) { date.Text = "March " + year; }
            if (month == 4) { date.Text = "April " + year; }
            if (month == 5) { date.Text = "May " + year; }
            if (month == 6) { date.Text = "June " + year; }
            if (month == 7) { date.Text = "July " + year; }
            if (month == 8) { date.Text = "August " + year; }
            if (month == 9) { date.Text = "September " + year; }
            if (month == 10) { date.Text = "October " + year; }
            if (month == 11) { date.Text = "November " + year; }*/
        }

        private void resourcesManagerBttn_Click(object sender, EventArgs e)
        {
            if (countryIsChosen)
            {
                Resource_Management rM = new Resource_Management(playerCountry.Text);
                rM.Show();
            }
        }

        private void militaryManagement_Click(object sender, EventArgs e)
        {
            if (countryIsChosen)
            {
                Military_management mM = new Military_management(playerCountry.Text, this);
                mM.Show();
            }
        }

        public void UpdateSFactoryInterface()
        {
            simpleResourcePBox.Show();


            if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Steel) { simpleResourcePBox.Image = Resources.SteelImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Gold) { simpleResourcePBox.Image = Resources.goldImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Oil) { simpleResourcePBox.Image = Resources.oilImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Copper) { simpleResourcePBox.Image = Resources.copperImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Coal) { simpleResourcePBox.Image = Resources.coalImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Uranium) { simpleResourcePBox.Image = Resources.uraniumImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Aluminium) { simpleResourcePBox.Image = Resources.aluminiumImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Gas) { simpleResourcePBox.Image = Resources.gasImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Grain) { simpleResourcePBox.Image = Resources.grainImage; }
            else if (Dictionary_NameSFactory[provinceName.Text].ProducedResourceName == SimpleResources.Names.Livestock) { simpleResourcePBox.Image = Resources.livestockImagejpg; }
            else { throw new ArgumentException(); }

            if (!Calculator.CheckBuildingSomething(provinceName.Text) && Dictionary_NameOwner[provinceName.Text] == playerCountry.Text)
            {
                increaseEL.Show();
                increaseTL.Show();
                decreaseEL.Show();
                decreaseTL.Show();
                educationEffortTrack.Show();
                educationEffortLabel.Show();
                educationEffortTrack.Value = Dictionary_NameCharacteristics[provinceName.Text].EductaionEffort;
                educationEffortLabel.Text = Convert.ToString(educationEffortTrack.Value);

                int euc = Dictionary_NameSFactory[provinceName.Text].CalculateEUpgradeCost(Dictionary_NameCharacteristics[provinceName.Text].Eductaion);
                int tuc = Dictionary_NameSFactory[provinceName.Text].CalculateTUpgradeCost(Dictionary_NameCharacteristics[provinceName.Text].Eductaion);

                if (Dictionary_NameSFactory[provinceName.Text].ExtensionLevel == 10)
                {
                    decreaseEL.Enabled = true;
                    increaseEL.Enabled = false;
                    increaseEL.Text = "Max EL";
                }
                else
                {
                    decreaseEL.Enabled = true;
                    if (Dictionary_NameSFactory[provinceName.Text].ExtensionLevel == 1) { decreaseEL.Enabled = false; }
                    if (Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash >= euc)
                    {
                        increaseEL.Enabled = true;
                        increaseEL.Text = Convert.ToString(euc);
                    }
                    else
                    {
                        increaseEL.Enabled = false;
                        increaseEL.Text = Convert.ToString(euc);
                    }
                }

                if (Dictionary_NameSFactory[provinceName.Text].TechnologyLevel == 10)
                {
                    increaseTL.Enabled = false;
                    increaseTL.Text = "Max TL";
                }
                else if (Dictionary_NameSFactory[provinceName.Text].TechnologyLevel == 1) { decreaseTL.Enabled = false; }
                else
                {
                    if (Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash >= tuc)
                    {
                        increaseTL.Enabled = true;
                        increaseTL.Text = Convert.ToString(tuc);
                    }
                    else
                    {
                        increaseTL.Enabled = false;
                        increaseTL.Text = Convert.ToString(tuc);
                    }
                }

            }
            else
            {
                educationEffortLabel.Hide();
                educationEffortTrack.Hide();
                increaseEL.Hide();
                increaseTL.Hide();
                decreaseEL.Hide();
                decreaseTL.Hide();
            }
            educationLevelBar.Show();
            educationLevelLabel.Show();
            extensionLevelLabel.Text = "E. D. " + Dictionary_NameSFactory[provinceName.Text].ExtensionLevel;
            technologicalLevelLabel.Text = "T. D. " + Dictionary_NameSFactory[provinceName.Text].TechnologyLevel;
            extensionLevelLabel.Show();
            technologicalLevelLabel.Show();
        }
        public void UpdateMFactoryInterface()
        {
            if (Dictionary_NameMFactory[provinceName.Text] != null)
            {
                buildMilFactoryBttn.Hide();
                militaryResourceTBox.Show();

                if (Dictionary_NameMFactory[provinceName.Text].IsFunctioning)
                {
                    if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.Weaponry) { militaryResourceTBox.Text = "Weaponry"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T72B) { militaryResourceTBox.Text = "T-72B"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T90A) { militaryResourceTBox.Text = "T-90A"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T90M) { militaryResourceTBox.Text = "T-90M"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T14) { militaryResourceTBox.Text = "T-14"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMP2) { militaryResourceTBox.Text = "BMP-2"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMP3) { militaryResourceTBox.Text = "BMP-3"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMD1) { militaryResourceTBox.Text = "BMD-1"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMD2) { militaryResourceTBox.Text = "BMD-2"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.FighterR) { militaryResourceTBox.Text = "Sov. Fighter"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.StrikeAircraftR) { militaryResourceTBox.Text = "Sov. Strike Aircraft"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M1) { militaryResourceTBox.Text = "M1"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M1A1) { militaryResourceTBox.Text = "M1A1"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M1A2) { militaryResourceTBox.Text = "M1A2"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M1A2C) { militaryResourceTBox.Text = "M1A2C"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M3A1) { militaryResourceTBox.Text = "M3A1"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.M3A3) { militaryResourceTBox.Text = "M3A3"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.FighterA) { militaryResourceTBox.Text = "NATO Fighter"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.StrikeAircraftA) { militaryResourceTBox.Text = "NATO Strike Aircraft"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T55) { militaryResourceTBox.Text = "T-55"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T55M) { militaryResourceTBox.Text = "T-55M"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T72A) { militaryResourceTBox.Text = "T-72A"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.T72M) { militaryResourceTBox.Text = "T-72M"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMP1) { militaryResourceTBox.Text = "BMP-1"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.BMP23) { militaryResourceTBox.Text = "BMP-23"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.FighterG) { militaryResourceTBox.Text = "Generic Fighter"; }
                    else if (Dictionary_NameMFactory[provinceName.Text].ProducedResourceName == MilitaryResources.Names.StrikeAircraftG) { militaryResourceTBox.Text = "Generic Strike Aircraft"; }
                    else { throw new ArgumentException(); }
                }
                else { militaryResourceTBox.Text = "Not functioning"; }


                if (!Calculator.CheckBuildingSomething(provinceName.Text) && Dictionary_NameOwner[provinceName.Text] == playerCountry.Text)
                {
                    increaseEL_MF.Show();
                    increaseTL_MF.Show();
                    decreaseEL_MF.Show();
                    decreaseTL_MF.Show();


                    int euc = Dictionary_NameMFactory[provinceName.Text].CalculateEUpgradeCost(Dictionary_NameCharacteristics[provinceName.Text].Eductaion);
                    int tuc = Dictionary_NameMFactory[provinceName.Text].CalculateTUpgradeCost(Dictionary_NameCharacteristics[provinceName.Text].Eductaion);

                    if (Dictionary_NameMFactory[provinceName.Text].ExtensionLevel == 10)
                    {
                        decreaseEL_MF.Enabled = true;
                        increaseEL_MF.Enabled = false;
                        increaseEL_MF.Text = "Max EL";
                    }
                    else if (Dictionary_NameMFactory[provinceName.Text].TechnologyLevel == 1) { decreaseEL_MF.Enabled = false; }
                    else
                    {
                        decreaseEL_MF.Enabled = true;
                        if (Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash >= euc)
                        {
                            increaseEL_MF.Enabled = true;
                            increaseEL_MF.Text = Convert.ToString(euc);
                        }
                        else
                        {
                            increaseEL_MF.Enabled = false;
                            increaseEL_MF.Text = Convert.ToString(euc);
                        }
                    }

                    if (Dictionary_NameMFactory[provinceName.Text].TechnologyLevel == 10)
                    {
                        increaseTL_MF.Enabled = false;
                        increaseTL_MF.Text = "Max TL";
                    }
                    else if (Dictionary_NameMFactory[provinceName.Text].TechnologyLevel == 1) { decreaseTL_MF.Enabled = false; }
                    else
                    {
                        if (Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash >= tuc)
                        {
                            increaseTL_MF.Enabled = true;
                            increaseTL_MF.Text = Convert.ToString(tuc);
                        }
                        else
                        {
                            increaseTL_MF.Enabled = false;
                            increaseTL_MF.Text = Convert.ToString(tuc);
                        }
                    }
                }
                else
                {
                    increaseEL_MF.Hide();
                    increaseTL_MF.Hide();
                    decreaseEL_MF.Hide();
                    decreaseTL_MF.Hide();
                }
                extensionLevelLabel_MF.Text = "E. D. " + Dictionary_NameSFactory[provinceName.Text].ExtensionLevel;
                technologicalLevelLabel_MF.Text = "T. D. " + Dictionary_NameSFactory[provinceName.Text].TechnologyLevel;
                extensionLevelLabel_MF.Show();
                technologicalLevelLabel_MF.Show();
            }
            else
            {
                increaseEL_MF.Hide();
                increaseTL_MF.Hide();
                decreaseEL_MF.Hide();
                decreaseTL_MF.Hide();
                extensionLevelLabel_MF.Hide();
                technologicalLevelLabel_MF.Hide();
                militaryResourceTBox.Hide();

                if (Dictionary_NameOwner[provinceName.Text] == playerCountry.Text)
                {
                    buildMilFactoryBttn.Show();
                    if (Calculator.CheckBuildingSomething(provinceName.Text))
                    {
                        buildMilFactoryBttn.Enabled = false;
                    }
                    else
                    {
                        buildMilFactoryBttn.Enabled = true;
                    }
                }
                else
                {
                    buildMilFactoryBttn.Hide();
                }
            }
        }


        private void educationEffortTrack_Scroll(object sender, EventArgs e)
        {
            Dictionary_NameCharacteristics[provinceName.Text].EductaionEffort = (byte)educationEffortTrack.Value;
            educationEffortLabel.Text = Convert.ToString(educationEffortTrack.Value);
        }


        private void buildMilFactoryBttn_Click(object sender, EventArgs e)
        {
            Dictionary_CountrynameCharacteristics[playerCountry.Text].Cash -= 10000;
            UpdatePlayerData();
            Dictionary_UpgradeQueue_MFactory.Add(12 + "," + provinceName.Text, new MilitaryFactory(MilitaryResources.Names.Weaponry, 1, 1, Dictionary_CountrynameCharacteristics[playerCountry.Text].TechGroup));
            buildMilFactoryBttn.Enabled = false;
        }


        private void militaryResourceTBox_Click(object sender, EventArgs e)
        {
            if (!Calculator.CheckBuildingSomething(provinceName.Text))
            {
                Choose_production cpf = new Choose_production(provinceName.Text);
                cpf.Show();
            }
        }

        private void splitterVertical_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plane1_Click(object sender, EventArgs e)
        {
            if (plane1.Text.Contains("Fighter"))
            {
                sendingInterceptors = true; if (plane1.Text.StartsWith("Generic")) { fighterName = "Generic Fighter"; }
                else { fighterName = "NATO Fighter"; }
            }
            else if (plane1.Text.Contains("Strike"))
            {
                sendingBombers = true;
                if (plane1.Text.StartsWith("Generic")) { bomberName = "Generic Strike Aircraft"; }
                else { bomberName = "NATO Strike Aircraft"; }
            }
            else if (plane1.Text.Contains("Add"))
            {
                Add_Plane ap = new Add_Plane(playerCountry.Text, provinceName.Text, plane1);
                ap.Show();
            }
            else { throw new ArgumentException(); }
        }
        private void plane2_Click(object sender, EventArgs e)
        {
            if (plane2.Text.Contains("Fighter"))
            {
                sendingInterceptors = true; 
                if (plane2.Text.StartsWith("Generic")) { fighterName = "Generic Fighter"; }
                else { fighterName = "NATO Fighter"; }
            }
            else if (plane2.Text.Contains("Strike"))
            {
                sendingBombers = true;
                if (plane2.Text.StartsWith("Generic")) { bomberName = "Generic Strike Aircraft"; }
                else { bomberName = "NATO Strike Aircraft"; }
            }
            else if (plane2.Text.Contains("Add"))
            {
                Add_Plane ap = new Add_Plane(playerCountry.Text, provinceName.Text, plane2);
                ap.Show();
            }
            else { throw new ArgumentException(); }
        }
        private void plane3_Click(object sender, EventArgs e)
        {
            if (plane3.Text.Contains("Fighter"))
            {
                sendingInterceptors = true; if (plane3.Text.StartsWith("Generic")) { fighterName = "Generic Fighter"; }
                else { fighterName = "NATO Fighter"; }
            }
            else if (plane3.Text.Contains("Strike"))
            {
                sendingBombers = true;
                if (plane3.Text.StartsWith("Generic")) { bomberName = "Generic Strike Aircraft"; }
                else { bomberName = "NATO Strike Aircraft"; }
            }
            else if (plane3.Text.Contains("Add"))
            {
                Add_Plane ap = new Add_Plane(playerCountry.Text, provinceName.Text, plane3);
                ap.Show();
            }
            else { throw new ArgumentException(); }

        }
        private void plane4_Click(object sender, EventArgs e)
        {
            if (plane4.Text.Contains("Fighter"))
            {
                sendingInterceptors = true; if (plane4.Text.StartsWith("Generic")) { fighterName = "Generic Fighter"; }
                else { fighterName = "NATO Fighter"; }
            }
            else if (plane4.Text.Contains("Strike"))
            {
                sendingBombers = true;
                if (plane4.Text.StartsWith("Generic")) { bomberName = "Generic Strike Aircraft"; }
                else { bomberName = "NATO Strike Aircraft"; }
            }
            else if (plane4.Text.Contains("Add"))
            {
                Add_Plane ap = new Add_Plane(playerCountry.Text, provinceName.Text, plane4);
                ap.Show();
            }
            else { throw new ArgumentException(); }
        }
        private void plane5_Click(object sender, EventArgs e)
        {
            if (plane5.Text.Contains("Fighter"))
            {
                sendingInterceptors = true; if (plane5.Text.StartsWith("Generic")) { fighterName = "Generic Fighter"; }
                else { fighterName = "NATO Fighter"; }
            }
            else if (plane5.Text.Contains("Strike"))
            {
                sendingBombers = true;
                if (plane5.Text.StartsWith("Generic")) { bomberName = "Generic Strike Aircraft"; }
                else { bomberName = "NATO Strike Aircraft"; }
            }
            else if (plane5.Text.Contains("Add"))
            {
                Add_Plane ap = new Add_Plane(playerCountry.Text, provinceName.Text, plane5);
                ap.Show();
            }
            else { throw new ArgumentException(); }
        }

        private void decreaseEL_Click(object sender, EventArgs e)
        {
            Dictionary_NameSFactory[provinceName.Text].EDegrade();
            UpdateSFactoryInterface();
        }
        private void increaseEL_Click(object sender, EventArgs e)
        {
            Dictionary_UpgradeQueue_SFactory.Add(6 + "," + provinceName.Text,
                new SimpleFactory(Dictionary_NameSFactory[provinceName.Text].ProducedResourceName,
                (byte)(Dictionary_NameSFactory[provinceName.Text].ExtensionLevel + 1),
                Dictionary_NameSFactory[provinceName.Text].TechnologyLevel));

            increaseEL.Hide();
            increaseTL.Hide();
            decreaseEL.Hide();
            decreaseTL.Hide();
            increaseEL_MF.Hide();
            increaseTL_MF.Hide();
            decreaseEL_MF.Hide();
            decreaseTL_MF.Hide();
        }
        private void decreaseTL_Click(object sender, EventArgs e)
        {
            Dictionary_NameSFactory[provinceName.Text].TDegrade();
            UpdateSFactoryInterface();
        }
        private void increaseTL_Click(object sender, EventArgs e)
        {
            Dictionary_UpgradeQueue_SFactory.Add(6 + "," + provinceName.Text,
                new SimpleFactory(Dictionary_NameSFactory[provinceName.Text].ProducedResourceName,
                Dictionary_NameSFactory[provinceName.Text].ExtensionLevel,
                (byte)(Dictionary_NameSFactory[provinceName.Text].TechnologyLevel + 1)));

            increaseEL.Hide();
            increaseTL.Hide();
            decreaseEL.Hide();
            decreaseTL.Hide();
            increaseEL_MF.Hide();
            increaseTL_MF.Hide();
            decreaseEL_MF.Hide();
            decreaseTL_MF.Hide();
        }

        private void decreaseEL_MF_Click(object sender, EventArgs e)
        {
            Dictionary_NameMFactory[provinceName.Text].EDegrade();
            UpdateSFactoryInterface();
        }
        private void increaseEL_MF_Click(object sender, EventArgs e)
        {
            Dictionary_UpgradeQueue_MFactory.Add(6 + "," + provinceName.Text,
               new MilitaryFactory(Dictionary_NameMFactory[provinceName.Text].ProducedResourceName,
              (byte)(Dictionary_NameMFactory[provinceName.Text].ExtensionLevel + 1),
               Dictionary_NameSFactory[provinceName.Text].TechnologyLevel,
               Dictionary_NameMFactory[provinceName.Text].FactoryType));
        }
        private void decreaseTL_MF_Click(object sender, EventArgs e)
        {
            Dictionary_NameMFactory[provinceName.Text].TDegrade();
            UpdateSFactoryInterface();
        }
        private void increaseTL_MF_Click(object sender, EventArgs e)
        {
            Dictionary_UpgradeQueue_MFactory.Add(6 + "," + provinceName.Text,
               new MilitaryFactory(Dictionary_NameMFactory[provinceName.Text].ProducedResourceName,
               Dictionary_NameMFactory[provinceName.Text].ExtensionLevel,
               (byte)(Dictionary_NameSFactory[provinceName.Text].TechnologyLevel + 1),
               Dictionary_NameMFactory[provinceName.Text].FactoryType));

            increaseEL.Hide();
            increaseTL.Hide();
            decreaseEL.Hide();
            decreaseTL.Hide();
            increaseEL_MF.Hide();
            increaseTL_MF.Hide();
            decreaseEL_MF.Hide();
            decreaseTL_MF.Hide();
        }

        private void diplomacyMenuBttn_Click(object sender, EventArgs e)
        {
            if (countryIsChosen)
            {
                Diplomacy_Menu dm = new Diplomacy_Menu(playerCountry.Text);
                dm.Show();
            }
        }

        private void mapmode_Click(object sender, EventArgs e)
        {
            if (mapmode.Text == "1") { mapmode.Text = "2"; ShowMapmode2(); }
            else { mapmode.Text = "1"; ShowMapmode1(); }
        }

        private void ShowMapmode1() //political
        {
            foreach(var province in Dictionary_NameOccupant.Keys) 
            {
                foreach(var point in Dictionary_NamesPoints[province]) 
                {
                    FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Dictionary_CountrynameCharacteristics[Dictionary_NameOccupant[province]].Color);
                }
            }
        }

        private void ShowMapmode2() //diplomatic
        {
            if (provinceName.Visible)
            {
                string country = Dictionary_NameOccupant[provinceName.Text];

                List<string> allies = new List<string>();
                List<string> rivals = new List<string>();
                List<string> warEnemies = new List<string>();

                foreach (var ally in Dictionary_CountrynameAllies[country])
                {
                    if (!allies.Contains(ally))
                    {
                        allies.Add(ally);
                    }
                }
                foreach (var rival in Dictionary_CountrynameRivals[country])
                {
                    if (!rival.Contains(rival))
                    {
                        rivals.Add(rival);
                    }
                }
                foreach (var existingCountry in ExistingCountriesList)
                {
                    if(existingCountry == country) { continue; }
                    if (Calculator.CheckAtWar(country, existingCountry)) 
                    {
                        warEnemies.Add(existingCountry);
                    }
                }
                foreach (var pact in Dictionary_PactCountrynames.Keys)
                {
                    if (Dictionary_PactCountrynames[pact].Contains(country))
                    {
                        foreach (var ally in Dictionary_PactCountrynames[pact])
                        {
                            if (!allies.Contains(ally) && ally != country)
                            {
                                allies.Add(ally);
                            }
                        }
                    }
                }

                foreach (var province in Dictionary_NameOccupant.Keys)
                {
                    if (allies.Contains(Dictionary_NameOccupant[province]))
                    {
                        foreach (var point in Dictionary_NamesPoints[province])
                        {
                            FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.Blue);
                        }
                    }
                    else if (rivals.Contains(Dictionary_NameOccupant[province])) {
                        foreach (var point in Dictionary_NamesPoints[province])
                        {
                            FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.Yellow);
                        }
                    }
                    else if (warEnemies.Contains(Dictionary_NameOccupant[province])) {
                        foreach (var point in Dictionary_NamesPoints[province])
                        {
                            FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.FromArgb(6,6,6));
                        }
                    }
                    else if(Dictionary_NameOccupant[province] == country) 
                    {
                        foreach (var point in Dictionary_NamesPoints[province])
                        {
                            FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Color.Green);
                        }
                    }
                    else
                    {
                        foreach (var point in Dictionary_NamesPoints[province])
                        {
                            FloodFill(baseBitmap, point, baseBitmap.GetPixel(point.X, point.Y), Dictionary_CountrynameCharacteristics[Dictionary_NameOccupant[province]].Color);
                        }
                    }
                }
            }
        }
    }
}