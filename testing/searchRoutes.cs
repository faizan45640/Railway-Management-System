using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace testing
{
    public partial class searchRoutes : Form
    {
        public int userLoggedInid = -1;
        private string searchMode;
        

        public searchRoutes()
        {
           
            
            InitializeComponent();
            populateAll();
        }
        private void populateAll()
        {
            //connect to database

            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            //prepare query
            string query= "SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id";
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create dataset
            var ds = new DataSet();
            //fill dataset
            da.Fill(ds, "Trai");
            //set the source of data grid view
            guna2DataGridView.DataSource = ds.Tables["Trai"];
            //close connection
            conn.Close();


            ///populate fields



        }
        private void changesearchMode()
        {
            //Source
            //Destination
            //Cost
//Train
//Date
            if (searchycombo.Text=="Train")
            {
                searchTXT.PlaceholderText = "Train Name";
                searchMode = "train";
            }
            else if(searchycombo.Text=="Source")
            {
                searchTXT.PlaceholderText = "Source";

                searchMode = "source";
            }
            else if(searchycombo.Text=="Date")
            {


                searchMode = "date";
            }
            else if(searchycombo.Text == "Destination")
            {   
                searchTXT.PlaceholderText = "Destination";
                searchMode = "destination";
            }
            else if (searchycombo.Text == "Cost")
            {
                searchTXT.PlaceholderText = "Cost";
                searchMode = "cost";
            }
            if (searchMode == "date")
            {
                //hides text box and shows date time picker
                searchTXT.Visible = false;
                searchPanel.Visible = false;
                guna2DateTimePicker1.Visible = true;
                DateLabel.Visible = true;

            }
            else
            {
                searchTXT.Visible = true;
                searchPanel.Visible = true;
                guna2DateTimePicker1.Visible = false;
                DateLabel.Visible = false;

            }
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

        private void searchycombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            changesearchMode();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateAccountBTN_Click(object sender, EventArgs e)
        {

        }

        private void searchTXT_TextChanged(object sender, EventArgs e)
        {
            //connect to database
            //open connection
            SqlConnection conn = new DatabaseConnection().getConnection();
            conn.Open();
            string search= searchTXT.Text;
            string query;
            //prepare query
            if (searchMode == "source")
            {
                 query="SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id WHERE source LIKE '"+this.searchTXT.Text+"%'";                
            }
            else if (searchMode == "destination")
            {
                query="SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id WHERE destination LIKE '"+search+"%'";
            }
            else if (searchMode == "train")
            {
                query="SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id WHERE name LIKE '"+search+"%'";
            }
            else if (searchMode == "cost")
            {
                query="SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id WHERE cost LIKE '"+search+"%'";
            }
            else if (searchMode == "date")
            {
                string date= guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
                query="SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id WHERE date = '"+date+"'";
            }
            else
            {
                query = "SELECT Route.id as ID, trainid AS [Train ID] ,name AS [Train Name],  source AS Source , destination as Destination , date AS Date , cost AS Cost FROM Route INNER JOIN Train ON trainid=Train.id";
            }
            //prepare command
            SqlCommand cmd = new SqlCommand(query, conn);
            //create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //create dataset
            var ds = new DataSet();
            //fill dataset
            da.Fill(ds, "Trai");
            //set the source of data grid view
            guna2DataGridView.DataSource = ds.Tables["Trai"];
            //close connection
            conn.Close();

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            searchTXT_TextChanged(sender, e);

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
