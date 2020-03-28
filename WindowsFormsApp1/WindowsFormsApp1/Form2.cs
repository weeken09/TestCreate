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
        private bool isFormOpen = false;
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
            ViewProduct vPForm = new ViewProduct();       
            vPForm.MdiParent = this;
            vPForm.WindowState = FormWindowState.Maximized;
            vPForm.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser aUForm = new AddUser();
            aUForm.MdiParent = this;
            aUForm.WindowState = FormWindowState.Maximized;
            aUForm.Show();
        }

        private void viewEditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUser vUForm = new ViewUser();
            vUForm.MdiParent = this;
            vUForm.WindowState = FormWindowState.Maximized;
            vUForm.Show();
        }
    }
}
