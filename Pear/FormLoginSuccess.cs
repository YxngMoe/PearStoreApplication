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
    public partial class FormLoginSuccess : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Label tb2;

        public static FormLoginSuccess instance;

        public FormLoginSuccess()
        {
            InitializeComponent();
            instance = this;
            tb2 = label1;


        }



        private void btnLogOut_Click(object sender, EventArgs e)
        {



            Form1.instance.tb1.Text = "";

            this.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region firstName Connection
            connection.Open();
            string selectQuery1 = "SELECT FirstName FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery1, connection);
            mdr = command.ExecuteReader();

            while (mdr.Read())
            {
                label1.Text = mdr.GetString(0);

            }

            connection.Close();


            #endregion
            #region lastName Connection

            connection.Open();
            string selectQuery2 = "SELECT LastName FROM pearstoreproject.userinfo WHERE userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery2, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label2.Text = mdr.GetString(0);

            }

            connection.Close();
            #endregion
            #region Gender Connection

            connection.Open();
            string selectQuery3 = "SELECT Gender FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery3, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label3.Text = mdr.GetString(0);

            }

            connection.Close();
            #endregion
            #region Birthday Connection

            connection.Open();
            string selectQuery4 = "SELECT Birthday FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';"; 
            command = new MySqlCommand(selectQuery4, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label4.Text = mdr.GetString(0);

            }

            connection.Close();
            #endregion
            #region Email Connection

            connection.Open();
            string selectQuery5 = "SELECT Email FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery5, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label5.Text = mdr.GetString(0);

            }

            connection.Close();
            #endregion
            #region username
            connection.Open();
            string selectQuery6 = "SELECT username FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery6, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label6.Text = mdr.GetString(0);

            }

            connection.Close();

            #endregion
            #region accountCreatedDate
            connection.Open();
            string selectQuery8 = "SELECT datecreated FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery8, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label17.Text = mdr.GetString(0);

            }

            connection.Close();

            #endregion
            #region lastlogin


            connection.Open();
            string selectQuery9 = "SELECT lastlogin FROM pearstoreproject.userinfo where userName ='" + Form1.instance.tb1.Text + "';";
            command = new MySqlCommand(selectQuery9, connection);
            mdr = command.ExecuteReader();


            while (mdr.Read())
            {
                label14.Text = mdr.GetString(0);

            }

            connection.Close();

            #endregion

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormLoginSuccess_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
