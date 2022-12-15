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
    public partial class FormAllProducts : Form
    {
        public FormAllProducts()
        {
            InitializeComponent();
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
            Form1.instance.pb1.Controls.Add(childForm);
            Form1.instance.pb1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }



        


        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();

            openChildForm(new FormWatch());




        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearPods());
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearMac());
            this.Close();
        
    }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearPods());
            this.Close();
        }
    }
    }

    

