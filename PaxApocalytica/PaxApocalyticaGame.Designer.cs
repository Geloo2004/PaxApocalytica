namespace PaxApocalytica
{
    partial class PaxApocalypticaGame
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
            diplomacyMenuBttn = new Button();
            plane5 = new Button();
            plane4 = new Button();
            plane3 = new Button();
            plane2 = new Button();
            plane1 = new Button();
            buildMilFactoryBttn = new Button();
            educationLevelLabel = new Label();
            educationEffortLabel = new Label();
            educationEffortTrack = new TrackBar();
            educationLevelBar = new ProgressBar();
            militaryResourceTBox = new TextBox();
            increaseTL_MF = new Button();
            decreaseTL_MF = new Button();
            increaseEL_MF = new Button();
            decreaseEL_MF = new Button();
            technologicalLevelLabel_MF = new Label();
            extensionLevelLabel_MF = new Label();
            provinceName = new TextBox();
            increaseTL = new Button();
            decreaseTL = new Button();
            increaseEL = new Button();
            decreaseEL = new Button();
            technologicalLevelLabel = new Label();
            extensionLevelLabel = new Label();
            simpleResourcePBox = new PictureBox();
            militaryManagementBttn = new Button();
            resourcesManagerBttn = new Button();
            date = new Label();
            saveChoice = new Button();
            playerCountry = new Label();
            cash = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            mapmode = new Button();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).BeginInit();
            splitterVertical.Panel1.SuspendLayout();
            splitterVertical.Panel2.SuspendLayout();
            splitterVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)educationEffortTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleResourcePBox).BeginInit();
            SuspendLayout();
            // 
            // splitterVertical
            // 
            splitterVertical.Dock = DockStyle.Fill;
            splitterVertical.FixedPanel = FixedPanel.Panel2;
            splitterVertical.IsSplitterFixed = true;
            splitterVertical.Location = new Point(0, 0);
            splitterVertical.Name = "splitterVertical";
            // 
            // splitterVertical.Panel1
            // 
            splitterVertical.Panel1.Controls.Add(mapmode);
            splitterVertical.Panel1.Controls.Add(mapBox);
            // 
            // splitterVertical.Panel2
            // 
            splitterVertical.Panel2.AutoScroll = true;
            splitterVertical.Panel2.Controls.Add(diplomacyMenuBttn);
            splitterVertical.Panel2.Controls.Add(plane5);
            splitterVertical.Panel2.Controls.Add(plane4);
            splitterVertical.Panel2.Controls.Add(plane3);
            splitterVertical.Panel2.Controls.Add(plane2);
            splitterVertical.Panel2.Controls.Add(plane1);
            splitterVertical.Panel2.Controls.Add(buildMilFactoryBttn);
            splitterVertical.Panel2.Controls.Add(educationLevelLabel);
            splitterVertical.Panel2.Controls.Add(educationEffortLabel);
            splitterVertical.Panel2.Controls.Add(educationEffortTrack);
            splitterVertical.Panel2.Controls.Add(educationLevelBar);
            splitterVertical.Panel2.Controls.Add(militaryResourceTBox);
            splitterVertical.Panel2.Controls.Add(increaseTL_MF);
            splitterVertical.Panel2.Controls.Add(decreaseTL_MF);
            splitterVertical.Panel2.Controls.Add(increaseEL_MF);
            splitterVertical.Panel2.Controls.Add(decreaseEL_MF);
            splitterVertical.Panel2.Controls.Add(technologicalLevelLabel_MF);
            splitterVertical.Panel2.Controls.Add(extensionLevelLabel_MF);
            splitterVertical.Panel2.Controls.Add(provinceName);
            splitterVertical.Panel2.Controls.Add(increaseTL);
            splitterVertical.Panel2.Controls.Add(decreaseTL);
            splitterVertical.Panel2.Controls.Add(increaseEL);
            splitterVertical.Panel2.Controls.Add(decreaseEL);
            splitterVertical.Panel2.Controls.Add(technologicalLevelLabel);
            splitterVertical.Panel2.Controls.Add(extensionLevelLabel);
            splitterVertical.Panel2.Controls.Add(simpleResourcePBox);
            splitterVertical.Panel2.Controls.Add(militaryManagementBttn);
            splitterVertical.Panel2.Controls.Add(resourcesManagerBttn);
            splitterVertical.Panel2.Controls.Add(date);
            splitterVertical.Panel2.Controls.Add(saveChoice);
            splitterVertical.Panel2.Controls.Add(playerCountry);
            splitterVertical.Panel2.Controls.Add(cash);
            splitterVertical.Panel2.Paint += splitterVertical_Panel2_Paint;
            splitterVertical.Size = new Size(1264, 801);
            splitterVertical.SplitterDistance = 900;
            splitterVertical.TabIndex = 0;
            splitterVertical.SplitterMoved += splitterVertical_SplitterMoved;
            // 
            // mapBox
            // 
            mapBox.Location = new Point(3, 3);
            mapBox.Name = "mapBox";
            mapBox.Size = new Size(100, 100);
            mapBox.SizeMode = PictureBoxSizeMode.Zoom;
            mapBox.TabIndex = 0;
            mapBox.TabStop = false;
            mapBox.MouseClick += mapBox_MouseClick;
            // 
            // diplomacyMenuBttn
            // 
            diplomacyMenuBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            diplomacyMenuBttn.Location = new Point(3, 287);
            diplomacyMenuBttn.Name = "diplomacyMenuBttn";
            diplomacyMenuBttn.Size = new Size(341, 47);
            diplomacyMenuBttn.TabIndex = 34;
            diplomacyMenuBttn.Text = "Diplomacy";
            diplomacyMenuBttn.UseVisualStyleBackColor = true;
            diplomacyMenuBttn.Click += diplomacyMenuBttn_Click;
            // 
            // plane5
            // 
            plane5.Location = new Point(106, 687);
            plane5.Name = "plane5";
            plane5.Size = new Size(97, 46);
            plane5.TabIndex = 33;
            plane5.Text = "button1";
            plane5.UseVisualStyleBackColor = true;
            plane5.Click += plane5_Click;
            // 
            // plane4
            // 
            plane4.Location = new Point(3, 687);
            plane4.Name = "plane4";
            plane4.Size = new Size(97, 46);
            plane4.TabIndex = 32;
            plane4.Text = "button1";
            plane4.UseVisualStyleBackColor = true;
            plane4.Click += plane4_Click;
            // 
            // plane3
            // 
            plane3.Location = new Point(209, 635);
            plane3.Name = "plane3";
            plane3.Size = new Size(97, 46);
            plane3.TabIndex = 31;
            plane3.Text = "button1";
            plane3.UseVisualStyleBackColor = true;
            plane3.Click += plane3_Click;
            // 
            // plane2
            // 
            plane2.Location = new Point(106, 635);
            plane2.Name = "plane2";
            plane2.Size = new Size(97, 46);
            plane2.TabIndex = 30;
            plane2.Text = "button1";
            plane2.UseVisualStyleBackColor = true;
            plane2.Click += plane2_Click;
            // 
            // plane1
            // 
            plane1.Location = new Point(3, 635);
            plane1.Name = "plane1";
            plane1.Size = new Size(97, 46);
            plane1.TabIndex = 29;
            plane1.Text = "button1";
            plane1.UseVisualStyleBackColor = true;
            plane1.Click += plane1_Click;
            // 
            // buildMilFactoryBttn
            // 
            buildMilFactoryBttn.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buildMilFactoryBttn.Location = new Point(3, 563);
            buildMilFactoryBttn.Name = "buildMilFactoryBttn";
            buildMilFactoryBttn.Size = new Size(341, 66);
            buildMilFactoryBttn.TabIndex = 28;
            buildMilFactoryBttn.Text = "BUILD MILITARY FACTORY";
            buildMilFactoryBttn.UseVisualStyleBackColor = true;
            buildMilFactoryBttn.Visible = false;
            buildMilFactoryBttn.Click += buildMilFactoryBttn_Click;
            // 
            // educationLevelLabel
            // 
            educationLevelLabel.AutoSize = true;
            educationLevelLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            educationLevelLabel.Location = new Point(244, 416);
            educationLevelLabel.Name = "educationLevelLabel";
            educationLevelLabel.Size = new Size(53, 21);
            educationLevelLabel.TabIndex = 27;
            educationLevelLabel.Text = "label1";
            // 
            // educationEffortLabel
            // 
            educationEffortLabel.AutoSize = true;
            educationEffortLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            educationEffortLabel.Location = new Point(244, 356);
            educationEffortLabel.Name = "educationEffortLabel";
            educationEffortLabel.Size = new Size(53, 21);
            educationEffortLabel.TabIndex = 26;
            educationEffortLabel.Text = "label1";
            // 
            // educationEffortTrack
            // 
            educationEffortTrack.LargeChange = 1;
            educationEffortTrack.Location = new Point(3, 356);
            educationEffortTrack.Maximum = 100;
            educationEffortTrack.Minimum = 1;
            educationEffortTrack.Name = "educationEffortTrack";
            educationEffortTrack.Size = new Size(235, 45);
            educationEffortTrack.TabIndex = 25;
            educationEffortTrack.Value = 1;
            educationEffortTrack.Scroll += educationEffortTrack_Scroll;
            // 
            // educationLevelBar
            // 
            educationLevelBar.Location = new Point(3, 416);
            educationLevelBar.Name = "educationLevelBar";
            educationLevelBar.Size = new Size(235, 23);
            educationLevelBar.Step = 100;
            educationLevelBar.TabIndex = 24;
            // 
            // militaryResourceTBox
            // 
            militaryResourceTBox.Font = new Font("Times New Roman", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            militaryResourceTBox.Location = new Point(3, 563);
            militaryResourceTBox.Multiline = true;
            militaryResourceTBox.Name = "militaryResourceTBox";
            militaryResourceTBox.Size = new Size(64, 64);
            militaryResourceTBox.TabIndex = 23;
            militaryResourceTBox.Click += militaryResourceTBox_Click;
            // 
            // increaseTL_MF
            // 
            increaseTL_MF.Location = new Point(249, 606);
            increaseTL_MF.Name = "increaseTL_MF";
            increaseTL_MF.Size = new Size(95, 23);
            increaseTL_MF.TabIndex = 22;
            increaseTL_MF.Text = "Increase";
            increaseTL_MF.UseVisualStyleBackColor = true;
            increaseTL_MF.Click += increaseTL_MF_Click;
            // 
            // decreaseTL_MF
            // 
            decreaseTL_MF.Location = new Point(143, 606);
            decreaseTL_MF.Name = "decreaseTL_MF";
            decreaseTL_MF.Size = new Size(95, 23);
            decreaseTL_MF.TabIndex = 21;
            decreaseTL_MF.Text = "Decrease";
            decreaseTL_MF.UseVisualStyleBackColor = true;
            decreaseTL_MF.Click += decreaseTL_MF_Click;
            // 
            // increaseEL_MF
            // 
            increaseEL_MF.Location = new Point(249, 565);
            increaseEL_MF.Name = "increaseEL_MF";
            increaseEL_MF.Size = new Size(95, 23);
            increaseEL_MF.TabIndex = 20;
            increaseEL_MF.Text = "Increase";
            increaseEL_MF.UseVisualStyleBackColor = true;
            increaseEL_MF.Click += increaseEL_MF_Click;
            // 
            // decreaseEL_MF
            // 
            decreaseEL_MF.Location = new Point(143, 565);
            decreaseEL_MF.Name = "decreaseEL_MF";
            decreaseEL_MF.Size = new Size(95, 23);
            decreaseEL_MF.TabIndex = 19;
            decreaseEL_MF.Text = "Decrease";
            decreaseEL_MF.UseVisualStyleBackColor = true;
            decreaseEL_MF.Click += decreaseEL_MF_Click;
            // 
            // technologicalLevelLabel_MF
            // 
            technologicalLevelLabel_MF.AutoSize = true;
            technologicalLevelLabel_MF.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            technologicalLevelLabel_MF.Location = new Point(76, 604);
            technologicalLevelLabel_MF.Name = "technologicalLevelLabel_MF";
            technologicalLevelLabel_MF.Size = new Size(61, 23);
            technologicalLevelLabel_MF.TabIndex = 18;
            technologicalLevelLabel_MF.Text = "label1";
            // 
            // extensionLevelLabel_MF
            // 
            extensionLevelLabel_MF.AutoSize = true;
            extensionLevelLabel_MF.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            extensionLevelLabel_MF.Location = new Point(76, 563);
            extensionLevelLabel_MF.Name = "extensionLevelLabel_MF";
            extensionLevelLabel_MF.Size = new Size(61, 23);
            extensionLevelLabel_MF.TabIndex = 17;
            extensionLevelLabel_MF.Text = "label1";
            // 
            // provinceName
            // 
            provinceName.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            provinceName.Location = new Point(3, 235);
            provinceName.Multiline = true;
            provinceName.Name = "provinceName";
            provinceName.ReadOnly = true;
            provinceName.Size = new Size(341, 46);
            provinceName.TabIndex = 15;
            // 
            // increaseTL
            // 
            increaseTL.Location = new Point(249, 509);
            increaseTL.Name = "increaseTL";
            increaseTL.Size = new Size(95, 23);
            increaseTL.TabIndex = 14;
            increaseTL.Text = "Increase";
            increaseTL.UseVisualStyleBackColor = true;
            increaseTL.Click += increaseTL_Click;
            // 
            // decreaseTL
            // 
            decreaseTL.Location = new Point(143, 509);
            decreaseTL.Name = "decreaseTL";
            decreaseTL.Size = new Size(95, 23);
            decreaseTL.TabIndex = 13;
            decreaseTL.Text = "Decrease";
            decreaseTL.UseVisualStyleBackColor = true;
            decreaseTL.Click += decreaseTL_Click;
            // 
            // increaseEL
            // 
            increaseEL.Location = new Point(249, 468);
            increaseEL.Name = "increaseEL";
            increaseEL.Size = new Size(95, 23);
            increaseEL.TabIndex = 12;
            increaseEL.Text = "Increase";
            increaseEL.UseVisualStyleBackColor = true;
            increaseEL.Click += increaseEL_Click;
            // 
            // decreaseEL
            // 
            decreaseEL.Location = new Point(143, 468);
            decreaseEL.Name = "decreaseEL";
            decreaseEL.Size = new Size(95, 23);
            decreaseEL.TabIndex = 11;
            decreaseEL.Text = "Decrease";
            decreaseEL.UseVisualStyleBackColor = true;
            decreaseEL.Click += decreaseEL_Click;
            // 
            // technologicalLevelLabel
            // 
            technologicalLevelLabel.AutoSize = true;
            technologicalLevelLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            technologicalLevelLabel.Location = new Point(76, 507);
            technologicalLevelLabel.Name = "technologicalLevelLabel";
            technologicalLevelLabel.Size = new Size(61, 23);
            technologicalLevelLabel.TabIndex = 10;
            technologicalLevelLabel.Text = "label1";
            // 
            // extensionLevelLabel
            // 
            extensionLevelLabel.AutoSize = true;
            extensionLevelLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            extensionLevelLabel.Location = new Point(76, 466);
            extensionLevelLabel.Name = "extensionLevelLabel";
            extensionLevelLabel.Size = new Size(61, 23);
            extensionLevelLabel.TabIndex = 9;
            extensionLevelLabel.Text = "label1";
            // 
            // simpleResourcePBox
            // 
            simpleResourcePBox.Location = new Point(3, 466);
            simpleResourcePBox.Name = "simpleResourcePBox";
            simpleResourcePBox.Size = new Size(64, 64);
            simpleResourcePBox.SizeMode = PictureBoxSizeMode.StretchImage;
            simpleResourcePBox.TabIndex = 8;
            simpleResourcePBox.TabStop = false;
            // 
            // militaryManagementBttn
            // 
            militaryManagementBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            militaryManagementBttn.Location = new Point(3, 182);
            militaryManagementBttn.Name = "militaryManagementBttn";
            militaryManagementBttn.Size = new Size(341, 47);
            militaryManagementBttn.TabIndex = 7;
            militaryManagementBttn.Text = "Military management";
            militaryManagementBttn.UseVisualStyleBackColor = true;
            militaryManagementBttn.Click += militaryManagement_Click;
            // 
            // resourcesManagerBttn
            // 
            resourcesManagerBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            resourcesManagerBttn.Location = new Point(3, 129);
            resourcesManagerBttn.Name = "resourcesManagerBttn";
            resourcesManagerBttn.Size = new Size(341, 47);
            resourcesManagerBttn.TabIndex = 6;
            resourcesManagerBttn.Text = "Resource management";
            resourcesManagerBttn.UseVisualStyleBackColor = true;
            resourcesManagerBttn.Click += resourcesManagerBttn_Click;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            date.Location = new Point(3, 84);
            date.Name = "date";
            date.Size = new Size(53, 21);
            date.TabIndex = 5;
            date.Text = "label1";
            // 
            // saveChoice
            // 
            saveChoice.AutoSize = true;
            saveChoice.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveChoice.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            saveChoice.Location = new Point(7, 56);
            saveChoice.Name = "saveChoice";
            saveChoice.Size = new Size(174, 33);
            saveChoice.TabIndex = 4;
            saveChoice.Text = "I want to play as ...";
            saveChoice.UseVisualStyleBackColor = true;
            saveChoice.Click += saveChoice_Click;
            // 
            // playerCountry
            // 
            playerCountry.AutoSize = true;
            playerCountry.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            playerCountry.Location = new Point(7, 9);
            playerCountry.Name = "playerCountry";
            playerCountry.Size = new Size(186, 31);
            playerCountry.TabIndex = 2;
            playerCountry.Text = "playerCountry";
            // 
            // cash
            // 
            cash.AutoSize = true;
            cash.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cash.Location = new Point(3, 56);
            cash.Name = "cash";
            cash.Size = new Size(53, 21);
            cash.TabIndex = 1;
            cash.Text = "label1";
            // 
            // mapmode
            // 
            mapmode.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mapmode.Location = new Point(3, 3);
            mapmode.Name = "mapmode";
            mapmode.Size = new Size(40, 40);
            mapmode.TabIndex = 1;
            mapmode.Text = "1";
            mapmode.UseVisualStyleBackColor = true;
            mapmode.Click += mapmode_Click;
            // 
            // PaxApocalypticaGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 801);
            Controls.Add(splitterVertical);
            Name = "PaxApocalypticaGame";
            Text = "PaxApocalyticaGame";
            FormClosing += PaxApocalyticaGame_FormClosing;
            splitterVertical.Panel1.ResumeLayout(false);
            splitterVertical.Panel2.ResumeLayout(false);
            splitterVertical.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).EndInit();
            splitterVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)educationEffortTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleResourcePBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitterVertical;
        private PictureBox mapBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label playerCountry;
        private Button saveChoice;
        private Label date;
        private Button resourcesManagerBttn;
        private Button militaryManagementBttn;
        public Label cash;
        private PictureBox simpleResourcePBox;
        private Button increaseTL;
        private Button decreaseTL;
        private Button increaseEL;
        private Button decreaseEL;
        private Label technologicalLevelLabel;
        private Label extensionLevelLabel;
        private TextBox provinceName;
        private Label educationEffortLabel;
        private TrackBar educationEffortTrack;
        private ProgressBar educationLevelBar;
        private TextBox militaryResourceTBox;
        private Button increaseTL_MF;
        private Button decreaseTL_MF;
        private Button increaseEL_MF;
        private Button decreaseEL_MF;
        private Label technologicalLevelLabel_MF;
        private Label extensionLevelLabel_MF;
        private Label educationLevelLabel;
        private Button buildMilFactoryBttn;
        public Button plane5;
        public Button plane4;
        public Button plane3;
        public Button plane2;
        public Button plane1;
        private Button diplomacyMenuBttn;
        private Button mapmode;
    }
}