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
    public partial class AddSalesOrder : Form
    {
        CustomerModule customerModule = new CustomerModule();
        double quantity = 0, unitprice = 0;
        public AddSalesOrder()
        {
            InitializeComponent();
        }

        private void AddSalesOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = customerModule.getCustomerFunc();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if(dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = dt.Columns["CusName"].ToString();
                comboBox1.ValueMember = dt.Columns["Id"].ToString();
            }
            
            DataGridViewTextBoxColumn txtno = new DataGridViewTextBoxColumn();
            txtno.HeaderText = "#";
            DataGridViewComboBoxColumn dgCombo = new DataGridViewComboBoxColumn();
            dgCombo.HeaderText = "Description";
            DataGridViewTextBoxColumn txtquantity = new DataGridViewTextBoxColumn();
            txtquantity.HeaderText = "Quantity";
            DataGridViewTextBoxColumn txtunitprice = new DataGridViewTextBoxColumn();
            txtunitprice.HeaderText = "Unit Price(RM)";
            DataGridViewTextBoxColumn txtamount = new DataGridViewTextBoxColumn();
            txtamount.HeaderText = "Amount(RM)";
            txtamount.ReadOnly = true;

            dataGridView1.Columns.Insert(0, txtno);
            dataGridView1.Columns.Insert(1, dgCombo);
            dataGridView1.Columns.Insert(2, txtquantity);
            dataGridView1.Columns.Insert(3, txtunitprice);
            dataGridView1.Columns.Insert(4, txtamount);

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
            DataTable dt = customerModule.getCustomerFunc(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                richTextBox1.Text = dt.Rows[0]["CusAddress"].ToString();
                textBox1.Text = (string.IsNullOrWhiteSpace(dt.Rows[0]["CusOfficePhone"].ToString()) ? dt.Rows[0]["CusHandPhone"].ToString() : dt.Rows[0]["CusOfficePhone"].ToString());
                textBox2.Text = dt.Rows[0]["CusEmail"].ToString();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {    
            if (e.RowIndex >= 0)
            {
                switch (this.dataGridView1.Columns[e.ColumnIndex].HeaderText)
                {
                    case "Quantity":
                        quantity = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        break;
                    case "Unit Price(RM)":
                        unitprice = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        break;
                }
                              
                double total = unitprice * quantity;
                Console.WriteLine("Total" + total);
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = total;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string id = comboBox1.SelectedValue.ToString();
                DataTable dt = customerModule.getCustomerFunc(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    richTextBox1.Text = dt.Rows[0]["CusAddress"].ToString();
                    textBox1.Text = (string.IsNullOrWhiteSpace(dt.Rows[0]["CusOfficePhone"].ToString()) ? dt.Rows[0]["CusHandPhone"].ToString() : dt.Rows[0]["CusOfficePhone"].ToString());
                    textBox2.Text = dt.Rows[0]["CusEmail"].ToString();
                }
            }
        }      
    }
}
