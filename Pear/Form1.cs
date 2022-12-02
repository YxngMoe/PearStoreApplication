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
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
            customizeDesign();

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
            if(panelAccessoriesSubMenu.Visible == true)
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

            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());

            //mycode

            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearMac());
            //mycode

            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPearPC());
            //mycode

            hideSubMenu();
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

            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCases());
            //mycode

            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new FormWatch());
            //mycode

            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //mycode

            hideSubMenu();
        }

        #endregion

        private void btnCart_Click(object sender, EventArgs e)
        {

            FormCart frmCart = new FormCart();

            frmCart.Show();
            //mycode

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
            openChildForm(new Form3());
            //mycode

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
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
