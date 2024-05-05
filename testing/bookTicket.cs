using System;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace testing
{
    public partial class bookTicket : Form
    {
        public int userLoggedInid = -1;
        public bookTicket()
        {
            
            InitializeComponent();
            fillrouteidcombo();
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
            //bookTickets bt = new bookTickets();
            //bt.show();
            //this.close();

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

        private void fillrouteidcombo()
        {
           //connect to database
            //fill route id combo box
           SqlConnection conn = new DatabaseConnection().getConnection();

            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from Route", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                routeIDcombo.Items.Add(dr["id"].ToString());
            }
            conn.Close();


            



        }

        private void routeIDcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill the textboxes with the selected route id
            SqlConnection conn = new DatabaseConnection().getConnection();
            int id = int.Parse(routeIDcombo.SelectedItem.ToString());


            string query = " SELECT Route.id as ID, trainid AS[Train ID], name AS[Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid = Train.id WHERE '" + id + "'=Route.id";


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

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void BookTicketTXT_Click(object sender, EventArgs e)
        {
            //book ticket
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //check if the user has already booked this route
            string query = "SELECT * FROM Reservation WHERE routeID = '" + routeIDcombo.SelectedItem.ToString() + "' AND passengerID = '" + loggedinUserdetail.loggedinUserID + "' AND status='Active'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("You have already booked this route");
                return;
            }
            



            conn.Close();
            conn.Open();
            query = "INSERT INTO Reservation (routeID, passengerID, status) VALUES ('" + routeIDcombo.SelectedItem + "','" +loggedinUserdetail.loggedinUserID + "' , 'Active')";
           SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Ticket Booked Successfully");
            conn.Close();
        }
    }
}
