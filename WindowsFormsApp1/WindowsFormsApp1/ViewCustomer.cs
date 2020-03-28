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
    public partial class ViewCustomer : Form
    {
        CustomerModule customerModule = new CustomerModule();
        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            DataTable dt = customerModule.getCustomerFunc();
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
