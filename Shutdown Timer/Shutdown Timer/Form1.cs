using System.Diagnostics;
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
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblTimer.Text = "00:00:00";
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
                PerformAction();
            }
        }
        private void PerformAction()
        {
            if (rbShutdown.Checked)
            {
                Process.Start("shutdown", "/s");
            }else if (rbRestart.Checked)
            {
                Process.Start("shutdown", "/r");
            }else if (rbStandBy.Checked)
            {
                Process.Start("rundll32.exe", "powrprof.dll,SetSuspendState");
            }
        }

        private void Close_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("If you Close the Program, the Timer will stop. Use the \"S \"Button to minimize the Program", "Do you want to Quit?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnUnvisible_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("If you Minimize the Program, you can only end the Program with the Task manager", "Do you want to Minimize?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Visible = false;
            }
        }
    }
}