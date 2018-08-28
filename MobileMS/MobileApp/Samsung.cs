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
    public partial class Samsung : Form
    {
        public Samsung()
        {
            InitializeComponent();
        }

        private void Samsung_Load(object sender, EventArgs e)
        {
            S9PB.Visible = false;
            C7PB.Visible = false;
            ConditionTB.Text = "New";
            ConditionTB.Visible = false;
            BuyBTN.Cursor = Cursors.Hand;
            ColorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModelCombo.DropDownStyle = ComboBoxStyle.DropDownList;
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
            //    sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select Model from Samsung ", sqlcon);
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
            if (ModelCombo.Text == "S9")
            {
                C7PB.Visible = false;
                S9PB.Visible = true;
                ConditionTB.Visible = true;
                BuyBTN.Enabled = true;
            }
            else if (ModelCombo.Text == "C7")
            {
                S9PB.Visible = false;
                C7PB.Visible = true;
                ConditionTB.Visible = true;
                BuyBTN.Enabled = true;
            }

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Samsung where Model = @Model", sqlcon);

            cmd.Parameters.AddWithValue("@Model", ModelCombo.Text);
            SqlDataReader dr1 = cmd.ExecuteReader();

            if (dr1.Read())
            {
                WarrantyTB.Text = dr1["Warranty"].ToString();
                PriceTB.Text = dr1["Unit Price"].ToString();
                DescriptionTB.Text = dr1["Description"].ToString();
            }
            ColorCombo.Enabled = true;
            sqlcon.Close();
        }
        private void button2_Click(object sender, EventArgs e)
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

