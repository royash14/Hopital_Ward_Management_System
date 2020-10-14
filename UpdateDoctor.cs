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
    public partial class UpdateDoctor : Form
    {
        public UpdateDoctor()
        {
            InitializeComponent();
        }

        private string doctor_id = "";

        public void LoadData(DataGridViewRow selectedRow)
        {
            txtName.Text = selectedRow.Cells["DOCTOR_NAME"].Value.ToString();
            txtAge.Text = selectedRow.Cells["AGE"].Value.ToString(); 
            txtNationality.Text = selectedRow.Cells["Nationality"].Value.ToString(); 
            doctor_id = selectedRow.Cells["doctor_id"].Value.ToString();

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

                if (specialization != "")
                {
                    if(String.IsNullOrWhiteSpace(txtName.Text) == true)
                    {
                        MessageBox.Show("Name field cannot be empty!");
                    }
                else
                    {
                        try
                        {
                            string updateQuery = "update doctors set doctor_name ='" + txtName.Text + "', specialization = '" + specialization + "', age = " + txtAge.Text + ", nationality = '" + txtNationality.Text + "' where doctor_id = " + doctor_id;
                            //MessageBox.Show(updateQuery);
                            
                            DataAccess access = new DataAccess();
                            access.Sqlcom = new SqlCommand(updateQuery, access.Sqlcon);
                            int rowsUpdated = access.Sqlcom.ExecuteNonQuery();
                            if (rowsUpdated == 1)
                            {
                                MessageBox.Show("Successful");
                            }
                            else
                            {
                                MessageBox.Show("Failed");
                            }
                            
                        }
                        catch (Exception t)
                        {
                            MessageBox.Show(t.ToString());
                        }
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
    }
}
