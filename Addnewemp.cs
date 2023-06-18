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
    public partial class Addnewemp : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Addnewemp()
        {
            InitializeComponent();
        }
        string imglocation = "";
        SqlCommand cmd;
        string branch;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain adm = new AdminMain();
            adm.Show();

        }

        private void Addnewemp_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
                try
                {
                    if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter all details", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }




                    DialogResult dr = MessageBox.Show("Do you want to add an image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); ;

                    if (dr == DialogResult.Yes)
                    {

                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {

                            imglocation = dialog.FileName.ToString();
                            pictureBox1.ImageLocation = imglocation;
                        }





                        con.Open();
                        byte[] images = null;
                        FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brs = new BinaryReader(streem);
                        images = brs.ReadBytes((int)streem.Length);

                        SqlCommand cmdz;
                        string strx;






                        branch = comboBox1.SelectedItem.ToString();
                        SqlCommand cmd = new SqlCommand("Insert into emptable values(@id,@name,@branch,@position,@photo,@stars)", con);
                        SqlCommand cmd2 = new SqlCommand("Select id from emptable where id= " + textBox1.Text + "", con);
                        cmd.CommandType = CommandType.Text;
                        cmd2.CommandType = CommandType.Text;


                        cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@branch", branch);
                        cmd.Parameters.AddWithValue("@position", textBox4.Text);
                       // cmd.Parameters.AddWithValue("@stars", int.Parse(stars.Text));
                        cmd.Parameters.Add(new SqlParameter("photo", images));


                        cmd.ExecuteNonQuery();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        stars.Text = "0";
                        textBox4.Text = "";
                    con.Close();

                    }

                    con.Open();
                    Image myImage = pictureBox2.Image;
                    byte[] data;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        myImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        data = ms.ToArray();
                    }
                    branch = comboBox1.SelectedItem.ToString();
                    SqlCommand cmd1 = new SqlCommand("Insert into emptable values(@id,@name,@branch,@position,@photo,@stars)", con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    cmd1.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd1.Parameters.AddWithValue("@branch", branch);
                    cmd1.Parameters.AddWithValue("@position", textBox4.Text);

                    cmd1.Parameters.Add(new SqlParameter("photo", data));
                    cmd1.Parameters.AddWithValue("@stars", int.Parse(stars.Text));


                    cmd1.ExecuteNonQuery();


                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;

                    textBox4.Text = String.Empty;
                    MessageBox.Show("New Student Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                }

                catch 
                {
                    
                    con.Close();
                }
            
            
        
        }
            
        

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();



            if (textBox1.Text == "")
            {
                panel1.Visible = true;
            }
            else
            {
              DialogResult dr= MessageBox.Show("Are you sure you want to delete " + textBox2.Text + "? ","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); ;
                if (dr == DialogResult.Yes)
                {
                    string query = "Delete from emptable where id= '" + textBox1.Text + "';";

                    SqlCommand mycommand2 = new SqlCommand(query, con);
                    SqlDataReader myreader2;

                    myreader2 = mycommand2.ExecuteReader();
                  
                    
                    
                    myreader2.Read();
                    
                    con.Close();
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    pictureBox1.Image.Dispose();
                       
                }
                else
                {
                    con.Close();
                }
            }
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();
                SqlCommand cmdz;
                string str;
                str = "Select id,name,branch,position,photo,stars from emptable where id= " + textBox5.Text + "";

                cmdz = new SqlCommand(str, con);
                SqlDataReader reader = cmdz.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["id"].ToString();
                textBox2.Text = reader["name"].ToString();
               comboBox1.Text = reader["branch"].ToString();
                textBox4.Text = reader["position"].ToString();
                stars.Text = reader["stars"].ToString();
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
                    panel1.Visible = false;
                }
                con.Close();

            }
            catch
            {
                MessageBox.Show("No such Student found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }

        }
            

            
            
        

       
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

       

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Select id from emptable where id= " + int.Parse(textBox1.Text) + "", con);

            cmd2.CommandType = CommandType.Text;

            SqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.HasRows)
            {
                MessageBox.Show("Student ID already taken. Please use another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("New ID added. Please enter more details", "Almost done...", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                con.Close();
            }
            con.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomeScreen al = new WelcomeScreen();
            al.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM emptable"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            
                        }
                    }
                }
            con.Close();

        }
    }
}
