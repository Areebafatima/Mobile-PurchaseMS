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
    public partial class Add_Category : Form
    {
      
        public Add_Category()
        {
            InitializeComponent();
        }

        private void Add_Category_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Insert into Brands (BrandID,Name) values (@BrandID,@Name)", sqlcon);

            cmd.Parameters.AddWithValue("@BrandID", BrandNoTB.Text);
            cmd.Parameters.AddWithValue("@Name", BNameTB.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Brand has been added !");

            sqlcon.Close();
        }

    }
}
