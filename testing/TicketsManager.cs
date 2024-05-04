using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace testing
{
    public partial class TicketsManager : Form
    {
        public TicketsManager()
        {
            InitializeComponent();
            fillpassengercombo();
            fillRoutecombo();
            populate();
        }
        private void fillpassengercombo()
        {
           
                //connect to database
                SqlConnection conn = new DatabaseConnection().getConnection();
                //open connection
                conn.Open();
               

                //prepare query
                string query = "SELECT id FROM Passenger";

                //prepare command
                SqlCommand cmd = new SqlCommand(query, conn);
                //create reader
                SqlDataReader reader = cmd.ExecuteReader();
                //create Data table
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Load(reader);
                passengeridcombo.ValueMember = "id";
                passengeridcombo.DataSource = dt;
                conn.Close();


            
        }
        private void fillRoutecombo()
        {

            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();


            //prepare query
            //select that route thats date is coming
            string query = "SELECT id FROM Route WHERE date >= GETDATE()";

            

            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create reader
            SqlDataReader reader = cmd.ExecuteReader();
            //create Data table
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(reader);
            routeidcombo.ValueMember = "id";
            routeidcombo.DataSource = dt;
            conn.Close();



        }
        private void populate()
        {
            //populate the datagridview with data
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "Select Reservation.id AS [T ID], Passenger.username AS [Passenger Name] , Train.name AS [Train Name] , Route.source AS Source , Route.destination AS Destination , Route.date AS Date , Route.cost AS Cost From Reservation INNER JOIN Passenger ON passengerID=Passenger.id INNER JOIN Route ON routeID=Route.id INNER JOIN Train ON Route.trainid=Train.id ";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create a datatable
            DataSet dataSet = new DataSet();
            //fill the datatable
            da.Fill(dataSet, "Route");
            //set the datasource of the datagridview
            guna2DataGridView1.DataSource = dataSet.Tables["Route"];
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

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void passengeridcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addRoueBTN_Click(object sender, EventArgs e)
        {
            //add reservation
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            //open connection
            conn.Open();
            //prepare query
           string p= passengeridcombo.SelectedValue.ToString();
            string r = routeidcombo.SelectedValue.ToString();
            int passengerid = int.Parse(p);
            int routeid = int.Parse(r);
            //check if the passenger has already book his ticket
            string query1 = "SELECT * FROM Reservation WHERE passengerID = '" + passengerid + "' AND routeID = '" + routeid + "'";
            SqlCommand cmd1 = new SqlCommand(query1, conn); 
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("The Passenger has already booked this route");
                return;
            }
            conn.Close();
            conn.Open();


            string query = "INSERT INTO Reservation (passengerID,routeID) VALUES ('" + passengerid + "','" + routeid + "')";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //execute command
            cmd.ExecuteNonQuery();
            //close connection
            conn.Close();
            MessageBox.Show("Reservation Added Successfully");
            //populate the datagridview
            populate();

        }
    }
}
