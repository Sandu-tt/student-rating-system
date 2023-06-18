using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class rate : Form
    {
        public rate()
        {
            InitializeComponent();
        }
        static string constring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        int starcount = 0;
        int initialstar = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmdz;
                string str;
                str = "Select id,name,branch,position,photo,stars from emptable where id= " + textBox1.Text + "";

                cmdz = new SqlCommand(str, con);
                SqlDataReader reader = cmdz.ExecuteReader();
                reader.Read();
                empid.Text = reader["id"].ToString();
                label2.Text = reader["name"].ToString();
                label3.Text = reader["branch"].ToString();
                label4.Text = reader["position"].ToString();
                label6.Text = reader["stars"].ToString();
                

                con.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmdz);

                DataSet ds = new DataSet();

                da.Fill(ds);


                if (ds.Tables[0].Rows.Count > 0)

                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["photo"]);

                    pictureBox1.Image = new Bitmap(ms);


                    reader.Close();
                    con.Close();

                }
                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("No such student found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            lit1.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            lit1.Visible = true;
            lit2.Visible = true;
            starcount = 2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            //lit2.Visible = false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            lit1.Visible = true;
            lit2.Visible = true;
            lit3.Visible = true;
            starcount = 3;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            //  lit3.Visible = false;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            lit1.Visible = true;
            lit2.Visible = true;
            lit3.Visible = true;
            lit4.Visible = true;
            starcount = 4;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            // lit4.Visible = false;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            lit1.Visible = true;
            lit2.Visible = true;
            lit3.Visible = true;
            lit4.Visible = true;
            lit5.Visible = true;
            starcount = 5;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            // lit5.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            lit1.Visible = true;
            starcount = 1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            // lit1.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void lit2_Click(object sender, EventArgs e)
        {
            lit5.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            starm.Text = starcount.ToString();


            if (lit1.Visible == true)
            {

                DialogResult dr = MessageBox.Show("Do you wish to rate " + label2.Text + " with " + starm.Text + "", "Rate an employee?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    con.Open();

                    // string str2;
                    int x= int.Parse(starm.Text) +int.Parse(label6.Text);

                    SqlCommand cmd2 = new SqlCommand("update emptable set stars="+x+" where id=@id", con);

                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@id", int.Parse(empid.Text));
                    cmd2.Parameters.AddWithValue("@stars", int.Parse(starm.Text));
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Student Rated Successfully", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                starcount = 0;
                con.Close();
                lit1.Visible = false;
                lit2.Visible = false;
                lit3.Visible = false;
                lit4.Visible = false;
                lit5.Visible = false;
            }
            // MessageBox.Show("Minimum rating is one star. Please select at least one star", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);




        }

        private void rate_Load(object sender, EventArgs e)
        {




        }

        private void empid_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lit4_Click(object sender, EventArgs e)
        {

        }

        private void lit5_Click(object sender, EventArgs e)
        {

        }

        private void lit3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Any unsaved data will be discarded. Are you sure you want to quit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);

            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain al = new AdminMain();
            al.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {


            con.Open();
        
            
            SqlCommand cmd2 = new SqlCommand("update rater set rating = rating+@stars where id= " + int.Parse(empid.Text) + "", con);
            cmd2.Parameters.Add(new SqlParameter("@stars", starm));

            cmd2.CommandType = CommandType.Text;
           
            SqlDataReader reader2 = cmd2.ExecuteReader();


           
            con.Close();


        }
    }
}
