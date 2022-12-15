using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;




namespace Pear
{
  
    public partial class Form2 : Form
    {

        //collin


        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        



        public static Form2 instance;

        public int[] totalProductsQuanity = new int[100];
        public int i = 0;

        

        
        public Form2()
        {
            InitializeComponent();

            
        }



        #region button1events
        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();

            if (Form1.instance.tb1.Text == "")
            {
                button1.Text = "Add to Cart $599.00";

                string message = "Please login first!            Would you like to login?";
                string caption = "Login";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the message box
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    frm.Show();
                }
                

            }
            else
            {
                button1.Text = "Added";
                //FormCart.instance.cartquanity += 1;


                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearphonepurple'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5;
                MyConn5.Open();
                MyReader5 = MyCommand5.ExecuteReader();
                while (MyReader5.Read())
                {

                }
                MyConn5.Close();

                //end of connection for product added to orders table



                //start of connection for cartquanity count
                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=";

                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity+1 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2s = new MySqlConnection(MyConnection3);

                MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                MySqlDataReader MyReader2s;
                MyConn2s.Open();
                MyReader2s = MyCommand2s.ExecuteReader();
                while (MyReader2s.Read())
                {
                }
                MyConn2s.Close();
                //end of connection for cartquanity count

                //start of connection for total count
                string MyConnection3s = "datasource=localhost;port=3306;username=root;password=";

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+599 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2ss = new MySqlConnection(MyConnection3s);

                MySqlCommand MyCommand2ss = new MySqlCommand(Queryss, MyConn2ss);
                MySqlDataReader MyReader3;
                MyConn2ss.Open();
                MyReader3 = MyCommand2ss.ExecuteReader();
                while (MyReader3.Read())
                {
                }
                MyConn2ss.Close();
                //end of connection for total count
            }

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Text = "Add";

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            button1.BackColor = Color.Black;
            button5.ForeColor = Color.White;
            button1.Text = "Add to cart $599.00";

        }
#endregion

        #region button2Events
        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();

            if (Form1.instance.tb1.Text == "")
            {
                button2.Text = "Add to Cart $599.00";
                string message = "Please login first!            Would you like to login?";
                string caption = "Login";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the message box
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    frm.Show();
                }
                
            }
            else
            {
                button2.Text = "Added";

                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearphoneblue'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5;
                MyConn5.Open();
                MyReader5 = MyCommand5.ExecuteReader();
                while (MyReader5.Read())
                {

                }
                MyConn5.Close();

                //end of connection for product added to orders table


                //start of connection for cartquanity count
                string MyConnection2s = "datasource=localhost;port=3306;username=root;password=";
                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity+1 WHERE userid = (SELECT userid FROM userinfo WHERE username = '"+Form1.instance.tb1.Text+"');";
                MySqlConnection MyConn2s = new MySqlConnection(MyConnection2s);

                MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                MySqlDataReader MyReader2s;
                MyConn2s.Open();
                MyReader2s = MyCommand2s.ExecuteReader();
                while (MyReader2s.Read())
                {
                }
                MyConn2s.Close();
                
                //end of connection for cartquanity count

                //start of connection for total count
                string MyConnection3s = "datasource=localhost;port=3306;username=root;password=";

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+599 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2ss = new MySqlConnection(MyConnection3s);

                MySqlCommand MyCommand2ss = new MySqlCommand(Queryss, MyConn2ss);
                MySqlDataReader MyReader3;
                MyConn2ss.Open();
                MyReader3 = MyCommand2ss.ExecuteReader();
                while (MyReader3.Read())
                {
                }
                MyConn2ss.Close();
                //end of connection for total count

            }


        }


        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.Text = "Add";



        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.Text = "Add to Cart $599.00";


        }
        #endregion

        #region button5events
        private void button5_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                button5.Text = "Add to Cart $599.00";
                string message = "Please login first!            Would you like to login?";
                string caption = "Login";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the message box
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    frm.Show();
                }
                
            }
            else
            {
                //FormCart.instance.cartquanity += 1;
                button5.Text = "Added";

                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearphoneblack'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5;
                MyConn5.Open();
                MyReader5 = MyCommand5.ExecuteReader();
                while (MyReader5.Read())
                {

                }
                MyConn5.Close();

                //end of connection for product added to orders table

                //start of the mysql for cartquanity count
                string MyConnection4 = "datasource=localhost;port=3306;username=root;password=";

                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity+1 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2s = new MySqlConnection(MyConnection4);

                MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                MySqlDataReader MyReader2s;
                MyConn2s.Open();
                MyReader2s = MyCommand2s.ExecuteReader();
                while (MyReader2s.Read())
                {
                }
                MyConn2s.Close();
                //end of the mysql for cartquanity count

                //start of connection for total count
                string MyConnection3s = "datasource=localhost;port=3306;username=root;password=";

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+599 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2ss = new MySqlConnection(MyConnection3s);

                MySqlCommand MyCommand2ss = new MySqlCommand(Queryss, MyConn2ss);
                MySqlDataReader MyReader3;
                MyConn2ss.Open();
                MyReader3 = MyCommand2ss.ExecuteReader();
                while (MyReader3.Read())
                {
                }
                MyConn2ss.Close();
                //end of connection for total count

            }

        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;
            button5.Text = "Add";
        }


        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Text = "Add to Cart $599.00";

        }

        #endregion 

        #region button6Events
        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();

            if (Form1.instance.tb1.Text == "")
            {
                button6.Text = "Add to Cart $599.00";
                string message = "Please login first!            Would you like to login?";
                string caption = "Login";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the message box
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    frm.Show();
                }
                
            }
            else
            {
                //FormCart.instance.cartquanity += 1;

                button6.Text = "Added";

                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearphonegreen'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5;
                MyConn5.Open();
                MyReader5 = MyCommand5.ExecuteReader();
                while (MyReader5.Read())
                {

                }
                MyConn5.Close();

                //end of connection for product added to orders table

                //start of the mysql for cartquanity count
                string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";

                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity+1 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2s = new MySqlConnection(MyConnection5);

                MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                MySqlDataReader MyReader2s;
                MyConn2s.Open();
                MyReader2s = MyCommand2s.ExecuteReader();
                while (MyReader2s.Read())
                {
                }
                MyConn2s.Close();
                //end of the mysql for cartquanity count

                //start of connection for total count
                string MyConnection3s = "datasource=localhost;port=3306;username=root;password=";

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+599 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                MySqlConnection MyConn2ss = new MySqlConnection(MyConnection3s);

                MySqlCommand MyCommand2ss = new MySqlCommand(Queryss, MyConn2ss);
                MySqlDataReader MyReader3;
                MyConn2ss.Open();
                MyReader3 = MyCommand2ss.ExecuteReader();
                while (MyReader3.Read())
                {
                }
                MyConn2ss.Close();
                //end of connection for total count



            }
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Text = "Add to Cart $599.00";

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
            button6.Text = "Add";
        }

        #endregion
  


        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        //collin
    }
}
