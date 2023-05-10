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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            mapBox = new PictureBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitterVertical).BeginInit();
            splitterVertical.Panel1.SuspendLayout();
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
            splitterVertical.Panel1.Controls.Add(button4);
            splitterVertical.Panel1.Controls.Add(button3);
            splitterVertical.Panel1.Controls.Add(button2);
            splitterVertical.Panel1.Controls.Add(button1);
            splitterVertical.Panel1.Controls.Add(mapBox);
            splitterVertical.Size = new Size(1264, 681);
            splitterVertical.SplitterDistance = 900;
            splitterVertical.TabIndex = 0;
            splitterVertical.SplitterMoved += splitterVertical_SplitterMoved;
            // 
            // button3
            // 
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(23, 681);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(0, 658);
            button2.Name = "button2";
            button2.Size = new Size(904, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(904, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // mapBox
            // 
            mapBox.Location = new Point(3, 3);
            mapBox.Name = "mapBox";
            mapBox.Size = new Size(8192, 4096);
            mapBox.SizeMode = PictureBoxSizeMode.Zoom;
            mapBox.TabIndex = 0;
            mapBox.TabStop = false;
            mapBox.Click += map_Click;
            // 
            // button4
            // 
            button4.Location = new Point(881, 0);
            button4.Name = "button4";
            button4.Size = new Size(23, 681);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // PaxApocalyticaGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitterVertical);
            Name = "PaxApocalyticaGame";
            Text = "PaxApocalyticaGame";
            splitterVertical.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitterVertical).EndInit();
            splitterVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitterVertical;
        private PictureBox mapBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}