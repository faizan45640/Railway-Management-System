using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace testing
{
    public partial class userLogin : Form
    {
        public userLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void userLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signUpherebutton_Click(object sender, EventArgs e)
        {
            userSignup us = new userSignup();
            this.Hide();
            us.Show();

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            //ADDRESS of sql server and database name
           
            // string connectionString = "\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";
            string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";
            //Establish Connection
            SqlConnection conn = new SqlConnection(connectionString);
            //open connection
            conn.Open();
            //prepare query
            string username = UsernameTXT.Text;
            string password = PasswordTXT.Text;

            string query = "select * from Passenger where username = '" + username+ "' and password = '" +password + "'";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            SqlDataReader reader = cmd.ExecuteReader();
            //check if user exists
            if (reader.Read())
            {

                //close connection
                conn.Close();
                //open new form
                mainform mf = new mainform();
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                UsernameTXT.Clear();
                PasswordTXT.Clear();
                UsernameTXT.Focus();
            }

        }


        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
