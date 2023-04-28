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
            vScrollBar2 = new VScrollBar();
            hScrollBar2 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            hScrollBar1 = new HScrollBar();
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
            splitterVertical.Panel1.Controls.Add(vScrollBar2);
            splitterVertical.Panel1.Controls.Add(hScrollBar2);
            splitterVertical.Panel1.Controls.Add(vScrollBar1);
            splitterVertical.Panel1.Controls.Add(hScrollBar1);
            splitterVertical.Panel1.Controls.Add(mapBox);
            splitterVertical.Size = new Size(1264, 681);
            splitterVertical.SplitterDistance = 900;
            splitterVertical.TabIndex = 0;
            splitterVertical.SplitterMoved += splitterVertical_SplitterMoved;
            // 
            // vScrollBar2
            // 
            vScrollBar2.Location = new Point(883, 17);
            vScrollBar2.Name = "vScrollBar2";
            vScrollBar2.Size = new Size(17, 644);
            vScrollBar2.TabIndex = 4;
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new Point(0, 661);
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(900, 17);
            hScrollBar2.TabIndex = 3;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(0, 17);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 644);
            vScrollBar1.TabIndex = 2;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(0, 0);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(900, 17);
            hScrollBar1.TabIndex = 1;
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
        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar2;
        private VScrollBar vScrollBar2;
    }
}