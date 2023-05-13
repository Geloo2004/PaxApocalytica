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
            splitterVertical.Panel1.Controls.Add(mapBox);
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
            mapBox.Click += map_Click;
            mapBox.MouseClick += mapBox_MouseClick;
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
    }
}