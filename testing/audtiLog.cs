using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace testing
{
    public partial class auditLog : Form
    {
        private string auditType = "";
        public auditLog()
        {
            InitializeComponent();
        }

        private void populate()
        {
            if (auditType == "")
            {
                return;
            }
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();

            //prepare query
            string query = "";
            if (auditType == "Passenger")
            {
                query= "select * from Passenger_Audit";
                
            }
            else if (auditType == "Train")
            {
                query= "select * from Train_Audit";
            }
            else if (auditType == "Route")
            {
                query= "select * from Route_Audit";
            }
            else if (auditType == "Reservation")
            {
                query= "select * from Reservation_Audit ";
            }
            else if (auditType == "Cancellation")
            {
                query= "select * from Cancellation_Audit";
            }
            else
            {
                return;
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            
            //create Data table
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

           guna2DataGridView1.DataSource = dt.Tables[0];
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
            //open tickets manager form
            TicketsManager tm = new TicketsManager();
            tm.Show();
            this.Close();

        }

        private void PassengerMGRBtn_Click(object sender, EventArgs e)
        {

        }

        private void CheckLogsBTN_Click(object sender, EventArgs e)
        {
            if(auditlogocombobox.Text == "")
            {
                MessageBox.Show("Please select an audit log type");
                return;
            }  
            else if(auditlogocombobox.Text == "Passengers")
            {

                auditType = "Passenger";
                guna2HtmlLabel3.Text="Passenger Audit Logs";
            }
            else if (auditlogocombobox.Text == "Trains")
            {
                auditType = "Train";
                guna2HtmlLabel3.Text = "Train Audit Logs";
            }
            else if (auditlogocombobox.Text == "Routes")
            {
                auditType = "Route";
                guna2HtmlLabel3.Text = "Route Audit Logs";
            }
            else if (auditlogocombobox.Text == "Reservations")
            {
                auditType = "Reservation";
                guna2HtmlLabel3.Text = "Reservation Audit Logs";
            }
            else if (auditlogocombobox.Text == "Cancellations")
            {
                auditType = "Cancellation";
                guna2HtmlLabel3.Text = "Cancellation Audit Logs";
            }  
            DeleteLogsBTN.Visible=true;
            populate();
        }

        private void DeleteLogsBTN_Click(object sender, EventArgs e)
        {
            //delete the logs selected in the combobox
            //connect
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query = "";
            if (auditType == "Passenger")
            {
                query = "delete from Passenger_Audit";
            }
            else if (auditType == "Train")
            {
                query = "delete from Train_Audit";
            }
            else if (auditType == "Route")
            {
                query = "delete from Route_Audit";
            }
            else if (auditType == "Reservation")
            {
                query = "delete from Reservation_Audit ";
            }
            else if (auditType == "Cancellation")
            {
                query = "delete from Cancellation_Audit";
            }
            else
            {
                return;
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            populate();
        }
    }
}
