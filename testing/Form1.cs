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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            //ADDRESS of sql server and database name
            string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";
            //Establish Connection
            SqlConnection conn = new SqlConnection(connectionString);
            //open connection
            conn.Open();
            //prepare query
            string query = "select * from ADMIN where name = '" + txtusername.Text + "' and password = '" + txtPasswor.Text + "'";
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
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
