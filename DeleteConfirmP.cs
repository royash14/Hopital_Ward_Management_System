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
    public partial class DeleteConfirmP : Form
    {
        public DeleteConfirmP()
        {
            InitializeComponent();
        }

        private string patient_id = "";

        public void LoadData(DataGridViewRow selectedRow)
        {
            patient_id = selectedRow.Cells["patient_id"].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPtn_Click(object sender, EventArgs e)
        {

            try
            {
                string deleteQuery = "delete from patients where patient_id = " + patient_id;

                //MessageBox.Show(updateQuery);

                DataAccess access = new DataAccess();
                access.Sqlcom = new SqlCommand(deleteQuery, access.Sqlcon);
                int rowsUpdated = access.Sqlcom.ExecuteNonQuery();
                if (rowsUpdated == 1)
                {
                    MessageBox.Show("Successfully deleted entry");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
    }
}
