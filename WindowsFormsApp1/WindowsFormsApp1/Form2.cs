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
    }
}
