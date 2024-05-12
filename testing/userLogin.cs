using Guna.UI2.WinForms;
using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Drawing;



namespace testing
{

    public partial class userLogin : Form
    {
        private bool isPaswordVisible = false;
        public userLogin()
        {
            InitializeComponent();
        }
        public static int loggedInpassengerID=-1;

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
            //string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";


            //Establish Connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            string email = UsernameTXT.Text;
            string password = PasswordTXT.Text;
            string query="";
            string usertype="";
            //will check for adminchecbox
            if (Loginasadmincheckox.Checked)
            {
                //check for passenger id and password
                query = "select * from ADMIN where email = '" + email + "' and password = '" + password + "'";
                usertype = "ADMIN";
            }
            else if(Loginasadmincheckox.Checked==false)
            {
                //check for admin id and password
                
                
                query = "select * from Passenger where email = '" + email + "' and password = '" + password + "'";
                usertype = "Passenger";
                

            }

           
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            SqlDataReader reader = cmd.ExecuteReader();
            //check if user exists
            if (usertype == "ADMIN")
            {
                if (reader.Read())
                {
                    //close connection
                    conn.Close();
                    //open new form
                    adminMainform mf = new adminMainform();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Email or password");
                    guna2CustomGradientPanel2.FillColor = Color.Red;
                    guna2CustomGradientPanel3.FillColor = Color.Red;
                    UsernameTXT.Clear();
                    PasswordTXT.Clear();
                    return;
                }
                
            }
            else if(reader.Read())
            {
                conn.Close();
                passengerMainform mf = new passengerMainform();
                conn.Open();
                query = "Select id from Passenger WHERE email ='" + email + "' ;";
                //prepare command
                SqlCommand cm = new SqlCommand(query, conn);
                //execute query
                loggedinUserdetail.loggedinUserID = (int)cm.ExecuteScalar();
                conn.Close();

                mf.Show();
                this.Hide();




            }

            else
            {
                MessageBox.Show("Invalid Username or Password");
                guna2CustomGradientPanel2.FillColor = Color.Red;
                guna2CustomGradientPanel3.FillColor = Color.Red;
                UsernameTXT.Clear();
                PasswordTXT.Clear();
                UsernameTXT.Focus();
            }

        }


        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsernameTXT_TextChanged(object sender, EventArgs e)
        {

        }

        

    }
}
