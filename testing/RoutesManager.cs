using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web.UI;

namespace testing
{
    public partial class RoutesManager : Form
    {
        public RoutesManager()
        {
            InitializeComponent();
            FilltrainID();
            Populate();
            changeStatusonRouteDate();
            dateChanged = false;
            
        }
        

        private void Populate()
        {
            
            
                //open connection
                SqlConnection conn = new DatabaseConnection().getConnection();
                conn.Open();
                //prepare query
                string query = "SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id";
                //prepare command
                SqlCommand cmd = new SqlCommand(query, conn);
                //create adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //create a datatable
                DataSet dataSet = new DataSet();
                //fill the datatable
                da.Fill(dataSet, "Reservation");
                //set the datasource of the datagridview
                guna2DataGridView1.DataSource = dataSet.Tables["Reservation"];
                //close connection
                conn.Close();
                changeStatusonRouteDate();


            
        }
        private void FilltrainID()
        {
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //Check for The if trains that are not occupied on that date

            //prepare query
            string query = "SELECT id FROM Train";
            
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create reader
            SqlDataReader reader = cmd.ExecuteReader();
            //create Data table
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(reader);
            TrainIDcombo.ValueMember = "id";
            TrainIDcombo.DataSource=dt;
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
            //RoutesManager rm = new RoutesManager();
            //rm.Show();
            this.Close();

        }

        private void RoutesMGRPic_Click(object sender, EventArgs e)
        {
            //open routes manager form
            //RoutesManager rm = new RoutesManager();
            //rm.Show();
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
            CancellationManager cm = new CancellationManager();
            cm.Show();
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

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            newDatetime= guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string oldDatetime;
        private string newDatetime;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //fill the fields by clicking on the datagridview
            //check if the date is changed
            

            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                TrainIDcombo.Text = row.Cells["Train ID"].Value.ToString();
                sourcecombo.Text = row.Cells["Source"].Value.ToString();
                destinationCombo.Text = row.Cells["Destination"].Value.ToString();
                guna2DateTimePicker1.Text = row.Cells["Date"].Value.ToString();
                CostTXT.Text = row.Cells["Cost"].Value.ToString();
                oldDatetime = row.Cells["Date"].Value.ToString();
                key = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            }
           oldDatetime= guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateChanged = true;

        }

       

        private void addRoueBTN_Click(object sender, EventArgs e)
        {
            if( TrainIDcombo==null || sourcecombo==null || destinationCombo==null || guna2DateTimePicker1==null || CostTXT==null)
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            Populate();
            FilltrainID();
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            string source=sourcecombo.Text;
            string destination=destinationCombo.Text;
            string date = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string a = CostTXT.Text;
            int cost;

            
            int trainid = int.Parse(TrainIDcombo.SelectedValue.ToString());

            

            if(source=="" || destination=="" || date=="" || a=="")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            else if(source==destination)
            {
                MessageBox.Show("Source and Destination cannot be same");
                return;
            }
           //check if the train is even available on that date

            
            if(!Int32.TryParse(a, out cost))
            {
                MessageBox.Show("Please enter a valid cost");
                
            }
            if(cost<0)
            {
                MessageBox.Show("Please enter a valid cost");
                cost = 0;
                CostTXT.Text = "0";
                CostTXT.Focus();
                return;
            }
            //check if the train is even available on that date
            string query = "SELECT * FROM Route WHERE trainid = "+trainid+" AND date = '"+date+"';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                MessageBox.Show("Train is already occupied on that date");
                return;
            }
            reader.Close();
            conn.Close();
            //open connection
            conn.Open();
             query = "INSERT INTO Route (trainid,source,destination,date,cost) VALUES ("+trainid+",'"+source+"','"+destination+"','"+date+"',"+cost+");";
            //prepare command
             cmd = new SqlCommand(query, conn);
            //execute command
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();
            Populate();
            FilltrainID();
            MessageBox.Show("Route Added Successfully");
            changeStatusonRouteDate();








        }

       public void changeStatusonRouteDate()
        {
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            //change status of train to unavailable if date is equal to  current date
            string query = "UPDATE Train SET Status='Unavailable' WHERE id IN (SELECT trainid FROM Route WHERE date = '"+DateTime.Now.ToString("yyyy-MM-dd")+"');";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();
            //change status to available if date is not equal to current date
            conn.Open();
            query = "UPDATE Train SET Status='Available' WHERE id NOT IN (SELECT trainid FROM Route WHERE date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "');";
            //prepare command
            cmd = new SqlCommand(query, conn);
            //execute command
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();

          






        }

        private void guna2DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateChanged = false;
            
        }

        int key = 0;
        private bool dateChanged = false;
        private void UpdateRouteBtn_Click(object sender, EventArgs e)
        {
            //update route
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            
            string source = sourcecombo.Text;
            string destination = destinationCombo.Text;
            
            newDatetime = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string a = CostTXT.Text;
            int cost;
            int trainid = int.Parse(TrainIDcombo.SelectedValue.ToString());
            if (source == "" || destination == "" || newDatetime == "" || a == "")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            else if (source == destination)
            {
                MessageBox.Show("Source and Destination cannot be same");
                return;
            }
            if (!Int32.TryParse(a, out cost))
            {
                MessageBox.Show("Please enter a valid cost");
                return;

            }
            if (cost < 0)
            {
                MessageBox.Show("Please enter a valid cost");
                cost = 0;
                CostTXT.Text = "0";
                CostTXT.Focus();
                return;
            }
            //check if the train is even available on that date and the date is not the date that is current the date
            //check if the date is changed while updating
            string query;
            SqlCommand cmd;
            if (oldDatetime!=newDatetime)
            {
                 query = "SELECT * FROM Route WHERE trainid = " + trainid + " AND date = '" + newDatetime + "';";
                //only if the date is changed

                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Train is already occupied on that date");
                    return;
                }
                reader.Close();
                conn.Close();
            }
            //open connection
            conn.Close();
            conn.Open();
             query = "UPDATE Route SET trainid = "+trainid+",source = '"+source+"',destination = '"+destination+"',date = '"+newDatetime+"',cost = "+cost+" WHERE id = "+key+";";
            //prepare command
            cmd = new SqlCommand(query, conn);
            //execute command
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();
            Populate();
            FilltrainID();
            MessageBox.Show("Route Updated Successfully");
            changeStatusonRouteDate();
            dateChanged = false;
            oldDatetime = "0";
            newDatetime = "1";

        
        }

        private void DeleteRouteBTN_Click(object sender, EventArgs e)
        {
            //delete the route
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
            string query = "DELETE FROM Route WHERE id = "+key+";";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command

            int i=cmd.ExecuteNonQuery();
            if(i==0)
            {
                MessageBox.Show("Please select a route to delete");
                return;
            }
            //close connection
            conn.Close();
            Populate();
            FilltrainID();
            MessageBox.Show("Route Deleted Successfully");
            changeStatusonRouteDate();

        }

        private void TicketsMGRPic_Click(object sender, EventArgs e)
        {
            //open tickets manager form
            TicketsManager tm = new TicketsManager();
            tm.Show();
            this.Close();

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void sourcecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
