using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace testing
{
    public partial class trainsmanager : Form
    {
        public trainsmanager()
        {
            InitializeComponent();
        }
        private void mainform_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //enlarge on hover
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            passengermanager pm= new passengermanager();
            
            this.Hide();
            pm.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void TraingManagerbt_Click(object sender, EventArgs e)
        {
            //trainsmanager tm = new trainsmanager();
            //this.Close();
            //tm.Show();


        }
        private void routesmgrbtn_Click(object sender, EventArgs e)
        {
            routesmanager rm = new routesmanager();
            rm.Show();
            this.Hide();

        }

        private void Reservationmgrbt_Click(object sender, EventArgs e)
        {
            Reservationmanager rm = new Reservationmanager();
            rm.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cancellationmanager cm = new cancellationmanager();
            cm.Show();
            this.Hide();

        }

        private void routesmgrbtn_Click_1(object sender, EventArgs e)
        {
            routesmgrbtn_Click(sender, e);
        }

        private void Reservationmgrbt_Click_1(object sender, EventArgs e)
        {
            Reservationmanager rm = new Reservationmanager();
            rm.Show();
            this.Close();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cancellationmanager cm = new cancellationmanager();
            cm.Show();
            this.Close();
            
        }
    }
}
