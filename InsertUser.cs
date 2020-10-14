using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ward_manage
{
    public partial class InsertUser : Form
    {
        public InsertUser()
        {
            InitializeComponent();
        }

        private void InsertPatient_Load(object sender, EventArgs e)
        {          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) == true || String.IsNullOrWhiteSpace(textBox2.Text) == true || String.IsNullOrWhiteSpace(textBox3.Text) == true || String.IsNullOrWhiteSpace(textBox4.Text) == true || String.IsNullOrWhiteSpace(textBox5.Text) == true)
            {
                MessageBox.Show("One or more field is empty!");
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Passwords did not match!");
            }
            else
            {
                try
                {
                    string addQuery = "insert into users ( Full_name,userid, username, password,admin) values('" + textBox1.Text + "'," + textBox2.Text + ",'"
                        + textBox3.Text + "','" + textBox4.Text + "',0)";
                    //MessageBox.Show(addQuery);
                    DataAccess access = new DataAccess();
                    access.Sqlcom = new SqlCommand(addQuery, access.Sqlcon);
                    int rowsUpdated = access.Sqlcom.ExecuteNonQuery();
                    if (rowsUpdated == 1)
                    {
                        MessageBox.Show("User Insertion Successful!");
                    }
                    else
                    {
                        MessageBox.Show("Failed ");
                    }
                }

                catch (Exception r)
                {
                    MessageBox.Show(r.ToString());
                }
            }
        }
    }
}
