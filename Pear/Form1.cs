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
    public partial class Form1 : Form
    {
        //ihab elryah 

        public static Form1 instance;

        public TextBox tb1;

        public Button btn1;

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;


        public Panel pb1;

        public Form1()
        {
            InitializeComponent();
            customizeDesign();
            instance = this;
            tb1 = textBox1;
            pb1 = panelChildForm;
            btn1 = btnExitApplication;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            PanelProductSubMenu.Visible = false;
            panelAccessoriesSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelAccessoriesSubMenu.Visible == true)
                panelAccessoriesSubMenu.Visible = false;
            if (PanelProductSubMenu.Visible == true)
                PanelProductSubMenu.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelProductSubMenu);

        }
        #region productsSubMenu

        private void button2_Click(object sender, EventArgs e)
        {

            openChildForm(new Form2());
            //mycode
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());

            //mycode

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearMac());
            //mycode

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearPC());
            //mycode

        }

        #endregion 

        private void btnAccessories_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAccessoriesSubMenu);
        }
        #region AccessoriesSubmenu
        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearPods());
            //mycode

        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCases());
            //mycode

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new FormWatch());
            //mycode

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //mycode


        }

        #endregion

        private void btnCart_Click(object sender, EventArgs e)
        {
            FormCart frmCart = new FormCart();



            if (textBox1.Text == "")
            {
                MessageBox.Show("Please log in first!");

            }
            else
            {

                /*string MyConnection2s = "datasource=localhost;port=3306;username=root;password=";

                string Querys = "USE pearstoreProject; UPDATE cart SET cartQuanity = '"+FormCart.instance.cartquanity+"' WHERE userid = (SELECT userid FROM userinfo WHERE username = '"+Form1.instance.textBox1.Text+"');";
                MySqlConnection MyConn2s = new MySqlConnection(MyConnection2s);

                MySqlCommand MyCommand2s = new MySqlCommand(Querys, MyConn2s);
                MySqlDataReader MyReader2s;
                MyConn2s.Open();
                MyReader2s = MyCommand2s.ExecuteReader();
                while (MyReader2s.Read())
                {
                }
                MyConn2s.Close();*/


                frmCart.Show();
                //mycode
            }

            hideSubMenu();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            openChildForm(new FormSupport());
            //mycode

            hideSubMenu();
        }



        private void btnSettings_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please log in first!");


            }
            else
            {

                FormLoginSuccess frm = new FormLoginSuccess();

                frm.Show();
                //mycode
            }

            hideSubMenu();
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
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnExitApplication_Click_1(object sender, EventArgs e)
        {
            if (Form1.instance.tb1.Text == "")
            {
                FormLogin frm = new FormLogin();

                frm.Show();
                if(Form1.instance.tb1.Text != "")
                {
                    btnExitApplication.Text = "Log Out";

                }

            }
            else
            {
                if (btnExitApplication.Text == "Log Out")
                {
                    MessageBox.Show(this, "Logging out will clear cart!", "Logging Out", MessageBoxButtons.OKCancel);

                    //start of the mysql for cartquanity count
                    string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";

                    string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = 0;";
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

                    string Queryss = "USE pearstoreProject; UPDATE cart SET total = 0;";
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

                    //start of connection for product added to orders table
                    string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                    string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; DELETE FROM orders WHERE cartid = (SELECT cartid FROM cart WHERE userid = (Select userid From userinfo where username ='" + Form1.instance.tb1.Text + "')); SET foreign_key_checks = 1;";
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


                }
                Form1.instance.tb1.Text = "";

                btnExitApplication.Text = "Log in";


            }


            

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

            private void button8_Click_1(object sender, EventArgs e)
            {

                openChildForm(new FormAllProducts());

            }

            private void button10_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        //ihab elrayah
    }
    }

