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
    public partial class userSignup : Form
    {
        public userSignup()
        {
            InitializeComponent();
            
        }

        private void userSignup_Load(object sender, EventArgs e)
        {

        }

        private void signInherebutton_Click(object sender, EventArgs e)
        {
            userLogin us = new userLogin();
            this.Close();
            us.Show();
        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            //connection string

            string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";
            //establish connection
            SqlConnection conn = new SqlConnection(connectionString);
            //open connection
            conn.Open();
            //prepare query
            string gender;
            if (Maleradiobtn.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            string Email = EmailTXT.Text;
            string Phone = PhoneTXT.Text;
            string Username = UsernameTXT.Text;
            string Address = AddressTXT.Text;
            string Password = TXTpassword.Text;
            //check for duplicate email violation
            string query1 = "select * from Passenger where Email = '" + Email + "'";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Email already exists");
                EmailTXT.Focus();
                return;
            }
            reader.Close();

            string query = " SET ANSI_WARNINGS OFF; insert into Passenger values('" + Username + "','" + Email + "' , '"+ Password +"' , '"+ Address+ "' , '"+Phone+"' , '"+gender+ "');  SET ANSI_WARNINGS ON;";
            //prepare command




            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            
            

            if(UsernameTXT.Text == "" || EmailTXT.Text == "" || TXTpassword.Text == "" || AddressTXT.Text == "" || PhoneTXT.Text == "")
            {
                
                MessageBox.Show("Please fill all fields");
            }

            else
            {
                if(PhoneTXT.Text.Length != 11)
                {
                    MessageBox.Show("Phone number must be 11 digits");
                    PhoneTXT.Clear();
                    PhoneTXT.Focus();
                }
                else
                {
                    
                    //execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Registered Successfully");
                    userLogin ul = new userLogin();
                    this.Close();
                    ul.Show();
                    cmd.Dispose();

                }
                
            }
            


        }

        private void Maleradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
