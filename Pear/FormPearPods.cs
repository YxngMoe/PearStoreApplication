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
    public partial class FormPearPods : Form
    {
        public static FormPearPods instance;

        public FormPearPods()
        {
            InitializeComponent();
            instance = this;
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
