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
    public partial class Login : Form
    {
        ToolTip tp = new ToolTip();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label1.Visible = false;
            label2.Visible = false;
            button1.Enabled = false;
            AcceptButton = button1;
            Exit.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            tp.SetToolTip(Exit,"Close");
            tp.IsBalloon = true;          
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");

            //sqlcon.ConnectionString = "Data Source=DESKTOP-1DB2R4F;Initial Catalog=MobileMS;Integrated Security=True";
            //sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Login where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                LoginMB lg = new LoginMB();
                lg.ShowDialog();
                //MessageBox.Show("Incorrect username or password. Please Re-Enter..", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlcon.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label2.Visible = true;
            textBox2.Clear();
            textBox2.UseSystemPasswordChar = true;
            textBox2.MaxLength = 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black ;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewAccount account = new NewAccount();
            account.ShowDialog();
            this.Hide();
        }
    }
}
