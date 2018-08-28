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
    public partial class Category : Form
    {
        Samsung sam = new Samsung();
        Apple app = new Apple();
        Sony sony = new Sony();
        Motorola moto = new Motorola();
        ToolTip tp = new ToolTip();
        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            MobPanel.Cursor = Cursors.Hand;
            tp.SetToolTip(SamBTN,"Samsung");
            tp.SetToolTip(AppleBTN,"Apple");
            tp.SetToolTip(SonyBTN,"Sony");
            tp.SetToolTip(MotoBTN,"Motorola");
            tp.IsBalloon = true;
        }

        private void SamBTN_Click(object sender, EventArgs e)
        {
            sam.Show();
            sam.CatTB.Text = this.SamBTN.Text ;
        }

        private void AppleBTN_Click(object sender, EventArgs e)
        {
            app.Show();
            app.CatTB.Text = this.AppleBTN.Text;
        }

        private void SonyBTN_Click(object sender, EventArgs e)
        {
            sony.Show();
            sony.CatTB.Text = this.SonyBTN.Text;
        }

        private void MotoBTN_Click(object sender, EventArgs e)
        {
            moto.Show();
            moto.CatTB.Text = this.MotoBTN.Text;
        }
    }
}
