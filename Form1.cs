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
    }
}