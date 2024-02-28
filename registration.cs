using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegi_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" && textBoxPass.Text == "" && textBoxConfPass.Text == "")
            {
                MessageBox.Show("username and password fields are empty", "Registration faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPass.Text == textBoxConfPass.Text)
            {
                String username = textBoxUsername.Text;
                String password = textBoxPass.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\MSSQLLocalDB;Initial Catalog=todo_list; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into users (username, password) values('" + textBoxUsername.Text + "','" + textBoxPass.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Account has been sucessfully created", "Registration sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match, Enter correct password", "Registration Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPass.Text = "";
                textBoxConfPass.Text = "";
                textBoxPass.Focus();
            }
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
            {
                textBoxPass.PasswordChar = '\0';
                textBoxConfPass.PasswordChar = '\0';
            }
            else
            {
                textBoxPass.PasswordChar = '*';
                textBoxConfPass.PasswordChar = '*';
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPass.Text = "";
            textBoxConfPass.Text = "";
            textBoxUsername.Focus();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}

