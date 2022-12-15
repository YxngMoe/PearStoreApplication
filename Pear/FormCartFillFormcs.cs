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
    public partial class FormCartFillFormcs : Form
    {

        //ihab

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public FormCartFillFormcs()
        {
            InitializeComponent();
            connection.Open();
            string selectQuery2 = "SELECT firstname FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery2, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label5.Text = mdr.GetString(0);

            }

            connection.Close();

            connection.Open();
            string selectQuery3 = "SELECT lastname FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery3, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label6.Text = mdr.GetString(0);

            }

            connection.Close();


            //email connection

            connection.Open();
            string selectQuery4 = "SELECT email FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery4, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label7.Text = mdr.GetString(0);

            }

            connection.Close();

            connection.Open();
            string selectQuery5 = "SELECT username FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery5, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label8.Text = mdr.GetString(0);

            }

            connection.Close();

            connection.Open();
            string selectQuery6 = "USE pearstoreproject; SELECT cartquanity FROM pearstoreproject.cart WHERE userid = (Select userid from userinfo where userName = '" + Form1.instance.tb1.Text + "');";
            command = new MySqlCommand(selectQuery6, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label16.Text = mdr.GetString(0);

            }

            connection.Close();

                connection.Open();
                string selectQuery6q = "USE pearstoreproject; SELECT total FROM pearstoreproject.cart WHERE userid = (Select userid from userinfo where userName = '" + Form1.instance.tb1.Text + "');";
                command = new MySqlCommand(selectQuery6q, connection);
                mdr = command.ExecuteReader();

                while (mdr.Read())
                {
                    label10.Text = mdr.GetString(0);
                }

                connection.Close();
               
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Thank you! Your Order was placed, now you will recieve an email confirmation");

            if (result == DialogResult.OK)
            {

                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; delete from orders where cartid = (select cartid from cart where userid = (select userid from userinfo where username = '" + Form1.instance.tb1.Text + "'));";
                MySqlCommand MyCommands = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReaders;
                MyConn5.Open();
                MyReaders = MyCommands.ExecuteReader();
                while (MyReaders.Read())
                {

                }
                MyConn5.Close();

                string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";


                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = 0 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";

                MySqlConnection MyConn = new MySqlConnection(MyConnection5);

                MySqlCommand MyCommand = new MySqlCommand(Querys, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {

                }
                MyConn.Close();

                string MyConnection6 = "datasource=localhost;port=3306;username=root;password=";


                string Query6 = "USE pearstoreProject; UPDATE cart SET total = 0 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";

                MySqlConnection MyConn6 = new MySqlConnection(MyConnection6);

                MySqlCommand MyCommand6 = new MySqlCommand(Query6, MyConn6);
                MySqlDataReader MyReader6;
                MyConn6.Open();
                MyReader6 = MyCommand6.ExecuteReader();
                while (MyReader6.Read())
                {

                }
                MyConn6.Close();

                this.Close();

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery2 = "SELECT firstname FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery2, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label5.Text = mdr.GetString(0);

            }

            connection.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}

//ihab