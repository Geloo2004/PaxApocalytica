namespace PaxApocalytica
{
    partial class Diplomacy_Menu
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
            alliesListBox = new ListBox();
            alliesLabel = new Label();
            rivalsLabel = new Label();
            rivalsListBox = new ListBox();
            friendLabel = new Label();
            friendsListBox = new ListBox();
            warEnemies = new ListBox();
            warsLabel = new Label();
            breakAllianceBttn = new Button();
            offerAllianceBttn = new Button();
            setAsRivalBttn = new Button();
            declareWarBttn = new Button();
            label1 = new Label();
            offerPeace = new Button();
            SuspendLayout();
            // 
            // alliesListBox
            // 
            alliesListBox.FormattingEnabled = true;
            alliesListBox.ItemHeight = 15;
            alliesListBox.Location = new Point(12, 36);
            alliesListBox.Name = "alliesListBox";
            alliesListBox.Size = new Size(186, 319);
            alliesListBox.TabIndex = 0;
            alliesListBox.SelectedIndexChanged += alliesListBox_SelectedIndexChanged;
            // 
            // alliesLabel
            // 
            alliesLabel.AutoSize = true;
            alliesLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            alliesLabel.Location = new Point(12, 9);
            alliesLabel.Name = "alliesLabel";
            alliesLabel.Size = new Size(65, 23);
            alliesLabel.TabIndex = 1;
            alliesLabel.Text = "Allies:";
            // 
            // rivalsLabel
            // 
            rivalsLabel.AutoSize = true;
            rivalsLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            rivalsLabel.Location = new Point(420, 9);
            rivalsLabel.Name = "rivalsLabel";
            rivalsLabel.Size = new Size(69, 23);
            rivalsLabel.TabIndex = 3;
            rivalsLabel.Text = "Rivals:";
            // 
            // rivalsListBox
            // 
            rivalsListBox.FormattingEnabled = true;
            rivalsListBox.ItemHeight = 15;
            rivalsListBox.Location = new Point(420, 36);
            rivalsListBox.Name = "rivalsListBox";
            rivalsListBox.Size = new Size(186, 259);
            rivalsListBox.TabIndex = 2;
            rivalsListBox.SelectedIndexChanged += rivalsListBox_SelectedIndexChanged;
            // 
            // friendLabel
            // 
            friendLabel.AutoSize = true;
            friendLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            friendLabel.Location = new Point(216, 9);
            friendLabel.Name = "friendLabel";
            friendLabel.Size = new Size(183, 23);
            friendLabel.TabIndex = 5;
            friendLabel.Text = "Friends and neutrals:";
            // 
            // friendsListBox
            // 
            friendsListBox.FormattingEnabled = true;
            friendsListBox.ItemHeight = 15;
            friendsListBox.Location = new Point(216, 36);
            friendsListBox.Name = "friendsListBox";
            friendsListBox.Size = new Size(186, 259);
            friendsListBox.TabIndex = 4;
            friendsListBox.SelectedIndexChanged += friendsListBox_SelectedIndexChanged;
            // 
            // warEnemies
            // 
            warEnemies.FormattingEnabled = true;
            warEnemies.ItemHeight = 15;
            warEnemies.Location = new Point(12, 450);
            warEnemies.Name = "warEnemies";
            warEnemies.Size = new Size(186, 154);
            warEnemies.TabIndex = 6;
            warEnemies.SelectedIndexChanged += warEnemies_SelectedIndexChanged;
            // 
            // warsLabel
            // 
            warsLabel.AutoSize = true;
            warsLabel.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            warsLabel.Location = new Point(12, 421);
            warsLabel.Name = "warsLabel";
            warsLabel.Size = new Size(182, 26);
            warsLabel.TabIndex = 7;
            warsLabel.Text = "WAR ENEMIES";
            // 
            // breakAllianceBttn
            // 
            breakAllianceBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            breakAllianceBttn.Location = new Point(12, 361);
            breakAllianceBttn.Name = "breakAllianceBttn";
            breakAllianceBttn.Size = new Size(186, 52);
            breakAllianceBttn.TabIndex = 10;
            breakAllianceBttn.Text = "Break Alliance";
            breakAllianceBttn.UseVisualStyleBackColor = true;
            breakAllianceBttn.Click += breakAllianceBttn_Click;
            // 
            // offerAllianceBttn
            // 
            offerAllianceBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            offerAllianceBttn.Location = new Point(216, 359);
            offerAllianceBttn.Name = "offerAllianceBttn";
            offerAllianceBttn.Size = new Size(186, 52);
            offerAllianceBttn.TabIndex = 11;
            offerAllianceBttn.Text = "Offer Alliance";
            offerAllianceBttn.UseVisualStyleBackColor = true;
            offerAllianceBttn.Click += offerAllianceBttn_Click;
            // 
            // setAsRivalBttn
            // 
            setAsRivalBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            setAsRivalBttn.Location = new Point(216, 301);
            setAsRivalBttn.Name = "setAsRivalBttn";
            setAsRivalBttn.Size = new Size(186, 52);
            setAsRivalBttn.TabIndex = 12;
            setAsRivalBttn.Text = "Declare Rival";
            setAsRivalBttn.UseVisualStyleBackColor = true;
            setAsRivalBttn.Click += setAsRivalBttn_Click;
            // 
            // declareWarBttn
            // 
            declareWarBttn.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            declareWarBttn.Location = new Point(420, 303);
            declareWarBttn.Name = "declareWarBttn";
            declareWarBttn.Size = new Size(186, 52);
            declareWarBttn.TabIndex = 13;
            declareWarBttn.Text = "Declare War";
            declareWarBttn.UseVisualStyleBackColor = true;
            declareWarBttn.Click += declareWarBttn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(521, 452);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "label1";
            // 
            // offerPeace
            // 
            offerPeace.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            offerPeace.Location = new Point(12, 610);
            offerPeace.Name = "offerPeace";
            offerPeace.Size = new Size(186, 38);
            offerPeace.TabIndex = 15;
            offerPeace.Text = "Offer Peace";
            offerPeace.UseVisualStyleBackColor = true;
            offerPeace.Click += offerPeace_Click;
            // 
            // Diplomacy_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(621, 660);
            Controls.Add(offerPeace);
            Controls.Add(label1);
            Controls.Add(declareWarBttn);
            Controls.Add(setAsRivalBttn);
            Controls.Add(offerAllianceBttn);
            Controls.Add(breakAllianceBttn);
            Controls.Add(warsLabel);
            Controls.Add(warEnemies);
            Controls.Add(friendLabel);
            Controls.Add(friendsListBox);
            Controls.Add(rivalsLabel);
            Controls.Add(rivalsListBox);
            Controls.Add(alliesLabel);
            Controls.Add(alliesListBox);
            Name = "Diplomacy_Menu";
            Text = "Diplomacy_Menu";
            Load += Diplomacy_Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox alliesListBox;
        private Label alliesLabel;
        private Label rivalsLabel;
        private ListBox rivalsListBox;
        private Label friendLabel;
        private ListBox friendsListBox;
        private ListBox warEnemies;
        private Label warsLabel;
        private Button breakAllianceBttn;
        private Button offerAllianceBttn;
        private Button setAsRivalBttn;
        private Button declareWarBttn;
        private Label label1;
        private Button offerPeace;
    }
}