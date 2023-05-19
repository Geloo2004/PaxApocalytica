namespace PaxApocalytica
{
    partial class PaxApocalyticaGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitterVertical = new SplitContainer();
            mapBox = new PictureBox();
            tabControl1 = new TabControl();
            portTab = new TabPage();
            numericUpDown7 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            diplomacyTab = new TabPage();
            armiesTab = new TabPage();
            airfieldTab = new TabPage();
            planeLabel4 = new Label();
            planeLabel3 = new Label();
            planeLabel2 = new Label();
            planeLabel1 = new Label();
            planeLabel0 = new Label();
            plane4 = new Button();
            plane3 = new Button();
            plane2 = new Button();
            plane1 = new Button();
            plane0 = new Button();
            economicsTab = new TabPage();
            occupantCountry = new Label();
            ownerCountry = new Label();
            producedMilitaryResource = new Label();
            producedResource = new Label();
            provinceName = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).BeginInit();
            splitterVertical.Panel1.SuspendLayout();
            splitterVertical.Panel2.SuspendLayout();
            splitterVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapBox).BeginInit();
            tabControl1.SuspendLayout();
            portTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            airfieldTab.SuspendLayout();
            SuspendLayout();
            // 
            // splitterVertical
            // 
            splitterVertical.Dock = DockStyle.Fill;
            splitterVertical.IsSplitterFixed = true;
            splitterVertical.Location = new Point(0, 0);
            splitterVertical.Name = "splitterVertical";
            // 
            // splitterVertical.Panel1
            // 
            splitterVertical.Panel1.Controls.Add(mapBox);
            // 
            // splitterVertical.Panel2
            // 
            splitterVertical.Panel2.Controls.Add(tabControl1);
            splitterVertical.Panel2.Controls.Add(occupantCountry);
            splitterVertical.Panel2.Controls.Add(ownerCountry);
            splitterVertical.Panel2.Controls.Add(producedMilitaryResource);
            splitterVertical.Panel2.Controls.Add(producedResource);
            splitterVertical.Panel2.Controls.Add(provinceName);
            splitterVertical.Size = new Size(1264, 681);
            splitterVertical.SplitterDistance = 900;
            splitterVertical.TabIndex = 0;
            splitterVertical.SplitterMoved += splitterVertical_SplitterMoved;
            // 
            // mapBox
            // 
            mapBox.Location = new Point(3, 3);
            mapBox.Name = "mapBox";
            mapBox.Size = new Size(8192, 4096);
            mapBox.SizeMode = PictureBoxSizeMode.Zoom;
            mapBox.TabIndex = 0;
            mapBox.TabStop = false;
            mapBox.MouseClick += mapBox_MouseClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(portTab);
            tabControl1.Controls.Add(diplomacyTab);
            tabControl1.Controls.Add(armiesTab);
            tabControl1.Controls.Add(airfieldTab);
            tabControl1.Controls.Add(economicsTab);
            tabControl1.Location = new Point(3, 213);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(357, 465);
            tabControl1.TabIndex = 6;
            // 
            // portTab
            // 
            portTab.Controls.Add(numericUpDown7);
            portTab.Controls.Add(numericUpDown6);
            portTab.Controls.Add(numericUpDown5);
            portTab.Controls.Add(numericUpDown4);
            portTab.Controls.Add(numericUpDown3);
            portTab.Controls.Add(numericUpDown2);
            portTab.Controls.Add(numericUpDown1);
            portTab.Location = new Point(4, 24);
            portTab.Name = "portTab";
            portTab.Padding = new Padding(3);
            portTab.Size = new Size(349, 437);
            portTab.TabIndex = 0;
            portTab.Text = "Port";
            portTab.UseVisualStyleBackColor = true;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(264, 285);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(120, 23);
            numericUpDown7.TabIndex = 14;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(297, 243);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 23);
            numericUpDown6.TabIndex = 13;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(283, 192);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 23);
            numericUpDown5.TabIndex = 12;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(274, 132);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 23);
            numericUpDown4.TabIndex = 11;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(284, 85);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(291, 48);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(290, 7);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // diplomacyTab
            // 
            diplomacyTab.Location = new Point(4, 24);
            diplomacyTab.Name = "diplomacyTab";
            diplomacyTab.Padding = new Padding(3);
            diplomacyTab.Size = new Size(349, 437);
            diplomacyTab.TabIndex = 1;
            diplomacyTab.Text = "Diplomacy";
            diplomacyTab.UseVisualStyleBackColor = true;
            // 
            // armiesTab
            // 
            armiesTab.Location = new Point(4, 24);
            armiesTab.Name = "armiesTab";
            armiesTab.Size = new Size(349, 437);
            armiesTab.TabIndex = 2;
            armiesTab.Text = "Armies";
            armiesTab.UseVisualStyleBackColor = true;
            // 
            // airfieldTab
            // 
            airfieldTab.Controls.Add(planeLabel4);
            airfieldTab.Controls.Add(planeLabel3);
            airfieldTab.Controls.Add(planeLabel2);
            airfieldTab.Controls.Add(planeLabel1);
            airfieldTab.Controls.Add(planeLabel0);
            airfieldTab.Controls.Add(plane4);
            airfieldTab.Controls.Add(plane3);
            airfieldTab.Controls.Add(plane2);
            airfieldTab.Controls.Add(plane1);
            airfieldTab.Controls.Add(plane0);
            airfieldTab.Location = new Point(4, 24);
            airfieldTab.Name = "airfieldTab";
            airfieldTab.Size = new Size(349, 437);
            airfieldTab.TabIndex = 3;
            airfieldTab.Text = "Airfield";
            airfieldTab.UseVisualStyleBackColor = true;
            // 
            // planeLabel4
            // 
            planeLabel4.AutoSize = true;
            planeLabel4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            planeLabel4.Location = new Point(136, 188);
            planeLabel4.Name = "planeLabel4";
            planeLabel4.Size = new Size(45, 19);
            planeLabel4.TabIndex = 9;
            planeLabel4.Text = "label2";
            // 
            // planeLabel3
            // 
            planeLabel3.AutoSize = true;
            planeLabel3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            planeLabel3.Location = new Point(136, 146);
            planeLabel3.Name = "planeLabel3";
            planeLabel3.Size = new Size(45, 19);
            planeLabel3.TabIndex = 8;
            planeLabel3.Text = "label2";
            // 
            // planeLabel2
            // 
            planeLabel2.AutoSize = true;
            planeLabel2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            planeLabel2.Location = new Point(136, 104);
            planeLabel2.Name = "planeLabel2";
            planeLabel2.Size = new Size(45, 19);
            planeLabel2.TabIndex = 7;
            planeLabel2.Text = "label2";
            // 
            // planeLabel1
            // 
            planeLabel1.AutoSize = true;
            planeLabel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            planeLabel1.Location = new Point(136, 62);
            planeLabel1.Name = "planeLabel1";
            planeLabel1.Size = new Size(45, 19);
            planeLabel1.TabIndex = 6;
            planeLabel1.Text = "label2";
            // 
            // planeLabel0
            // 
            planeLabel0.AutoSize = true;
            planeLabel0.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            planeLabel0.Location = new Point(136, 20);
            planeLabel0.Name = "planeLabel0";
            planeLabel0.Size = new Size(45, 19);
            planeLabel0.TabIndex = 5;
            planeLabel0.Text = "label1";
            // 
            // plane4
            // 
            plane4.Location = new Point(13, 171);
            plane4.Name = "plane4";
            plane4.Size = new Size(103, 36);
            plane4.TabIndex = 4;
            plane4.Text = "button5";
            plane4.UseVisualStyleBackColor = true;
            // 
            // plane3
            // 
            plane3.Location = new Point(13, 129);
            plane3.Name = "plane3";
            plane3.Size = new Size(103, 36);
            plane3.TabIndex = 3;
            plane3.Text = "button4";
            plane3.UseVisualStyleBackColor = true;
            // 
            // plane2
            // 
            plane2.Location = new Point(13, 87);
            plane2.Name = "plane2";
            plane2.Size = new Size(103, 36);
            plane2.TabIndex = 2;
            plane2.Text = "button3";
            plane2.UseVisualStyleBackColor = true;
            // 
            // plane1
            // 
            plane1.Location = new Point(13, 45);
            plane1.Name = "plane1";
            plane1.Size = new Size(103, 36);
            plane1.TabIndex = 1;
            plane1.Text = "button2";
            plane1.UseVisualStyleBackColor = true;
            // 
            // plane0
            // 
            plane0.Location = new Point(13, 3);
            plane0.Name = "plane0";
            plane0.Size = new Size(103, 36);
            plane0.TabIndex = 0;
            plane0.Text = "button1";
            plane0.UseVisualStyleBackColor = true;
            // 
            // economicsTab
            // 
            economicsTab.Location = new Point(4, 24);
            economicsTab.Name = "economicsTab";
            economicsTab.Size = new Size(349, 437);
            economicsTab.TabIndex = 4;
            economicsTab.Text = "Economics";
            economicsTab.UseVisualStyleBackColor = true;
            // 
            // occupantCountry
            // 
            occupantCountry.AutoSize = true;
            occupantCountry.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            occupantCountry.Location = new Point(3, 79);
            occupantCountry.Name = "occupantCountry";
            occupantCountry.Size = new Size(140, 21);
            occupantCountry.TabIndex = 4;
            occupantCountry.Text = "occupantCountry";
            // 
            // ownerCountry
            // 
            ownerCountry.AutoSize = true;
            ownerCountry.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ownerCountry.Location = new Point(3, 49);
            ownerCountry.Name = "ownerCountry";
            ownerCountry.Size = new Size(117, 21);
            ownerCountry.TabIndex = 3;
            ownerCountry.Text = "ownerCountry";
            // 
            // producedMilitaryResource
            // 
            producedMilitaryResource.AutoSize = true;
            producedMilitaryResource.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            producedMilitaryResource.Location = new Point(3, 149);
            producedMilitaryResource.Name = "producedMilitaryResource";
            producedMilitaryResource.RightToLeft = RightToLeft.No;
            producedMilitaryResource.Size = new Size(209, 21);
            producedMilitaryResource.TabIndex = 2;
            producedMilitaryResource.Text = "producedMilitaryResource";
            // 
            // producedResource
            // 
            producedResource.AutoSize = true;
            producedResource.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            producedResource.Location = new Point(3, 119);
            producedResource.Name = "producedResource";
            producedResource.Size = new Size(153, 21);
            producedResource.TabIndex = 1;
            producedResource.Text = "producedResource";
            // 
            // provinceName
            // 
            provinceName.AutoSize = true;
            provinceName.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            provinceName.Location = new Point(7, 189);
            provinceName.Name = "provinceName";
            provinceName.Size = new Size(118, 21);
            provinceName.TabIndex = 0;
            provinceName.Text = "provinceName";
            // 
            // PaxApocalyticaGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitterVertical);
            Name = "PaxApocalyticaGame";
            Text = "PaxApocalyticaGame";
            FormClosing += PaxApocalyticaGame_FormClosing;
            splitterVertical.Panel1.ResumeLayout(false);
            splitterVertical.Panel2.ResumeLayout(false);
            splitterVertical.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).EndInit();
            splitterVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapBox).EndInit();
            tabControl1.ResumeLayout(false);
            portTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            airfieldTab.ResumeLayout(false);
            airfieldTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitterVertical;
        private PictureBox mapBox;
        private Label provinceName;
        private Label producedMilitaryResource;
        private Label producedResource;
        private Label occupantCountry;
        private Label ownerCountry;
        private TabControl tabControl1;
        private TabPage portTab;
        private TabPage diplomacyTab;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TabPage armiesTab;
        private TabPage airfieldTab;
        private TabPage economicsTab;
        private Button plane4;
        private Button plane3;
        private Button plane2;
        private Button plane1;
        private Button plane0;
        private Label planeLabel4;
        private Label planeLabel3;
        private Label planeLabel2;
        private Label planeLabel1;
        private Label planeLabel0;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}