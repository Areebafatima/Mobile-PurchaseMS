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
    public partial class Apple : Form
    {
        public Apple()
        {
            InitializeComponent();
        }

        private void Apple_Load(object sender, EventArgs e)
        {
            iPhonePB.Visible = false;
            ConditionTB.Text = "New";
            ConditionTB.Visible = false;
            ColorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModelCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            BuyBTN.Cursor = Cursors.Hand;
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
            SqlCommand cmd = new SqlCommand("Select Model from Apple ", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ModelCombo.Items.Add(dr["Model"]).ToString();
            }
            Color();
            sqlcon.Close();
        }
        public void Color()
        {
            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd1 = new SqlCommand("Select Color from Colors ", sqlcon);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            ColorCombo.Items.Clear();
            while (dr1.Read())
            {
                ColorCombo.Items.Add(dr1["Color"]).ToString();
            }

            sqlcon.Close();
        }
        private void ModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModelCombo.Text == "iPhone 6")
            {
                BuyBTN.Enabled = true;
                iPhonePB.Visible = true;
                ConditionTB.Visible = true;
            }

            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Apple where Model = @Model", sqlcon);

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
                //MessageBox.Show("Please select the color of product......", "Mobile Gallery", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Invoice voice = new Invoice();
                voice.Show();
            }
        }
    }
}
