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

    public partial class FormLogin : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlConnection CartConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        MySqlCommand command;
        MySqlDataReader mdr;

        public TextBox tbusername;


        public static FormLogin instance;

        int cartids = 0;
        
        public int cartidss;

        public FormLogin()
        {
            InitializeComponent();
            instance = this;
            cartidss = cartids;
            tbusername = txtUserName;

            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

       


    public void btnLogin_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
                Form1.instance.tb1.Text = "";

            }

            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM pearstoreproject.userinfo WHERE Username = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {

                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";

                    string Query = "update pearstoreproject.userinfo set LastLogin='" + dateTimePicker1.Value + "' where Username='" + this.txtUserName.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();

                    


                    Form1.instance.tb1.Text = txtUserName.Text;

                    MessageBox.Show("Login Successful!");

                    Form1.instance.btn1.Text = "Log Out";
                    this.Hide();


                }
                else
                {
                    Form1.instance.tb1.Text = "";
                    MessageBox.Show("Incorrect Login Information! Try again.");
                        
                }

                connection.Close();
           
            }
          
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCreateAccount frm3 = new FormCreateAccount();
            frm3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
