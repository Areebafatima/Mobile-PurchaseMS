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
    public partial class NewAccount : Form
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            button1.Enabled = false;
            AcceptButton = button1;
            Exit.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            UserTB.Clear();
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UserTB.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label2.Visible = true;
            PasswordTB.Clear();
            PasswordTB.UseSystemPasswordChar = true;
            PasswordTB.MaxLength = 10;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PasswordTB.ForeColor = Color.Black;
            label5.Visible = true;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            EmailTB.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            EmailTB.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection Conn = new Connection();
            SqlConnection sqlcon = new SqlConnection();
            Conn.ConnectionOpen(sqlcon, "MobileMS");

            SqlCommand cmd = new SqlCommand("Insert into Login(UserName,Password,Email) values (@UserName, @Password, @Email)", sqlcon);
            cmd.Parameters.AddWithValue("@UserName",UserTB.Text);
            cmd.Parameters.AddWithValue("@Password",PasswordTB.Text);
            cmd.Parameters.AddWithValue("@Email",EmailTB.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Congratulations !! Your account has been created....");
            sqlcon.Close();
        }
    }
}
