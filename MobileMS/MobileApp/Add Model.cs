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
    public partial class Add_Model : Form
    {
        public Add_Model()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");

            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Insert into Models (BrandID,ModelID,Name,Warranty,Specification,Color) values (@BrandID,@ModelID,@Name,@Warranty,@Specification,@Color)", sqlcon);

            cmd.Parameters.AddWithValue("@BrandID", BrandCombo.Text);
            cmd.Parameters.AddWithValue("@ModelID", ModelNoTB.Text);
            cmd.Parameters.AddWithValue("@Name", MNameTB.Text);
            cmd.Parameters.AddWithValue("@Warranty", WarrantyTB.Text);
            cmd.Parameters.AddWithValue("@Specification", SpecificationTB.Text);
            cmd.Parameters.AddWithValue("@Color", ColorTB.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Model has been registered!! ");
            sqlcon.Close();
        }

        private void Add_Model_Load(object sender, EventArgs e)
        {

            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select Name from Brands", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BrandCombo.Items.Add(dr["Name"]).ToString();
            }
            sqlcon.Close();
        }
    }
}
