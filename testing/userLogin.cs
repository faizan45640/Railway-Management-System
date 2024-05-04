using System;
using System.Data.SqlClient;
using System.Windows.Forms;


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
            //string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";



            //Establish Connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            string username = UsernameTXT.Text;
            string password = PasswordTXT.Text;
            string query;
            string usertype;
            //will check for adminchecbox
            if (!Loginasadmincheckox.Checked)
            {
                //check for passenger id and password
                query = "select * from Passenger where username = '" + username + "' and password = '" + password + "'";
                usertype = "Passenger";
            }
            else
            {
                //check for admin id and password
                query = "select * from ADMIN where name = '" + username + "' and password = '" + password + "'";
                usertype = "ADMIN";
            }


            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            SqlDataReader reader = cmd.ExecuteReader();
            //check if user exists
            if (reader.Read() && usertype == "ADMIN")
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
