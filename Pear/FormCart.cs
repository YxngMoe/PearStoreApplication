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
    public partial class FormCart : Form
    {
        public FormCart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);  
            row.Cells[0].Value = "Cell1";
            row.Cells[1].Value = "Cell2s";
            dataGridView1.Rows.Add(row);
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCartFillFormcs());
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCart());
        }
    }
}
