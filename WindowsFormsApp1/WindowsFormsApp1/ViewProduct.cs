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
    public partial class ViewProduct : Form
    {
        ProductModule productModule = new ProductModule();
        public ViewProduct()
        {
            InitializeComponent();
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {
            DataTable dt = productModule.getProductFunc();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
