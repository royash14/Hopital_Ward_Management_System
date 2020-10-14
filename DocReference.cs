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
    public partial class DocReference : Form
    {
        public DocReference()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtDocID.Text) == true)
            {
                MessageBox.Show("Field cannot be empty!");
            }
            else 
            {
                try
                {
                    DataAccess access = new DataAccess();
                    string searchDoctor = "Select * from Doctors where Doctor_id=" + txtDocID.Text;

                    access.Sqlcom = new SqlCommand(searchDoctor, access.Sqlcon);
                    access.Sda = new SqlDataAdapter(access.Sqlcom);
                    DataTable table = new DataTable();
                    access.Sda.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Doctor found!:" + table.Rows[0]["doctor_name"].ToString());
                        InsertPatient insertPatient = new InsertPatient();
                        insertPatient.LoadName(table.Rows[0]["doctor_name"].ToString());
                        insertPatient.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No doctor with this ID exists!");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            
        }

        private void txtDocID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
