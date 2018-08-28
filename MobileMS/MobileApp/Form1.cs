using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileApp
{
    public partial class Form1 : Form
    {
        Category cat = new Category();
        Invoice voice = new Invoice();
        Stock st = new Stock();
        Records rec = new Records();
        About at = new About();
        ToolTip tp = new ToolTip();

        public Form1()
        {
            InitializeComponent();

            tp.SetToolTip(CatLPB, "Category");
            tp.SetToolTip(StockLPB, "Stock");
            tp.SetToolTip(InvoiceLPB, "Invoice");
            tp.SetToolTip(AboutLPB, "About");
            tp.SetToolTip(HomePB, "Click to expand");
            tp.SetToolTip(Exit, "Close");
            tp.SetToolTip(CategoryBTN, "Category");
            tp.SetToolTip(StockBTN, "Stock");
            tp.SetToolTip(InvoiceBTN, "Invoice");
            tp.SetToolTip(AboutBTN, "About");
            tp.SetToolTip(RecordBTN, "Records");
            tp.IsBalloon = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CatDPB.Visible = false;
            RecordDPB.Visible = false;
            StockDPB.Visible = false;
            InvoiceDPB.Visible = false;
            AboutDPB.Visible = false;

            HPanel.Cursor = Cursors.Hand;
            TPanel.Cursor = Cursors.Hand;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Category()
        {
            pictureBox1.Visible = false;
            st.Hide();
            voice.Hide();
            rec.Hide();
            cat.Show();
        }
        public void Invoice()
        {
            pictureBox1.Visible= false;
            cat.Hide();
            st.Hide();
            rec.Hide();
            voice.Show();
        }

        public void Stock()
        {
            pictureBox1.Visible = false;
            cat.Hide();
            voice.Hide();
            rec.Hide();
            st.Show();
        }

        public void Records()
        {
            pictureBox1.Visible = false;
            cat.Hide();
            voice.Hide();
            st.Hide();
            rec.Show();
        }
        private void CategoryBTN_Click(object sender, EventArgs e)
        {
            Category();
        }
        private void CatLPB_Click(object sender, EventArgs e)
        {
            Category();
        }

        private void CatDPB_Click(object sender, EventArgs e)
        {
            Category();
        }

        private void InvoiceBTN_Click(object sender, EventArgs e)
        {
            Invoice();
        }

        private void InvoiceLPB_Click(object sender, EventArgs e)
        {
            Invoice();
        }

        private void InvoiceDPB_Click(object sender, EventArgs e)
        {
            Invoice();
        }

        private void StockBTN_Click(object sender, EventArgs e)
        {
            Stock();
        }

        private void StockDPB_Click(object sender, EventArgs e)
        {
            Stock();
        }

        private void StockLPB_Click(object sender, EventArgs e)
        {
            Stock();
        }

        private void RecordBTN_Click(object sender, EventArgs e)
        {
            Records();
        }
        private void CategoryBTN_MouseEnter(object sender, EventArgs e)
        {
            CatDPB.Visible = true;
            CatLPB.Visible = false;
        }
        private void CategoryBTN_MouseLeave(object sender, EventArgs e)
        {
            CatDPB.Visible = false;
            CatLPB.Visible = true;
        }

        private void StockBTN_MouseEnter(object sender, EventArgs e)
        {
            StockDPB.Visible = true;
            StockLPB.Visible = false;
        }

        private void StockBTN_MouseLeave(object sender, EventArgs e)
        {
            StockDPB.Visible = false;
            StockLPB.Visible = true;
        }

        private void RecordBTN_MouseEnter(object sender, EventArgs e)
        {
            RecordDPB.Visible = true;
            RecordLPB.Visible = false;
        }

        private void RecordBTN_MouseLeave(object sender, EventArgs e)
        {
            RecordDPB.Visible = false;
            RecordLPB.Visible = true;
        }
        private void InvoiceBTN_MouseEnter(object sender, EventArgs e)
        {
            InvoiceDPB.Visible = true;
            InvoiceLPB.Visible = false;
        }

        private void InvoiceBTN_MouseLeave(object sender, EventArgs e)
        {
            InvoiceDPB.Visible = false;
            InvoiceLPB.Visible = true;
        }

        private void AboutBTN_MouseEnter(object sender, EventArgs e)
        {
            AboutDPB.Visible = true;
            AboutLPB.Visible = false;
        }

        private void AboutBTN_MouseLeave(object sender, EventArgs e)
        {
            AboutDPB.Visible = false;
            AboutLPB.Visible = true;
        }

        private void CatLPB_MouseEnter(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                CatLPB.Visible = false;
                CatDPB.Visible = true;
            }
        }

        private void CatLPB_MouseLeave(object sender, EventArgs e)
        {
            if(HPanel.Width == 104 && HPanel.Height == 803)
            {
                CatLPB.Visible = true;
                CatDPB.Visible = false;
            }
        }

        private void StockLPB_MouseEnter(object sender, EventArgs e) 
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                StockLPB.Visible = false;
                StockDPB.Visible = true;
            }
        }

        private void StockLPB_MouseLeave(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                StockLPB.Visible = true;
                StockDPB.Visible = false;
            }
        }

        private void RecordLPB_MouseEnter(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                RecordLPB.Visible = false;
                RecordDPB.Visible = true;
            }
        }

        private void RecordLPB_MouseLeave(object sender, EventArgs e)
        {

            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                RecordLPB.Visible = true;
                RecordDPB.Visible = false;
            }
        }
        private void InvoiceLPB_MouseEnter(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                InvoiceLPB.Visible = false;
                InvoiceDPB.Visible = true;
            }
        }

        private void InvoiceLPB_MouseLeave(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                InvoiceLPB.Visible = true;
                InvoiceDPB.Visible = false;
            }
        }

        private void AboutLPB_MouseEnter(object sender, EventArgs e)
        {

            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                AboutLPB.Visible = false;
                AboutDPB.Visible = true;
            }
        }

        private void AboutLPB_MouseLeave(object sender, EventArgs e)
        {
            if (HPanel.Width == 104 && HPanel.Height == 803)
            {
                AboutLPB.Visible = true;
                AboutDPB.Visible = false;
            }
        }

        private void HomePB_Click(object sender, EventArgs e)
        {
            HPanel.Width = 324;
            HPanel.Height = 803;
            pictureBox1.Location = new Point(547, 140);

        }

        private void AboutBTN_Click(object sender, EventArgs e)
        {
            cat.Hide();
            voice.Hide();
            st.Hide();
            rec.Hide();
            at.ShowDialog();
        }
    }
}
