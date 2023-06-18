using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addnewemp add =new Addnewemp();
            this.Hide();
            add.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rate rt = new rate();
            this.Hide();
            rt.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomeScreen al = new WelcomeScreen();
            al.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Addnewemp add = new Addnewemp();
            this.Hide();
            add.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            rate rt = new rate();
            this.Hide();
            rt.Show();
        }
    }
}
