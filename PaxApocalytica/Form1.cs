namespace PaxApocalytica
{
    public partial class Form1 : Form
    {
        public static string path = null;
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(341, 246);
            this.MaximumSize = new Size(341, 246);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaxApocalypticaGame game = new PaxApocalypticaGame(this);
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            if (path != null && path != "")
            {
                path = folderBrowserDialog1.SelectedPath + "\\";
                button1.Text = "Continue";
            }
            else
            {
                path = null;
                button1.Text = "Start";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}