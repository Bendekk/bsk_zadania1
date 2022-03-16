namespace bsk_zadania1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rail rail = new Rail();
            rail.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void macierzowe2a_Click(object sender, EventArgs e)
        {
            Macierzowe2a macierzowe2a = new Macierzowe2a();
            macierzowe2a.Show();
            this.Hide();
        }
    }
}