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
using System.IO;

namespace Ward_manage
{
    public partial class DischargeConfirm : Form
    {
        public DischargeConfirm()
        {
            InitializeComponent();
        }

        private string patientID;
        private string ward_no;
        private string patientName;

        private string dischargeInfoBill;
        private string dischargeInfoAge;
        private string dischargeInfoAdmission;
        

        public void LoadData(DataGridViewRow selectedRow)
        {
            patientID = selectedRow.Cells["patient_id"].Value.ToString();
            ward_no = selectedRow.Cells["ward_no"].Value.ToString();
            patientName = selectedRow.Cells["patient_name"].Value.ToString();
            MessageBox.Show(patientID);

            dischargeInfoBill = selectedRow.Cells["Bill"].Value.ToString();
            dischargeInfoAge = selectedRow.Cells["age"].Value.ToString();
            dischargeInfoAdmission = selectedRow.Cells["admit_date"].Value.ToString();
        }

        private void btnAddPtn_Click(object sender, EventArgs e)
        {
            string dischargeQuery = "update patients set discharged = 'yes' where patient_id = " + patientID;

            DataAccess access = new DataAccess();
            access.Sqlcom = new SqlCommand(dischargeQuery, access.Sqlcon);
            int rowsUpdated = access.Sqlcom.ExecuteNonQuery();

            if(rowsUpdated==1)
            {

                string roomValidityQuery = "update rooms set  availability = 'yes', pat_id = NULL where room_id  =" + ward_no;
                access.Sqlcom = new SqlCommand(roomValidityQuery, access.Sqlcon);
                access.Sqlcom.ExecuteNonQuery();

                try
                {
                    DateTime localDateTime = DateTime.Now;
                    string receiptText = "--------------Receipt--------------\n" +
                            "Name: " + patientName +
                            "\nAge: " + dischargeInfoAge +
                            "\nWard: " + ward_no +
                            "\nBill: " + dischargeInfoBill +
                            "\nAdmitted since: " + dischargeInfoAdmission +
                            "\n-----------------------------------" +
                            "\n" + localDateTime.ToString("dddd, dd MMMM yyyy");
                    MessageBox.Show(receiptText);
                    
                    using (StreamWriter sr = new StreamWriter("D:\\WardReceipts\\receipts" + localDateTime.ToString("_yyyyMMdd - HHmmss") + ".txt", false))
                    //" + localDateTime.ToString("_yyyyMMdd-HHmmss") + "
                    {
                        //Console.WriteLine("Receipt");
                        sr.WriteLine(receiptText);
                        sr.Close();
                    }
                }
                catch(Exception p)
                {
                    MessageBox.Show(p.ToString());
                }

                MessageBox.Show("Patient discharged:" +patientName);
            }
            else
            {
                MessageBox.Show("Discharge failed!");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
