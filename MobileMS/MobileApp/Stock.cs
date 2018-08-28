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

namespace MobileApp
{
    public partial class Stock : Form
    {
    
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            button1.Cursor= Cursors.Hand;
            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Stock ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            sqlcon.Close();
        }

        private void StockTB_TextChanged(object sender, EventArgs e)
        {
            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Stock where Model = '" + StockTB.Text + "'", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                sqlcon.Close();
        }
    }
}
