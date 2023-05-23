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
            resourcesManagerBttn = new Button();
            date = new Label();
            saveChoice = new Button();
            manpower = new Label();
            playerCountry = new Label();
            cash = new Label();
            provinceName = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).BeginInit();
            splitterVertical.Panel1.SuspendLayout();
            splitterVertical.Panel2.SuspendLayout();
            splitterVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapBox).BeginInit();
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
            splitterVertical.Panel2.Controls.Add(resourcesManagerBttn);
            splitterVertical.Panel2.Controls.Add(date);
            splitterVertical.Panel2.Controls.Add(saveChoice);
            splitterVertical.Panel2.Controls.Add(manpower);
            splitterVertical.Panel2.Controls.Add(playerCountry);
            splitterVertical.Panel2.Controls.Add(cash);
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
            mapBox.Size = new Size(100, 100);
            mapBox.SizeMode = PictureBoxSizeMode.Zoom;
            mapBox.TabIndex = 0;
            mapBox.TabStop = false;
            mapBox.MouseClick += mapBox_MouseClick;
            // 
            // resourcesManagerBttn
            // 
            resourcesManagerBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            resourcesManagerBttn.Location = new Point(7, 123);
            resourcesManagerBttn.Name = "resourcesManagerBttn";
            resourcesManagerBttn.Size = new Size(350, 47);
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
            saveChoice.Location = new Point(7, 51);
            saveChoice.Name = "saveChoice";
            saveChoice.Size = new Size(174, 33);
            saveChoice.TabIndex = 4;
            saveChoice.Text = "I want to play as ...";
            saveChoice.UseVisualStyleBackColor = true;
            saveChoice.Click += saveChoice_Click;
            // 
            // manpower
            // 
            manpower.AutoSize = true;
            manpower.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            manpower.Location = new Point(3, 63);
            manpower.Name = "manpower";
            manpower.Size = new Size(53, 21);
            manpower.TabIndex = 3;
            manpower.Text = "label1";
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
            cash.Location = new Point(3, 42);
            cash.Name = "cash";
            cash.Size = new Size(53, 21);
            cash.TabIndex = 1;
            cash.Text = "label1";
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
            // PaxApocalypticaGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
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
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitterVertical;
        private PictureBox mapBox;
        private Label provinceName;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label playerCountry;
        private Label cash;
        private Label manpower;
        private Button saveChoice;
        private Label date;
        private Button resourcesManagerBttn;
    }
}