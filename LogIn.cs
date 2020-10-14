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
  public partial class LogIn : Form
    {
        private bool passwordView = true;
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBx1.Text))
            {
                MessageBox.Show("Enter username");
            }
            if (String.IsNullOrWhiteSpace(txtBx2.Text))
            {
                MessageBox.Show("Enter password");
            }
            try
            {
                DataAccess access = new DataAccess();
        
                string query = "select * from users where username= '" + txtBx1.Text + "' AND password = '" + txtBx2.Text + "';";
                SqlCommand com = new SqlCommand(query, access.Sqlcon);
                access.Sda= new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                access.Sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Welcome to the system "+ dt.Rows[0][1]);
                    if(dt.Rows[0]["admin"].ToString() == "True")
                    {
                        MainWindow MW1 = new MainWindow();
                        this.Hide();
                        MW1.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MainWindow MW1 = new MainWindow();
                        MW1.HidePanelDoctor();
                        this.Hide();
                        MW1.ShowDialog();
                        this.Close();
                    }

                }
                else
                    MessageBox.Show("Invalid");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
           
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            if (passwordView==true)
            {
                txtBx2.PasswordChar = '\0';
                passwordView = false;
            }
            else if (passwordView==false)
            {
                txtBx2.PasswordChar = '*';
                passwordView = true;
            }
        }

        private void txtBx2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
