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
    public partial class AddDoctor : Form
    {
        public AddDoctor()
        {
            InitializeComponent();
        }

        private void btnAddPtn_Click(object sender, EventArgs e)
        {
            try
            {
                string specialization = "";

                //bool isChecked = radioButton1.Checked;

                if (radioButton1.Checked == true)
                {
                    specialization = "ONCOLOGY";
                }
                else if (radioButton2.Checked == true)
                {
                    specialization = "CARDIOLOGY";
                }
                else if (radioButton3.Checked == true)
                {
                    specialization = "GASTROLOGY";
                }
                else if (radioButton4.Checked == true)
                {
                    specialization = "NEPHROLOGY";
                }
                else if (radioButton5.Checked == true)
                {
                    specialization = "NEUROLOGY";
                }
                else if (radioButton5.Checked == false || radioButton4.Checked == false || radioButton3.Checked == false || radioButton2.Checked == false || radioButton1.Checked == false)
                {
                    MessageBox.Show("Must select a specialization");
                }
                if(comboBox1.Text == "")
                {
                    MessageBox.Show("Nationality field cannot be empty!");
                }

                if (specialization != ""&&comboBox1.Text!="")
                {
                    string addQuery = "insert into doctors(doctor_name, specialization, age, nationality) values('" + txtName.Text + "', '" + specialization + "'," + txtAge.Text + ", '" + comboBox1.Text + "')";
                    //MessageBox.Show(addQuery);

                    
                    DataAccess access = new DataAccess();
                    access.Sqlcom = new SqlCommand(addQuery, access.Sqlcon);

                    //DataSet set = access.ExecuteQuery(addQuery);
                    int rowsUpdated = access.Sqlcom.ExecuteNonQuery();
                    if (rowsUpdated == 1)
                    {
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                    
                    //value = radioButton1.Text;

                    //value = radioButton2.Text;

                  
                    
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
        }
    }
}
