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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string pw = ("admin");


            if (textBox1.Text == pw)
            {
                this.Hide();
                AdminMain AM = new AdminMain();
                AM.Show();

            }

            else MessageBox.Show("Incorrect Password. Please Check your credentials and try again!","Access Denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        


    


    }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Opacity = 50 ;
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
