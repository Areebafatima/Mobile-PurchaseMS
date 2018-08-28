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
    public partial class Model_Registration : Form
    {
        public Model_Registration()
        {
            InitializeComponent();
        }

        private void Model_Registration_Load(object sender, EventArgs e)
        {
            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Models ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            sqlcon.Close();
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            Add_Model model = new Add_Model();
            this.Close();
            model.ShowDialog();
        }
    }
}
