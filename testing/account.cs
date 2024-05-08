using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace testing
{
    public partial class account : Form
    {
        
        public account()
        {
            
            InitializeComponent();
            populatefields();
        }
        int key = 0;
        private void populatefields()
        {
            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "SELECT * FROM Passenger WHERE id = "  + loggedinUserdetail.loggedinUserID;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //populate fields
                key= int.Parse(reader["id"].ToString());
                PassengerNaeTX.Text = reader["username"].ToString();
                PassengerMailTXT.Text = reader["email"].ToString();
                PassengerPhoneTXT.Text = reader["phone"].ToString();
                PassengerAddressTxt.Text = reader["address"].ToString();
                PassengerPasswordTXT.Text = reader["password"].ToString();
                if (reader["gender"].ToString() == "Male")
                {
                    MalerdioBTN.Checked = true;
                }
                else
                {
                    FemaleRDIOBTN.Checked = true;
                }
            }
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
            
            

        }

        private void SearchRoutesBTN_Click(object sender, EventArgs e)
        {
           // open search rooutes fomr
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

        private void UpdateAccountBTN_Click(object sender, EventArgs e)
        {
            //update passenger
            if(PassengerNaeTX.Text == "" || PassengerMailTXT.Text == "" || PassengerPhoneTXT.Text == "" || PassengerAddressTxt.Text == "" || PassengerPasswordTXT.Text == "" || (MalerdioBTN.Checked == false && FemaleRDIOBTN.Checked == false))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            //connect to database
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string username= PassengerNaeTX.Text;
            string email = PassengerMailTXT.Text;
            string phone = PassengerPhoneTXT.Text;
            string address = PassengerAddressTxt.Text;
            string password = PassengerPasswordTXT.Text;
            string gender="";
            if(MalerdioBTN.Checked)
            {
                gender = "Male";

            }
            else
            {
                gender = "Female";
            }
            //check for existing email
            string query = "SELECT * FROM Passenger WHERE email = '" + email + "' AND id != " + loggedinUserdetail.loggedinUserID;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Email already exists");
                conn.Close();
                return;
            }
            conn.Close();
            //update passenger
            conn.Open();
            query = "UPDATE Passenger SET username = '" + username + "', email = '" + email + "', phone = '" + phone + "', address = '" + address + "', password = '"+password+"', gender = '"+gender+"' WHERE id = " + key;
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Account updated successfully");
            populatefields();




        }

        private void searchroutesticket_Click(object sender, EventArgs e)
        {
            //open search routes form
            searchRoutes sr = new searchRoutes();
            sr.Show();
            this.Close();

        }

        private void TrainsMgrBtn_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
