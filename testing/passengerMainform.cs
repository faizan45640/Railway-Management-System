using System;
using System.Windows.Forms;

namespace testing
{
    public partial class passengerMainform : Form
    {
        public int userLoggedInid = -1;
        public passengerMainform()
        {
            
            InitializeComponent();
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
            //searchRoutesform sr= new searchRoutesform();
            //sr.show();
            //this.close();

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
    }
}
