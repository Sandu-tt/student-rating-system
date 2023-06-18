using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Form1()
        {
            InitializeComponent();
        }
        Timer tmr;
        
        private void Form1_Load(object sender, EventArgs e)
        {

            con.Open();
            tmr = new Timer();

            //set time interval 3 sec

            tmr.Interval = 3000;

            //starts the timer

            tmr.Start();

            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)

        {

            //after 3 sec stop the timer
            con.Close();
            tmr.Stop();
            this.Hide();
            AdminLogin CPP= new AdminLogin();
            CPP.Show();
            
            
            
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
