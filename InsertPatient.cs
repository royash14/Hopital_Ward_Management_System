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
    public partial class InsertPatient : Form
    {
        public InsertPatient()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) == true || String.IsNullOrWhiteSpace(cmbGender.Text) == true || String.IsNullOrWhiteSpace(txtAge.Text) == true || String.IsNullOrWhiteSpace(txtDgn.Text) == true || String.IsNullOrWhiteSpace(txtDocName.Text) == true || String.IsNullOrWhiteSpace(txtWardNo.Text) == true || String.IsNullOrWhiteSpace(txtBill.Text) == true)
            {
                MessageBox.Show("One or more field is empty!");
            }
            else
            {
                try
                {
                    string roomAvailabilityQuery = "select * from rooms where room_Id =" + txtWardNo.Text;

                    DataAccess access = new DataAccess();
                    access.Sqlcom = new SqlCommand(roomAvailabilityQuery, access.Sqlcon);
                    access.Sda = new SqlDataAdapter(access.Sqlcom);
                    DataTable table = new DataTable();
                    access.Sda.Fill(table);

                    string roomAvailability = table.Rows[0]["availability"].ToString();
                    if (table == null)
                    {
                        MessageBox.Show("Room is not available");
                    }

                    //MessageBox.Show(roomAvailability);

                    if (roomAvailability == "yes")
                    {

                        string addQuery = "insert into patients(patient_name, gender, age, diagnosis, doctor_name, ward_no, bill, admit_date) values('" + txtName.Text + "','" + cmbGender.Text + "'," + txtAge.Text + ",'" + txtDgn.Text + "','" + txtDocName.Text + "', " + txtWardNo.Text + "," + txtBill.Text + ", CONVERT(DATE, '" + dtpAdmission.Value.Date.ToString("yyyy-MM-dd") + "'))";
                        // '2019-02-01'

                        //MessageBox.Show(addQuery);
                        DataAccess access2 = new DataAccess();
                        access2.Sqlcom = new SqlCommand(addQuery, access2.Sqlcon);

                        //DataSet set = access.ExecuteQuery(addQuery);
                        int rowsUpdated = access2.Sqlcom.ExecuteNonQuery();
                        if (rowsUpdated == 1)
                        {
                            string lastPatientIdQuery = "select top 1 patient_id from patients order by patient_id desc";

                            access = new DataAccess();
                            access.Sqlcom = new SqlCommand(lastPatientIdQuery, access.Sqlcon);
                            access.Sda = new SqlDataAdapter(access.Sqlcom);
                            table = new DataTable();
                            access.Sda.Fill(table);

                            string lastPatientId = table.Rows[0][0].ToString();

                            string roomValidityQuery = "update rooms set pat_id = " + lastPatientId + ", availability = 'no' where room_id  =" + txtWardNo.Text;
                            access.Sqlcom = new SqlCommand(roomValidityQuery, access.Sqlcon);
                            access.Sqlcom.ExecuteNonQuery();
                            MessageBox.Show("Successful");

                        }
                        else
                        {
                            MessageBox.Show("Failed");
                        }

                        //string updateRoomQuery = "update rooms set "
                    }
                    else
                    {
                        MessageBox.Show("Ward number " + txtWardNo.Text + " is not available right now!");
                    }

                    //MessageBox.Show(addQuery);
                    /*

                    */
                }

                catch (IndexOutOfRangeException IE)
                {
                    MessageBox.Show("Room does not exist!");
                }
            
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
        }
    }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertPatient_Load(object sender, EventArgs e)
        {

        }

        public void LoadName(string doctorName)
        {
            txtDocName.Text = doctorName; 
        }
    }
}
