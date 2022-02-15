namespace Shutdown_Timer
{
    public partial class Form1 : Form
    {
        TimeSpan timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            checkIfEmpty();
            bool istStartable = true;
            try
            {
                timeLeft = new TimeSpan(Convert.ToInt32(txtHour.Text), Convert.ToInt32(txtMin.Text), Convert.ToInt32(txtSec.Text));
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                istStartable = false;
                MessageBox.Show("Please check the timer input!");
            }

            if (istStartable)
            {
                timer.Start();
                lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkIfEmpty()
        {
            if (txtHour.Text.Count() == 0)
            {
                txtHour.Text = "0";
            }
            if (txtMin.Text.Count() == 0)
            {
                txtMin.Text = "0";
            }
            if (txtMin.Text.Count() == 0)
            {
                txtSec.Text = "0";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");

            if (timeLeft.TotalSeconds <= 0)
            {
                timer.Stop();
            }
        }
    }
}