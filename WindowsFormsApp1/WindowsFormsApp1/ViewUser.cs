using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSoft
{
    public partial class ViewUser : Form
    {
        UserModule userModule = new UserModule();
        public ViewUser()
        {
            InitializeComponent();
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            DataTable dt = userModule.getUserFunc();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
