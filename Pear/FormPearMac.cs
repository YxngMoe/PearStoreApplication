using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pear
{
    public partial class FormPearMac : Form
    {
        public static FormPearMac instance;
        public FormPearMac()
        {
            InitializeComponent();
            instance = this;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                frm.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                frm.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                frm.Show();
            }
        }
    }
}
