using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace testing
{
    public partial class TrainsManager : Form
    {
        public TrainsManager()
        {
            InitializeComponent();
            Populate();
        }
        private void Populate()
        {
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "select id AS ID, name AS Name, capacity as Capacity, Status from Train";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create dataset
            var ds = new DataSet();
            //fill dataset
            da.Fill(ds, "Train");
            //set the source of data grid view
            guna2DataGridView1.DataSource = ds.Tables["Train"];
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
            //TrainsManager tm = new TrainsManager();
            //tm.Show();
            //this.Close();

        }

        private void TrainsMgrBtn_Click(object sender, EventArgs e)
        {
            //open TrainsManager form
            // TrainsManager tm = new TrainsManager();
            // tm.Show();
            //this.Close();

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
            //TicketsManager tm = new TicketsManager();
            //tm.Show();
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
            PassengerManager pm = new PassengerManager();

            pm.Show();
            this.Close();

        }

        private void PassengerMGRpic_Click(object sender, EventArgs e)
        {
            //open passengers manager form
            PassengerManager pm = new PassengerManager();
            pm.Show();
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

        private void UsernameTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void addTrainBTN_Click(object sender, EventArgs e)
        {
            //open connection
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6QJ1R4I;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
            SqlConnection conn = new DatabaseConnection().getConnection();

            //open connection
            conn.Open();
            //prepare query
            string trainName = TrainNameTXT.Text;
            string a = TrainCapacityTXT.Text;
            int trainCapacity;



            if (!Int32.TryParse(TrainCapacityTXT.Text, out trainCapacity))
            {
                MessageBox.Show("Error: Train Capacity cannot be a String");
                TrainCapacityTXT.Focus();
                return;
            }
            else
            {
                if (Int32.Parse(a) < 0)
                {
                    MessageBox.Show("Error: Train Capacity cannot be negative");
                    TrainCapacityTXT.Focus();
                    return;
                }
                trainCapacity = Int32.Parse(a);
            }




            string istrainAvailable;
            if (Availableradiobtn.Checked)
            {
                istrainAvailable = "Available";

            }
            else
            {
                istrainAvailable = "Not Available";
            }
            string query = "insert into Train values('" + trainName + "','" + trainCapacity + "','" + istrainAvailable + "')";
            //prepare command
            if (trainName == "" || a == "")
            {
                MessageBox.Show("Please fill all fields");
                TrainNameTXT.Focus();
                return;
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Train Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed to add Train");
            }
            //close connection
            conn.Close();
            Populate();


        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        int key=0;

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            TrainNameTXT.Text= guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            TrainCapacityTXT.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Available")
            {
                Availableradiobtn.Checked = true;
            }
            else
            {
                NotAvailableRadioBTN.Checked = true;
            }

            if (TrainNameTXT.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            
        }
        private void DeleteTrainBTN_Click(object sender, EventArgs e)
        {
            if(TrainNameTXT.Text=="" || TrainCapacityTXT.Text=="")
            {
                MessageBox.Show("Select a Train to Delete");
                return;
            }

            if(key==0)
            {
                MessageBox.Show("Select a Train to Delete");
                return;
            }
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "delete from Train where id = " + key;
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Train Deleted Successfully");

                TrainNameTXT.Clear();
                TrainCapacityTXT.Clear();
                Availableradiobtn.Checked = false;
                

            }
            else
            {
                MessageBox.Show("Failed to delete Train");
            }

            Populate();
        }

        private void UpdateTrnBtn_Click(object sender, EventArgs e)
        {
            if (TrainNameTXT.Text == "" || TrainCapacityTXT.Text == "")
            {
                MessageBox.Show("Select a Train to Update");
                return;
            }
            if (key==0)
            {
                   MessageBox.Show("Select a Train to Update");
                return;
            }
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string trainName = TrainNameTXT.Text;
            string a = TrainCapacityTXT.Text;
            int trainCapacity;
            if (!Int32.TryParse(TrainCapacityTXT.Text, out trainCapacity))
            {
                MessageBox.Show("Error: Train Capacity cannot be a String");
                TrainCapacityTXT.Focus();
                return;
            }
            else
            {
                if (Int32.Parse(a) < 0)
                {
                    MessageBox.Show("Error: Train Capacity cannot be negative");
                    TrainCapacityTXT.Focus();
                    return;
                }
                trainCapacity = Int32.Parse(a);
            }
            string istrainAvailable;
            if (Availableradiobtn.Checked)
            {
                istrainAvailable = "Available";

            }
            else
            {
                istrainAvailable = "Not Available";
            }
            string query = "update Train set name = '" + trainName + "', capacity = '" + trainCapacity + "', Status = '" + istrainAvailable + "' where id = " + key;
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Train Updated Successfully");
                TrainNameTXT.Clear();
                TrainCapacityTXT.Clear();
                Availableradiobtn.Checked = false;

            }
            else
            {
                MessageBox.Show("Failed to update Train");

            }
            //close connection
            conn.Close();

            Populate();
        }
    }
}
