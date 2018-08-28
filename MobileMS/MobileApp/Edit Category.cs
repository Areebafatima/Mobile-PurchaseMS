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
    public partial class Edit_Category : Form
    {
        public Edit_Category()
        {
            InitializeComponent();
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Update Brands set Name = @Name where BrandID = @BrandID" , sqlcon);
            cmd.Parameters.AddWithValue("@BrandID", BrandCombo.Text);
            cmd.Parameters.AddWithValue("@Name", BNameTB.Text);
            cmd.ExecuteNonQuery();
         
            MessageBox.Show("Brand name is updated !");

            sqlcon.Close();
        }

        private void Edit_Category_Load(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select BrandID from Brands", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BrandCombo.Items.Add(dr["BrandID"]).ToString();
            }
            sqlcon.Close();
        }
    }
}
