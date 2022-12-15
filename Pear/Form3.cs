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

namespace Pear
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //home button
        private void button4_Click_1(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                button1.Text = "Add to Cart $499.00";
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


                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearpadpurple'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
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

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+499 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                button2.Text = "Add to Cart $499.00";


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

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearpadblack'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
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

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+499 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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

        private void button5_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                button5.Text = "Add to Cart $499.00";
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

                button5.Text = "Added";

                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearpadblue'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
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

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+499 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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

        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();


            if (Form1.instance.tb1.Text == "")
            {
                button6.Text = "Add to Cart $499.00";
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

                button6.Text = "Added";

                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearpadgreen'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
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

                string Queryss = "USE pearstoreProject; UPDATE cart SET total = total+499 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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

            button1.Text = "Add to cart $499.00";

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Text = "Add";

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = "Add to cart $499.00";

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Text = "Add";

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Text = "Add to cart $499.00";

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Text = "Add";

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Text = "Add to cart $499.00";

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}


