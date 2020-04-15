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
        ProductModule productModule = new ProductModule();
        double quantity = 0, unitprice = 0;
        DataTable dtSO;
        double total = 0;
        bool taxable;
        string productName;
        public AddSalesOrder()
        {
            InitializeComponent();
        }

        private void AddSalesOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = customerModule.getCustomerFunc();
            DataTable dtPro = productModule.getProductFunc();
            dtSO = new DataTable();
            dtSO.Columns.Add("Product", typeof(string));
            dtSO.Columns.Add("Unit Price(RM)", typeof(double));
            dtSO.Columns.Add("Quantity", typeof(double));
            dtSO.Columns.Add("Amount(RM)", typeof(string));
            dtSO.Columns.Add("Remark", typeof(string));
            dtSO.Columns.Add("Taxable", typeof(string));           
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if(dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = dt.Columns["CusName"].ToString();
                comboBox1.ValueMember = dt.Columns["Id"].ToString();
            }
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (dtPro != null)
            {
                comboBox2.DataSource = dtPro;
                comboBox2.DisplayMember = dtPro.Columns["ProductName"].ToString();
                comboBox2.ValueMember = dtPro.Columns["Id"].ToString();
            }          
            dataGridView1.DataSource = dtSO;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "0.00##";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "0.0##";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "0.00##";
            
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

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = comboBox2.SelectedValue.ToString();
            DataTable dt = productModule.getProductFunc(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                textBox3.Text = string.Format("{0:0.00}", double.Parse(dt.Rows[0]["ProductPrice"].ToString()));
                taxable = (int.Parse(dt.Rows[0]["Taxable"].ToString()) == 1);
                productName = dt.Rows[0]["ProductName"].ToString();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
            if(dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                double tempOut;
                TextBox txtQuantity = e.Control as TextBox;
                if(double.TryParse(txtQuantity.Text, out tempOut)){
                    quantity = tempOut;
                }
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
           
            var currentcell = dataGridView1.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells[3];
            DataGridViewTextBoxCell celNo = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells[0];
            if (sendingCB.SelectedValue != null)
            {
                DataTable dtPS = productModule.getProductFunc(sendingCB.SelectedValue.ToString());
                if (dtPS != null)
                {
                    cel.Value = dtPS.Rows[0]["ProductPrice"].ToString();
                    celNo.Value = (currentcell.Y + 1).ToString();
                }
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temp;
            double quantity = 0;
            if(double.TryParse(textBox4.Text.ToString(), out temp))
            {
                quantity = temp;
                if(string.IsNullOrEmpty(textBox3.Text.ToString()) || string.IsNullOrEmpty(textBox4.Text.ToString()))
                {
                    MessageBox.Show("Please fill in all the blank!");
                }
                else if(quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity!");
                }
                else
                {
                    double price = double.Parse(textBox3.Text.ToString());
                    double amount = price * quantity;
                    string remark = textBox6.Text.ToString();
                    total += amount;
                    dtSO.Rows.Add(productName,price,quantity,amount,remark,taxable ? "Yes" : "No");
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                    }
                    label9.Text = string.Format("{0:0.00}", total);
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity!");
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox2.SelectedValue != null)
                {
                    string id = comboBox2.SelectedValue.ToString();
                    DataTable dt = productModule.getProductFunc(id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        textBox3.Text = string.Format("{0:0.00}", double.Parse(dt.Rows[0]["ProductPrice"].ToString()));
                        taxable = (int.Parse(dt.Rows[0]["Taxable"].ToString()) == 1);
                        productName = dt.Rows[0]["ProductName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No product found!");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    total -= double.Parse(row.Cells[3].Value.ToString());
                    dataGridView1.Rows.RemoveAt(row.Index);                   
                }
                label9.Text = string.Format("{0:0.00}", total);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }
            }           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
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
                else
                {
                    MessageBox.Show("No customer found!");
                }
            }
        }      
    }
}
