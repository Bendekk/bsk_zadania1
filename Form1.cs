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

        private void macierzowe2b_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void LFSR_Click(object sender, EventArgs e)
        {
            LFSR lfsr = new LFSR();
            lfsr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SzyfrowanieStrumieniowe szyfrowanieStrumieniowe = new SzyfrowanieStrumieniowe();
            szyfrowanieStrumieniowe.Show();
            this.Hide();
        }

        private void DES_Click(object sender, EventArgs e)
        {
            Des des = new Des();
            des.Show();
            this.Hide();
        }
    }
}