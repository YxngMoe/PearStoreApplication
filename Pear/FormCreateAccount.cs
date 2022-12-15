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
    public partial class FormCreateAccount : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public static FormCreateAccount instance;

        public ComboBox combox;
        public FormCreateAccount()
        {
            InitializeComponent();
            combox = comboBoxGender;
        }

        private void FormCreateAccount_Load(object sender, EventArgs e)
        {
            comboBoxGender.Items.Add("Yes");
            comboBoxGender.Items.Add("No");

        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtpassword.Text != txtpassword.Text)
            {
                MessageBox.Show("Password doesn't match!", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtfirst.Text) || string.IsNullOrEmpty(txtlast.Text) || string.IsNullOrEmpty(comboBoxGender.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtconpass.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            else
            {
                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM pearstoreproject.userinfo WHERE Username = @UserName", connection),
                cmd2 = new MySqlCommand("SELECT * FROM pearstoreproject.userinfo WHERE Email = @UserEmail", connection);


                cmd1.Parameters.AddWithValue("@UserName", txtUser.Text);
                cmd2.Parameters.AddWithValue("@UserEmail", txtEmail.Text);

                bool userExists = false, mailExists = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email not available!");


                if (!(userExists || mailExists))
                {

                    string iquery = "INSERT INTO pearstoreproject.userinfo(`userID`,`FirstName`,`LastName`,`Gender`,`Birthday`,`Email`,`Username`, `Password`) VALUES (NULL, '" + txtfirst.Text + "', '" + txtlast.Text + "', '" + comboBoxGender.Text + "', '" + dateTimePicker1.Value.Date + "', '" + txtEmail.Text + "', '" + txtUser.Text + "', '" + txtpassword.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }



          
                    MessageBox.Show("Account Successfully Created!");
                    
                    

                    //'" + FormCart.instance.cartquanity + "' incase i need to make this instance again its here

                    string MyConnection2s = "datasource=localhost;port=3306;username=root;password=";

                    string Querys = "USE pearstoreProject; INSERT INTO cart(`cartid`, `userid`, `total`, `cartquanity`) VALUES (NULL, (SELECT userid FROM userinfo WHERE Username = '" + txtUser.Text + "'), 0, 0);";
                    MySqlConnection MyConn2s = new MySqlConnection(MyConnection2s);

                    MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                    MySqlDataReader MyReader2s;
                    MyConn2s.Open();
                    MyReader2s = MyCommand2s.ExecuteReader();
                    while (MyReader2s.Read())
                    {
                    }
                    MyConn2s.Close();

                }
                connection.Close();


            }
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            this.Close();

            FormLogin frm4 = new FormLogin();
            frm4.ShowDialog();

            this.Close();

        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
