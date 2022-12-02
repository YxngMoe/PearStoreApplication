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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button1.Text = "Add";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.Text = "Add To Cart";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
            button2.Text = "Add";

            

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.Text = "Add To Cart";


        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.Text = "Add To Cart";


        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Gray;
            button5.Text = "Add";
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.White;
            button6.Text = "Add To Cart";
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.Gray;
            button6.Text = "Add";
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.Text = "Add To Cart";
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gray;
            button4.Text = "Home";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.Text = "Home";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
