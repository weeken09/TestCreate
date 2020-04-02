using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSoft
{
    public partial class Form2 : Form
    {
        private Form formOpen;
        public string username;
        public Form2()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formOpen != null)
            {
                formOpen.Dispose();
            }
            ViewProduct vPForm = new ViewProduct();       
            vPForm.MdiParent = this;
            vPForm.WindowState = FormWindowState.Maximized;
            vPForm.Show();
            formOpen = vPForm;
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            AddUser aUForm = new AddUser();
            aUForm.MdiParent = this;
            aUForm.WindowState = FormWindowState.Maximized;
            aUForm.Show();
            formOpen = aUForm;
        }

        private void viewEditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            ViewUser vUForm = new ViewUser();
            vUForm.MdiParent = this;
            vUForm.WindowState = FormWindowState.Maximized;
            vUForm.Show();
            formOpen = vUForm;
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            AddCustomer aCForm = new AddCustomer();
            aCForm.MdiParent = this;
            aCForm.WindowState = FormWindowState.Maximized;
            aCForm.Show();
            formOpen = aCForm;

        }

        private void viewEditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            ViewCustomer vCForm = new ViewCustomer();
            vCForm.MdiParent = this;
            vCForm.WindowState = FormWindowState.Maximized;
            vCForm.Show();
            formOpen = vCForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + username;
        }

        private void addSalesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            AddSalesOrder aSOForm = new AddSalesOrder();
            aSOForm.MdiParent = this;
            aSOForm.WindowState = FormWindowState.Maximized;
            aSOForm.Show();
            formOpen = aSOForm;
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen != null)
            {
                formOpen.Dispose();
            }
            AddProduct aPForm = new AddProduct();
            aPForm.MdiParent = this;
            aPForm.WindowState = FormWindowState.Maximized;
            aPForm.Show();
            formOpen = aPForm;
        }
    }
}
