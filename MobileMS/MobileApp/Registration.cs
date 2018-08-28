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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Brands ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add_Category add = new Add_Category();
            //add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Edit_Category edit = new Edit_Category();
            //edit.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow items in this.dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.RemoveAt(items.Index);
            //}
            
            //    SqlConnection sqlcon = new SqlConnection();
            //    sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //    sqlcon.Open();
            //    SqlCommand cmd = new SqlCommand("Delete from Brands where BrandID = @BrandID", sqlcon);

            //cmd.ExecuteNonQuery();

            //    MessageBox.Show("Brand name is updated !");
            //    sqlcon.Close();
            }
        }
}
