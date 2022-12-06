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
    public partial class FormWatch : Form
    {
        
        public FormWatch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                frm.Show();
            }
        }
    }
}
