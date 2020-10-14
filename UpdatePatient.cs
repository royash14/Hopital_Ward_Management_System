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
    public partial class UpdatePatient : Form
    {
        public UpdatePatient()
        {
            InitializeComponent();
        }
        private string patient_id="";

        public void LoadData(DataGridViewRow selectedRow)
        {
            txtName.Text = selectedRow.Cells["PATIENT_NAME"].Value.ToString();
            cmbGender.Text = selectedRow.Cells["GENDER"].Value.ToString();
            txtAge.Text = selectedRow.Cells["AGE"].Value.ToString(); ;
            txtDgn.Text = selectedRow.Cells["DIAGNOSIS"].Value.ToString(); ;
            txtDocName.Text = selectedRow.Cells["DOCTOR_Name"].Value.ToString(); ;
            txtWardNo.Text = selectedRow.Cells["WARD_No"].Value.ToString();
            txtBill.Text = selectedRow.Cells["BILL"].Value.ToString();
            patient_id = selectedRow.Cells["patient_id"].Value.ToString();
            
        }
        private void btnAddPtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtName.Text) == true)
                {
                    MessageBox.Show("Name field cannot be empty!");
                }
                else
                {
                    try
                    {
                        string date = dtpAdmission.Value.Date.ToString("yyyy-MM-dd");
                        string updateQuery = "update patients set patient_name='" + txtName.Text + "',Gender ='" + cmbGender.Text + "',Age =" + txtAge.Text + ",Diagnosis ='" + txtDgn.Text + "', Doctor_Name ='" + txtDocName.Text + "',Ward_No =" + txtWardNo.Text + ",Bill = " + txtBill.Text +
                           ",admit_date = convert(date,'"+ date+"') from patients where patient_id = " + patient_id;

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
            catch (Exception t)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
                         // private void dtpAdmission_ValueChanged(object sender, EventArgs e)


                     
                    
