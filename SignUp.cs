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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBox1.Text) == true|| String.IsNullOrWhiteSpace(textBox2.Text) == true || String.IsNullOrWhiteSpace(textBox3.Text) == true || String.IsNullOrWhiteSpace(textBox4.Text) == true || String.IsNullOrWhiteSpace(textBox5.Text) == true)
            {
                MessageBox.Show("One or more of the fields is empty!");
            }    
            else if(textBox4.Text!= textBox5.Text)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                try
                {
                    DataAccess access = new DataAccess();
                    string query = "insert into users(Full_name,userid,username,password, admin) values ('" + textBox1.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "', 0);";
                    //MessageBox.Show(query);
                    access.Sqlcom = new SqlCommand(query, access.Sqlcon);
                    int check = access.Sqlcom.ExecuteNonQuery();
                    if (check == 0)
                    {
                        MessageBox.Show("Insertion Failed");
                    }
                    else
                    {
                        MessageBox.Show("Insertion Succeded");
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
