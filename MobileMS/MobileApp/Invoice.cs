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
    public partial class Invoice : Form
    {
        int count = 0,c;
        string[] Brand = new string[20];
        string[] Model = new string[20];
        int[] Qty = new int[20];
        int[] Price = new int[100];
        ToolTip tp = new ToolTip();
        InvoiceMB mb = new InvoiceMB();
        public Invoice()
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
            SqlCommand cmd1 = new SqlCommand("Select Color from Colors ", sqlcon);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            ColorCombo.Items.Clear();

            while (dr1.Read())
            {

                ColorCombo.Items.Add(dr1["Color"]).ToString();
            }
            sqlcon.Close();
        }

        public void ClearTB()
        {
            WarrantyTB.Clear();
            PQtyTB.Clear();
            PriceTB.Clear();
            PModelCombo.Items.Clear();
            TotalTB.Clear();
        }
        public void Samsung()
        {
            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Samsung where Model = @Model", sqlcon);

            cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                WarrantyTB.Text = dr["Warranty"].ToString();
                PriceTB.Text = dr["Unit Price"].ToString();
            }
            ColorCombo.Enabled = true;
            sqlcon.Close();
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
            InvoiceNoTB.ReadOnly = true;
            CIDTB.ReadOnly = true;
            TotalTB.ReadOnly = true;
            ColorCombo.Enabled = false;
            CreateBTN.Visible = false;
            AddBTN.Enabled = false;
            PTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            PModelCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ColorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            tp.SetToolTip(PTypeCombo, "Select category");
            tp.SetToolTip(PModelCombo, "Select model");
            tp.SetToolTip(ColorCombo, "Select Color");
            tp.SetToolTip(PQtyTB, "Quantity");
            tp.SetToolTip(WarrantyTB, "Warranty");
            tp.SetToolTip(PriceTB, "Unit Price");
            tp.SetToolTip(TotalTB,"Total Amount");

            Connection Conn = new Connection();

            SqlConnection sqlcon = new SqlConnection();

            Conn.ConnectionOpen(sqlcon, "MobileMS");
            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select Name from Brands", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            PTypeCombo.Items.Clear();

            while (dr.Read())
            {
                PTypeCombo.Items.Add(dr["Name"]).ToString();
            }
            sqlcon.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlConnection sqlcon = new SqlConnection();

            if (PQtyTB.Text == "" && CNameTB.Text == "" && CPhTB.Text == "" )
            {
                MessageBox.Show("Please enter complete details.", "Mobile Gallery", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                Connection Conn = new Connection();

                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd1 = new SqlCommand("Select count (InvoiceID) from Invoice ", sqlcon);
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    count = Convert.ToInt32(dr1[0]);
                    count++;
                }

                InvoiceNoTB.Text = "MG" + "-00 " + count.ToString() + "_" + System.DateTime.Today.Year;
                sqlcon.Close();

                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd2 = new SqlCommand("Select count (CID) from Invoice ", sqlcon);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.Read())
                {
                    c = Convert.ToInt32(dr2[0]);
                    c++;
                }

                CIDTB.Text = "Customer" + "-00 " + c.ToString() + "_" + System.DateTime.Today.Year;
                sqlcon.Close();

                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Invoice (InvoiceID,Date,CID,CName,CPH,Brand,Model,Warranty,Quantity,Price,TotalAmount) values (@InvoiceID, @Date, @CID, @CName, @CPH, @Brand, @Model, @Warranty, @Quantity, @Price, @TotalAmount)", sqlcon);
                cmd.Parameters.AddWithValue("@InvoiceID", InvoiceNoTB.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@CID", CIDTB.Text);
                cmd.Parameters.AddWithValue("@CName", CNameTB.Text);
                cmd.Parameters.AddWithValue("@CPH", CPhTB.Text);
                cmd.Parameters.AddWithValue("@Brand", PTypeCombo.Text);
                cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);
                cmd.Parameters.AddWithValue("@Warranty", WarrantyTB.Text);
                cmd.Parameters.AddWithValue("@Quantity", PQtyTB.Text);
                cmd.Parameters.AddWithValue("@Price", PriceTB.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalTB.Text);
                cmd.ExecuteNonQuery();

                mb.ShowDialog();

                SqlCommand cmd3 = new SqlCommand("Update Stock set Quantity = Quantity - "+PQtyTB.Text+" where Model = @Model ", sqlcon);
                cmd3.Parameters.AddWithValue("@Model", PModelCombo.Text);
                cmd3.Parameters.AddWithValue("@Quantity", PQtyTB.Text);
                cmd3.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        private void PTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");

            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd= new SqlCommand("Select Model from PModels where Category = @Category",sqlcon);
            cmd.Parameters.AddWithValue("@Category", PTypeCombo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            PModelCombo.Items.Clear();
            ClearTB();

            while (dr.Read())
            {
                PModelCombo.Items.Add(dr["Model"]).ToString();
            }
            Color();
            sqlcon.Close();
        }
        private void AddBTN_Click(object sender, EventArgs e)
        {
            CreateBTN.Visible = true;

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");

            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Insert into Product (Brand,Model,Price,Quantity) values (@Brand,@Model,@Price,@Quantity) ", sqlcon);
            cmd.Parameters.AddWithValue("@Brand", PTypeCombo.Text);
            cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);
            cmd.Parameters.AddWithValue("@Price",PriceTB.Text);
            cmd.Parameters.AddWithValue("@Quantity", PQtyTB.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("Select * from Product", sqlcon);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.Update();

            var q = Convert.ToSingle(PQtyTB.Text);
            var p = Convert.ToSingle(PriceTB.Text);
            var amount = q * p;
            TotalTB.Text = amount.ToString();
            sqlcon.Close();

        }

        private void PQtyTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void CPhTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PQtyTB_TextChanged(object sender, EventArgs e)
        {
            AddBTN.Enabled = true;
        }

        private void PModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PTypeCombo.Text == "Samsung" && PModelCombo.Text == "S9")
            {
                Samsung();
            }

            else if (PTypeCombo.Text == "Samsung" && PModelCombo.Text == "C7")
            {
                Samsung();
            }
            else if (PTypeCombo.Text == "Motorola" && PModelCombo.Text == "Nexus 6")
                {
                Connection Conn = new Connection();
                SqlConnection sqlcon = new SqlConnection();
                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Motorola where Model = @Model", sqlcon);

                cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    WarrantyTB.Text = dr["Warranty"].ToString();
                    PriceTB.Text = dr["Unit Price"].ToString();
                }
                ColorCombo.Enabled = true;
                sqlcon.Close();
            }
            else if (PTypeCombo.Text == "Apple" && PModelCombo.Text == "iPhone 6")
            {
                Connection Conn = new Connection();
                SqlConnection sqlcon = new SqlConnection();
                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Apple where Model = @Model", sqlcon);

                cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    WarrantyTB.Text = dr["Warranty"].ToString();
                    PriceTB.Text = dr["Unit Price"].ToString();
                }
                ColorCombo.Enabled = true;
                sqlcon.Close();
            }

            else if (PTypeCombo.Text == "Sony" && PModelCombo.Text == "Xperia Z5")
            {
                Connection Conn = new Connection();
                SqlConnection sqlcon = new SqlConnection();
                Conn.ConnectionOpen(sqlcon, "MobileMS");
                //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
                //sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sony where Model = @Model", sqlcon);
                cmd.Parameters.AddWithValue("@Model", PModelCombo.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    WarrantyTB.Text = dr["Warranty"].ToString();
                    PriceTB.Text = dr["Unit Price"].ToString();
                }
                ColorCombo.Enabled = true;
                sqlcon.Close();
            }
        }
    }
}
