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
    public partial class AddUser : Form
    {
        UserModule userModule = new UserModule();
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            DataTable dt = userModule.getUserCategoryFunc();
            if(dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = dt.Columns["UserCategory"].ToString();
                comboBox1.ValueMember = dt.Columns["Id"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age;
            int tempOut;
            string fullname = textBox1.Text.ToString().Trim();
            string email = textBox3.Text.ToString().Trim();
            string username = textBox4.Text.ToString().Trim();
            string password = textBox5.Text.ToString().Trim();
            string confirmPassword = textBox6.Text.ToString().Trim();
            int category = int.Parse(comboBox1.SelectedValue.ToString());
            bool ageCheck = int.TryParse(textBox2.Text.ToString(), out tempOut);
            if (ageCheck)
            {
                age = tempOut;
                if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Please fill in all the blank!");
                }
                else if(!password.Equals(confirmPassword))
                {
                    MessageBox.Show("Password is not same with confirm password!");
                }
                else
                {                   
                    try
                    {
                        if (userModule.addUserFunc(fullname, age, email, username, password, category) == 1)
                        {
                            MessageBox.Show("User successfully added!");
                        }
                        else
                        {
                            MessageBox.Show("Fail to add user!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Fatal Error when insert user. Please contact administrator!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please key in numeric for Age!");
            }
            
        }
    }
}
