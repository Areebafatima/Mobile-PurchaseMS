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
    public partial class Sony : Form
    {
        public Sony()
        {
            InitializeComponent();
        }
        public void Color()
        {
            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select Color from Colors ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            ColorCombo.Items.Clear();

            while (dr.Read())
            {
                ColorCombo.Items.Add(dr["Color"]).ToString();
            }
            sqlcon.Close();
        }
        private void Sony_Load(object sender, EventArgs e)
        {
            Z5PB.Visible = false;
            ConditionTB.Text = "New";
            ConditionTB.Visible = false;
            ColorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModelCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            BuyBTN.Cursor = Cursors.Hand;
            BuyBTN.Enabled = false;
            CatTB.ReadOnly = true;
            WarrantyTB.ReadOnly = true;
            PriceTB.ReadOnly = true;
            ConditionTB.ReadOnly = true;
            DescriptionTB.ReadOnly = true;
            ColorCombo.Enabled = false;
            BuyBTN.Enabled = false;

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select Model from Sony ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ModelCombo.Items.Add(dr["Model"]).ToString();
            }
            Color();
            sqlcon.Close();
        }

        private void ModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModelCombo.Text == "Xperia Z5")
            {
                ColorCombo.Enabled = true;
                Z5PB.Visible = true;
                ConditionTB.Visible = true;
                BuyBTN.Enabled = true;
            }

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sony where Model = @Model", sqlcon);
            cmd.Parameters.AddWithValue("@Model", ModelCombo.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                WarrantyTB.Text = dr["Warranty"].ToString();
                PriceTB.Text = dr["Unit Price"].ToString();
                DescriptionTB.Text = dr["Description"].ToString();
            }
            ColorCombo.Enabled = true;
            sqlcon.Close();
        }

        private void BuyBTN_Click(object sender, EventArgs e)
        {
            if (ColorCombo.Text == "")
            {
                CatMB mb = new CatMB();
                mb.ShowDialog();
               // MessageBox.Show("Please select the color of product......", "Mobile Gallery", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Invoice voice = new Invoice();
                voice.Show();
            }
        }
    }
}
