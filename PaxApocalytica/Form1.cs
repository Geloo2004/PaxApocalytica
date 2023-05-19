namespace PaxApocalytica
{
    public partial class Form1 : Form
    {
        public static string path = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaxApocalyticaGame game = new PaxApocalyticaGame();
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            path = folderBrowserDialog1.SelectedPath+"\\";
            button1.Text = "Continue";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}