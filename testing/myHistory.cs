using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace testing
{
    public partial class myHistory : Form
    {
        
        public myHistory()
        {

            
            InitializeComponent();
            populatecancelledtickets();
            populateActiveTickets();
                }
       
        private void adminMainform_Load(object sender, EventArgs e)
        {
        }

        private void populateActiveTickets()
        {
            //populate the datagridview with data
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "Select Reservation.id AS [T ID], Passenger.username AS [Passenger Name] , Train.name AS [Train Name] , Route.source AS Source , Route.destination AS Destination , Route.date AS Date, Route.cost AS Cost From Reservation INNER JOIN Passenger ON passengerID=Passenger.id INNER JOIN Route ON routeID=Route.id INNER JOIN Train ON Route.trainid=Train.id WHERE Reservation.Status='Active' AND Passenger.id = " + loggedinUserdetail.loggedinUserID;
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create a datatable
            DataSet dataSet = new DataSet();
            //fill the datatable
            da.Fill(dataSet, "Route");
            //set the datasource of the datagridview
            datagridviewactivetickets.DataSource = dataSet.Tables["Route"];
            //close connection
            conn.Close();
        }
       
            private void populatecancelledtickets()
            {
                //populate the datagridview with data
                SqlConnection conn = new DatabaseConnection().getConnection();
                conn.Open();
                //prepare query
                string query = "Select Reservation.id AS [T ID], Passenger.username AS [Passenger Name] , Train.name AS [Train Name] , Route.source AS Source , Route.destination AS Destination , Route.date AS Date, Route.cost AS Cost From Reservation INNER JOIN Passenger ON passengerID=Passenger.id INNER JOIN Route ON routeID=Route.id INNER JOIN Train ON Route.trainid=Train.id WHERE Reservation.Status='Cancelled' AND Passenger.id = " + loggedinUserdetail.loggedinUserID;
                //prepare command
                SqlCommand cmd = new SqlCommand(query, conn);
                //create adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //create a datatable
                DataSet dataSet = new DataSet();
                //fill the datatable
                da.Fill(dataSet, "Route");
                //set the datasource of the datagridview
                cancelledTickets.DataSource = dataSet.Tables["Route"];
                //close connection
                conn.Close();
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
            cancelTicket ct = new cancelTicket();
            ct.Show();
            this.Close();
        }

        private void cancellationBTN_Click(object sender, EventArgs e)
        {
            CancellationMGRBtn_Click(sender, e);
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            //open history form
            //history h = new history();
            //h.show();
            //this.close();

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            //open history form
            //history h = new history();
            //h.show();
            //this.close();

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

        private void datagridviewactivetickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //store id of the clicked row
            string id= datagridviewactivetickets.Rows[e.RowIndex].Cells[0].Value.ToString();
            //open cancellation form
            cancelTicket ct = new cancelTicket(id);
            ct.Show();
            this.Close();

        }
    }
}
