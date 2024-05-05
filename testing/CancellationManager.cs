using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace testing
{
    public partial class CancellationManager : Form
    {
        public CancellationManager()
        {
            InitializeComponent();
            FillticketIDcombo();
            populate();
        }
        private void FillticketIDcombo()
        {
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query ticketid date should be greater than today
            //current date time
            DateTime today = DateTime.Now;
            //prepare query
            string query = "select Reservation.id AS id From Reservation INNER JOIN Route ON routeID=Route.id where date >  '" + today + "' AND status='Active'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();


            
            //create Data table
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(rdr);
            ReservationIDManager.ValueMember = "id";
            ReservationIDManager.DataSource = dt;
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

        private void TicketsMGRPic_Click(object sender, EventArgs e)
        {
            //open tickets manager form
            TicketsManager tm = new TicketsManager();
            tm.Show();
            this.Close();

        }

        private void sourcecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteReservationBTN_Click(object sender, EventArgs e)
        {
            populate();
            if(ReservationIDManager.Text == "")
            {
                MessageBox.Show("Please select a reservation to delete");
            }
            else
            {
                //open connection
                SqlConnection conn = new DatabaseConnection().getConnection();
                conn.Open();
                //insert into cancellation table
                string timeDate= DateTime.Now.ToString("yyyy-MM-dd");

                
                string a= ReservationIDManager.Text;
                int b = Convert.ToInt32(a);
                //check if reservation is already cancelled
                string query3 = "select status from Reservation where id='" + b + "'";
                SqlCommand cmd3 = new SqlCommand(query3, conn);
                SqlDataReader rdr = cmd3.ExecuteReader();
                rdr.Read();
                if (rdr["status"].ToString() == "Cancelled")
                {
                    MessageBox.Show("Reservation already cancelled");
                    return;
                }
                conn.Close();
                //set status to cancelled
                conn.Open();    
                string query1 = "update Reservation set status='Cancelled' where id='" + b + "'";
                SqlCommand cmd= new SqlCommand(query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                    

                string query2 = "insert into Cancellation values('" + b + "','" + timeDate + "')";
                SqlCommand sqlCommand = new SqlCommand(query2, conn);
                sqlCommand.ExecuteNonQuery();

                conn.Close();
                
               
               
                MessageBox.Show("Reservation Deleted Successfully");
                
                FillticketIDcombo();
                populate();
            }
        }
        private void populate()
        {
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "select Cancellation.id AS [Canc. ID] , reservationID as [Ticket ID] , passengerID as [Passenger ID] , routeID as [Route ID] , date as [Date] from Cancellation INNER JOIN Reservation ON Reservation.id=reservationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
    }
}
