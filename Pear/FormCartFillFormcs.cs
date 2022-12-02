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
    public partial class FormCartFillFormcs : Form
    {
        public FormCartFillFormcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Thank you! Your Order was placed, now you will recieve an email confirmation");

            
        }
    }
}
