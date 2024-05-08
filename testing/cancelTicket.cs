using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace testing
{
    public partial class cancelTicket : Form
    {
        public int userLoggedInid = -1;
        public cancelTicket()
        {
            
            InitializeComponent();
            fillrouteidcombo();
        }

        public cancelTicket(string id)
        {
            InitializeComponent();
            ticketIDcombo.Items.Add(id);
            ticketIDcombo.SelectedIndex = 0;
            
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
            CancellationManager cm = new CancellationManager();
            cm.Show();
            this.Close();

        }

        private void CancellationMGRPic_Click(object sender, EventArgs e)
        {
            //open cancellation manager form
            CancellationManager cm = new CancellationManager();
            cm.Show();
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
            

        }
       

        private void myaccountBTN_Click(object sender, EventArgs e)
        {
            //open accountSettings form
         account account = new account();
            account.Show();
            this.Close();
            
            
            

        }

        private void SearchRoutesBTN_Click(object sender, EventArgs e)
        {
            //open search rooutes fomr
            searchRoutes sr= new searchRoutes();
            sr.Show();
            this.Close();

        }

        private void BookTicketBTN_Click(object sender, EventArgs e)
        {
            //open book tickets form
            bookTicket bt = new bookTicket();
            bt.Show();
            this.Close();

        }

        private void bookticketpic_Click(object sender, EventArgs e)
        {
            BookTicketBTN_Click(sender, e);
        }

        private void CancelticketsBTN_Click(object sender, EventArgs e)
        {
            //open cancel tickets form
            //cancelTickets ct = new cancelTickets();
            //ct.show();
            //this.close();
        }

        private void cancellationBTN_Click(object sender, EventArgs e)
        {
            CancellationMGRBtn_Click(sender, e);
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            //open history form
            myHistory h = new myHistory();
            h.Show();
            this.Close();

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            //open history form
            myHistory h = new myHistory();
            h.Show();
            this.Close();

        }

        private void myaccountpic_Click(object sender, EventArgs e)
        {
            //open account settings form
            //accountSettings as = new accountSettings();
            //as.show();
            //this.close();

        }

        private void searchroutesticket_Click(object sender, EventArgs e)
        {
            //open search routes form
            searchRoutes sr = new searchRoutes();
            sr.Show();
            this.Close();

        }
        private void fillrouteidcombo()
        {
            //connect to database
            //fill route id combo box
            ticketIDcombo.Items.Clear();
            SqlConnection conn = new DatabaseConnection().getConnection();

            conn.Open();
            //query from reservation table in which the date is incoming and not outgoing
            
            string query = "Select Reservation.id from Reservation INNER JOIN Route ON routeID=Route.id where passengerID='" + loggedinUserdetail.loggedinUserID+"' AND status='Active' AND date>"+DateTime.Now.ToString("yyyy-MM--dd");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ticketIDcombo.Items.Add(dr["id"].ToString());
            }
            conn.Close();






        }

        private void ReservationIDManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            //first empty tbe box
            
            SqlConnection conn = new DatabaseConnection().getConnection();
            int id = int.Parse(ticketIDcombo.SelectedItem.ToString());


            string query = " SELECT Route.id as ID, trainid AS[Train ID], Train.name AS[Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Reservation INNER JOIN Route ON Route.id=routeID INNER JOIN Train ON trainid = Train.id WHERE '" + id + "'=Reservation.id AND  Reservation.status='Active'" ;


            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrainIDTXT.Text = dr["Train ID"].ToString();
                TrainNameTXT.Text = dr["Train Name"].ToString();
                SourceTXTBox.Text = dr["Source"].ToString();
                DestinationTXT.Text = dr["Destination"].ToString();
                DateTXT.Text = dr["Date"].ToString();
                CostTXT.Text = dr["Cost"].ToString();
            }


            conn.Close();
        }

        private void DeleteReservationBTN_Click(object sender, EventArgs e)
        {
            if (ticketIDcombo.Text == "")
            {
                MessageBox.Show("Please select a reservation to delete");
            }
            else
            {
                //open connection
                SqlConnection conn = new DatabaseConnection().getConnection();
                conn.Open();
                //insert into cancellation table
                string timeDate = DateTime.Now.ToString("yyyy-MM-dd");


                string b = ticketIDcombo.SelectedItem.ToString();
                
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
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();


                string query2 = "insert into Cancellation values('" + b + "','" + timeDate + "')";
                SqlCommand sqlCommand = new SqlCommand(query2, conn);
                sqlCommand.ExecuteNonQuery();

                conn.Close();



                MessageBox.Show("Reservation Deleted Successfully");
                
            }
           
        }
    }
}
