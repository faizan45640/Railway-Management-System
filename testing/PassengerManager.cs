using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace testing
{
    public partial class PassengerManager : Form
    {
        public PassengerManager()
        {
            InitializeComponent();
            Populate();
        }
        private void PassengerManager_Load(object sender, EventArgs e)
        {
        }
        private void Populate()
        {
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "SELECT id as ID, username AS Username , email AS Email , password AS Password , address AS Address , phone AS Phone , gender AS Gender FROM Passenger";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create a datatable
            DataSet dataSet = new DataSet();
            //fill the datatable
           da.Fill(dataSet, "Passenger");
            //set the datasource of the datagridview
            guna2DataGridView1.DataSource = dataSet.Tables["Passenger"];
            //close connection
            conn.Close();


        }

        private void adminMainform_Load(object sender, EventArgs e)
        {

        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //open trains manager form
            TrainsManager tm = new TrainsManager();
            tm.Show();
            this.Close();

        }

        private void TrainsMgrBtn_Click(object sender, EventArgs e)
        {
            //  open TrainsManager form
            TrainsManager tm = new TrainsManager();
            tm.Show();
            this.Close();

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoutesMGRBtn_Click(object sender, EventArgs e)
        {
            //open routes manager form
            RoutesManager rm = new RoutesManager();
            rm.Show();
            this.Close();

        }

        private void RoutesMGRPic_Click(object sender, EventArgs e)
        {
            //open routes manager form
            RoutesManager rm = new RoutesManager();
            rm.Show();
            this.Close();

        }

        private void TicketsMGRBtn_Click(object sender, EventArgs e)
        {
            //open tickets manager form
            TicketsManager tm = new TicketsManager();
            tm.Show();
            this.Close();

        }

        private void CancellationMGRBtn_Click(object sender, EventArgs e)
        {
            //open cancellation manager form
            //CancellationManager cm = new CancellationManager();
            //cm.Show();
            this.Close();

        }

        private void CancellationMGRPic_Click(object sender, EventArgs e)
        {
            //open cancellation manager form
            //CancellationManager cm = new CancellationManager();
            //cm.Show();
            this.Close();

        }

        private void PassengersMGRBtn_Click(object sender, EventArgs e)
        {
            //open passengers manager form
            //PassengersManager pm = new PassengersManager();

            //pm.Show();
            this.Close();

        }

        private void PassengerMGRpic_Click(object sender, EventArgs e)
        {
            //open passengers manager form
            //PassengersManager pm = new PassengersManager();
            //pm.Show();
            this.Close();

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            //OPEN login form
            userLogin us = new userLogin();
            this.Close();
            us.Show();
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            //open login form
            userLogin us = new userLogin();
            this.Close();
            us.Show();
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PassengerNaeTX.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PassengerMailTXT.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PassengerPasswordTXT.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            PassengerAddressTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            PassengerPhoneTXT.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            if (guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Male")
            {
                MalerdioBTN.Checked = true;
            }
            else
            {
                FemaleRDIOBTN.Checked= true;

            }
            if (PassengerNaeTX.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void addPassengerBTN_Click(object sender, EventArgs e)
        {

            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            
            //prepare query
            string name = PassengerNaeTX.Text;
            string email = PassengerMailTXT.Text;
            string password = PassengerPasswordTXT.Text;
            string address = PassengerAddressTxt.Text;
            string phone = PassengerPhoneTXT.Text;
            string gender;
            if(MalerdioBTN.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            //prepare query
            if(name == "" || email == "" || password == "" || address == "" || phone == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            conn.Close();
            //check for existing email
            conn.Open();
            string check = "SELECT * FROM Passenger WHERE email = '" + email + "'";
            SqlCommand checkcmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkcmd.ExecuteReader();
            if(reader.Read())
            {
                MessageBox.Show("Email already exists");
                
                return;
            }
            conn.Close();




            conn.Open();
            string query="INSERT INTO Passenger VALUES('"+name+"','"+email+"','"+password+"','"+address+"','"+phone+ "','"+gender+"')";

            //execute
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();
            //populate
            //clear fields
            PassengerNaeTX.Clear();
            PassengerMailTXT.Clear();
            PassengerPasswordTXT.Clear();
            PassengerAddressTxt.Clear();
            PassengerPhoneTXT.Clear();



            Populate();
        }

        private void UpdatePassengerBtn_Click(object sender, EventArgs e)
        {
            //update passenger
            if (PassengerNaeTX.Text == "" || PassengerMailTXT.Text == "" || PassengerPasswordTXT.Text == "" || PassengerAddressTxt.Text == "" || PassengerPhoneTXT.Text == "" || (MalerdioBTN.Checked == false && FemaleRDIOBTN.Checked == false))
            {
                MessageBox.Show("Please select a passenger to update");
                return;

            }
            if (key == 0)
            {
                MessageBox.Show("Select a passenger to update");
                return;
            }
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string name = PassengerNaeTX.Text;
            string email = PassengerMailTXT.Text;
            string password = PassengerPasswordTXT.Text;
            string address = PassengerAddressTxt.Text;
            string phone = PassengerPhoneTXT.Text;
            string gender;
            if (MalerdioBTN.Checked)
            {
                gender = "Male";
                
            }
            else
            {
                gender = "Female";
            }
            //chec for existing email
            string check = "SELECT * FROM Passenger WHERE email = '" + email + "' AND id <> " + key;
            SqlCommand checkcmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkcmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Email already exists");
                //clear fields
                PassengerNaeTX.Clear();
                PassengerMailTXT.Clear();
                PassengerPasswordTXT.Clear();
                PassengerAddressTxt.Clear();
                PassengerPhoneTXT.Clear();
                conn.Close();

                return;
            }
            conn.Close();
            conn.Open();
            //prepare query
            string query = "UPDATE Passenger SET username = '" + name + "', email = '" + email + "', password = '" + password + "', address = '" + address + "', phone = '" + phone + "' , gender='"+gender+"' WHERE id = " + key;
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Passenger Updated");
            }
            else
            {
                MessageBox.Show("Error Updating Passenger");
            }
            conn.Close();
            Populate();

        }

        private void DeletePassengerBTN_Click(object sender, EventArgs e)
        {
            //delete passenger
            if(PassengerNaeTX.Text=="" || PassengerMailTXT.Text == "" || PassengerPasswordTXT.Text == "" || PassengerAddressTxt.Text == "" || PassengerPhoneTXT.Text == "" || (MalerdioBTN.Checked == false && FemaleRDIOBTN.Checked == false))
            {
                MessageBox.Show("Please Fill All Fields");
                return;
                
            }
            if(key == 0)
            {
                MessageBox.Show("Select a passenger to delete");
                return;
            }

            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "DELETE FROM Passenger WHERE id = " + key;
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            int i=cmd.ExecuteNonQuery();
            if(i != 0)
            {
                MessageBox.Show("Passenger Deleted");
            }
            else
            {
                MessageBox.Show("Error Deleting Passenger");
            }
            //close connection
            conn.Close();
            //populate
            Populate();


        }

        private void TicketsMGRPic_Click(object sender, EventArgs e)
        {
            //open tickets manager form
                TicketsManager tm = new TicketsManager();
            tm.Show();
            this.Close();

        }
    }
}
