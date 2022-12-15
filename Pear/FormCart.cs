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
    public partial class FormCart : Form
    {
        public static FormCart instance;

        public int cartquanity = 12;


        public FormCart()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);


                MyConn5.Open();
                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; select * from cart where userid = (select userid from userinfo where username = '" + Form1.instance.tb1.Text + "');";
                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5 = MyCommand5.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(MyReader5);
                dataGridView2.DataSource = table;

                MyConn5.Close();

            }
            {
                //start of connection for product added to orders table
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);


                MyConn5.Open();
                string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename " +
                    "FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MySqlDataReader MyReader5 = MyCommand5.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(MyReader5);
                dataGridView1.DataSource = table;

                MyConn5.Close();
                //end of connection for product added to orders table

                button3.Text = "Refresh Cart Details";
                button2.Text = "Refresh Cart";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {


            openChildForm(new FormCartFillFormcs());


        }


        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCart());

        }

        private void FormCart_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //start of connection for product added to orders table
            string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);


            MyConn5.Open();
            string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; select * from cart where userid = (select userid from userinfo where username = '" + Form1.instance.tb1.Text + "');";
            MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
            MySqlDataReader MyReader5 = MyCommand5.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(MyReader5);
            dataGridView2.DataSource = table;

            MyConn5.Close();


            //end of connection for product added to orders table
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {


            string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);


            MyConn5.Open();
            string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; delete from orders where cartid = (select cartid from cart where userid = (select userid from userinfo where username = '" + Form1.instance.tb1.Text + "'));";
            MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
            MySqlDataReader MyReader5 = MyCommand5.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(MyReader5);
            dataGridView1.DataSource = table;

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


        }


        #region deleteRow
        //DELETE ROW
        private void button7_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }*/

            button3.Text = "Refresh Cart Details";

            // Get the index of the selected row
             int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            // Get the selected row using the selected row index
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

            // Get the value of the cell that corresponds to the primary key of the database table
            object primaryKeyValue = selectedRow.Cells[0].Value;

            // Connect to the database
            string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);
            MyConn5.Open();

            // Create the SQL query
            string Query5 = "DELETE FROM orders WHERE orderid = @orderid";
            MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
            MyCommand5.Parameters.AddWithValue("@orderid", primaryKeyValue);

            // Execute the query and get the number of affected rows
            int affectedRows = MyCommand5.ExecuteNonQuery();

            // Check if the query was successful
            if (affectedRows > 0)
            {
                // Remove the row from the DataGridView
                dataGridView1.Rows.RemoveAt(selectedRowIndex);

                // Update the DataGridView to show the changes
                dataGridView1.Refresh();
            }

            MyConn5.Close();

            //start of the mysql for cartquanity count
            string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";

            string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity-1, total = total - 400 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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



            //still need to work on

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndexs = dataGridView1.SelectedCells[0].RowIndex;

                // Get the selected row using the selected row index
                DataGridViewRow selectedRowData = dataGridView1.Rows[selectedRowIndexs];

                // Get the value of the cell in the fourth column of the selected row
                object cellValue = selectedRowData.Cells[3].Value;

                /*string MyConnection5ss = "datasource=localhost;port=3306;username=root;password=";

                string Query5s = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT catogorieName FROM products WHERE productname = 'pearmacwhite'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                MySqlConnection MyConn5s = new MySqlConnection(MyConnection5ss);

                MySqlCommand MyCommand5s = new MySqlCommand(Query5s, MyConn5s);
                MySqlDataReader MyReader5s;
                MyConn5s.Open();
                MyReader5s = MyCommand5.ExecuteReader();
                while (MyReader5s.Read())
                {
                    textBox1.Text = MyReader5s.ToString();
                }
                MyConn5.Close();*/

                // Check if the value of the cell is equal to "pearphone"
                if (textBox1.Text == "pearphone")
                {
                    //start of connection for total count
                    string connectionString = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    string query = "USE pearstoreProject; UPDATE cart SET total = total-599 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                    //end of connection for total count
                }
                else if (cellValue.ToString() == "pearpad")
                {
                    //start of connection for total count
                    string connectionString = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    string query = "USE pearstoreProject; UPDATE cart SET total = total-499 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                    //end of connection for total count
                }
                else if (cellValue.ToString() == "pearmac")
                {
                    //start of connection for total count
                    string connectionString = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    string query = "USE pearstoreProject; UPDATE cart SET total = total-799 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                    //end of connection for total count
                }
                else if (cellValue.ToString() == "pearpods")
                {
                    //start of connection for total count
                    string connectionString = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    string query = "USE pearstoreProject; UPDATE cart SET total = total-250 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                    //end of connection for total count
                }
                else if (cellValue.ToString() == "pearwatch")
                {
                    //start of connection for total count
                    string connectionString = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    string query = "USE pearstoreProject; UPDATE cart SET total = total-399 WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                    //end of connection for total count
                }
            }

        }


        #endregion deleteRowEnd

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private Form activeForms = null;
        private void openChildForms(Form childForm)
        {
            if (activeForms != null)
                activeForms.Close();
            activeForms = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Form1.instance.pb1.Controls.Add(childForm);
            Form1.instance.pb1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForms(new FormAllProducts());
            this.Close();

        }


        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Get the value of the third cell in the selected row
            object cellValue = selectedRow.Cells[1].Value;

                // Check the value of the cell
                if (cellValue.Equals(1001) || cellValue.Equals(1002) || cellValue.Equals(1003) || cellValue.Equals(1004))
                {

                    comboBox1.Items.Add("pearphonepurple");
                    comboBox1.Items.Add("pearphoneblue");
                    comboBox1.Items.Add("pearphoneblack");
                    comboBox1.Items.Add("pearphonegreen");

                    comboBox1.Visible = true;


                }
                else if(cellValue.Equals(1005) || cellValue.Equals(1006) || cellValue.Equals(1007) || cellValue.Equals(1008))
                {

                    comboBox1.Items.Add("pearpadpurple");
                    comboBox1.Items.Add("pearpadblack");
                    comboBox1.Items.Add("pearpadblue");
                    comboBox1.Items.Add("pearpadgreen");

                    comboBox1.Visible = true;
                }
                else if (cellValue.Equals(1009) || cellValue.Equals(1010) || cellValue.Equals(1011))
                {

                    comboBox1.Items.Add("pearbookwhite");
                    comboBox1.Items.Add("pearbookpurple");
                    comboBox1.Items.Add("pearbookred");

                    comboBox1.Visible = true;
                }
                else if (cellValue.Equals(1013))
                {
                        

                    comboBox1.Items.Add("pearpods");


                    comboBox1.Visible = true;
                }
                else if(cellValue.Equals(1012))
                {

                    comboBox1.Items.Add("pearwatch");

                    comboBox1.Visible = true;
                }
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            button3.Text = "Refresh Cart Details";

            {
                // Get the index of the selected row
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the selected row using the selected row index
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                // Get the value of the cell that corresponds to the primary key of the database table
                object primaryKeyValue = selectedRow.Cells[0].Value;

                // Connect to the database
                string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);
                MyConn5.Open();

                // Create the SQL query
                string Query5 = "DELETE FROM orders WHERE orderid = @orderid";
                MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                MyCommand5.Parameters.AddWithValue("@orderid", primaryKeyValue);

                // Execute the query and get the number of affected rows
                int affectedRows = MyCommand5.ExecuteNonQuery();

                // Check if the query was successful
                if (affectedRows > 0)
                {
                    // Remove the row from the DataGridView
                    dataGridView1.Rows.RemoveAt(selectedRowIndex);

                    // Update the DataGridView to show the changes
                    dataGridView1.Refresh();
                }

                MyConn5.Close();

                //start of the mysql for cartquanity count
                string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";

                string Querys = "USE pearstoreProject; UPDATE cart SET cartquanity = cartquanity WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "');";
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

            }


            //Insering the New product rowed

            if (comboBox1.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to continue?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearphonepurple"))
                    {
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



                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        // Get the index of the selected row
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                            // Get the selected row using the selected row index
                            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                            // Get the value of the cell that corresponds to the primary key of the database table
                            object primaryKeyValue = selectedRow.Cells[0].Value;

                            // Connect to the database
                            string MyConnection5ss = "datasource=localhost;port=3306;username=root;password=";
                            MySqlConnection MyConn5s = new MySqlConnection(MyConnection5ss);
                            MyConn5s.Open();

                            // Create the SQL query
                            string Query5s = "DELETE FROM orders WHERE orderid = @orderid";
                            MySqlCommand MyCommand5s = new MySqlCommand(Query5s, MyConn5s);
                            MyCommand5s.Parameters.AddWithValue("@orderid", primaryKeyValue);

                            // Execute the query and get the number of affected rows
                            int affectedRows = MyCommand5s.ExecuteNonQuery();

                            // Check if the query was successful
                            if (affectedRows > 0)
                            {
                                // Remove the row from the DataGridView
                                dataGridView1.Rows.RemoveAt(selectedRowIndex);

                                // Update the DataGridView to show the changes
                                dataGridView1.Refresh();
                            }

                            MyConn5s.Close();
                        }

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearphonegreen"))
                    {
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



                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearphoneblack"))
                    {
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

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearphoneblue"))
                    {
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



                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }

                    #region restOfProducts
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearpadblack"))
                    {
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

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearpadblue"))
                    {
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

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearpadpurple"))
                    {
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

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearpadgreen"))
                    {
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

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearbookred"))
                    {
                        //start of connection for product added to orders table
                        string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                        string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearmacred'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                        MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                        MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                        MySqlDataReader MyReader5;
                        MyConn5.Open();
                        MyReader5 = MyCommand5.ExecuteReader();
                        while (MyReader5.Read())
                        {

                        }
                        MyConn5.Close();

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearbookpurple"))
                    {
                        //start of connection for product added to orders table
                        string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                        string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearmacpurple'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                        MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                        MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                        MySqlDataReader MyReader5;
                        MyConn5.Open();
                        MyReader5 = MyCommand5.ExecuteReader();
                        while (MyReader5.Read())
                        {

                        }
                        MyConn5.Close();

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
                    else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.Equals("pearbookwhite"))
                    {
                        //start of connection for product added to orders table
                        string MyConnection5s = "datasource=localhost;port=3306;username=root;password=";

                        string Query5 = "USE pearstoreproject; SET foreign_key_checks = 0; INSERT INTO orders(orderid, productID, cartId) VALUES (NULL, (SELECT productID FROM products WHERE productname = 'pearmacwhite'), (SELECT cartID FROM cart WHERE userid = (SELECT userid FROM userinfo WHERE username = '" + Form1.instance.tb1.Text + "'))); SET foreign_key_checks = 1;";
                        MySqlConnection MyConn5 = new MySqlConnection(MyConnection5s);

                        MySqlCommand MyCommand5 = new MySqlCommand(Query5, MyConn5);
                        MySqlDataReader MyReader5;
                        MyConn5.Open();
                        MyReader5 = MyCommand5.ExecuteReader();
                        while (MyReader5.Read())
                        {

                        }
                        MyConn5.Close();

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=";
                        MySqlConnection MyConn = new MySqlConnection(MyConnection5);


                        MyConn.Open();
                        string Query = "USE pearstoreproject; SET foreign_key_checks = 0; SELECT t1.orderid, t1.productid, t2.productname, t3.catagoriename FROM orders t1 INNER JOIN products t2 ON t1.productid = t2.productid INNER JOIN catagories t3 ON t2.catagorieid = t3.catagorieid ;";
                        MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(MyReader5);
                        dataGridView1.DataSource = table;

                        MyConn.Close();

                        //end of connection for product added to orders table
                        dataGridView1.Update();

                    }
#endregion


                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
