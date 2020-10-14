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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LoadSearchBox();
            try
            {
                DataAccess access = new DataAccess();
                string query = "SELECT * FROM Patients";
                access.Sqlcom = new SqlCommand(query, access.Sqlcon);
                access.Sda = new SqlDataAdapter(access.Sqlcom);
                DataTable dt = new DataTable();
                access.Sda.Fill(dt);
                dataGridViewMain.DataSource = dt;
                
            }

            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocReference docRef = new DocReference();
            docRef.ShowDialog();
            //InsertPatient p = new InsertPatient();
            //p.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int countOfRows = dataGridViewMain.SelectedRows.Count;
                if(countOfRows==1)
                {
                    int selectedRowIndex = dataGridViewMain.SelectedRows[0].Index;
                    DataGridViewRow SelectedRow = dataGridViewMain.Rows[selectedRowIndex];
                    UpdatePatient up = new UpdatePatient();
                    up.LoadData(SelectedRow);
                    up.ShowDialog();
                  
   
                }

            }
            catch(Exception o)
            {

            }
        }

        private void btnShowDoc_Click(object sender, EventArgs e)
        {
            this.HideSearchBox();
            try
            {
                DataAccess access = new DataAccess();
                string query = "SELECT * FROM Doctors";
                access.Sqlcom = new SqlCommand(query, access.Sqlcon);
                access.Sda = new SqlDataAdapter(access.Sqlcom);
                DataTable dt = new DataTable();
                access.Sda.Fill(dt);
                dataGridViewMain.DataSource = dt;

            }

            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            AddDoctor addDoc = new AddDoctor();
            addDoc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int countOfRows = dataGridViewMain.SelectedRows.Count;
                if (countOfRows == 1)
                {
                    int selectedRowIndex = dataGridViewMain.SelectedRows[0].Index;
                    DataGridViewRow SelectedRow = dataGridViewMain.Rows[selectedRowIndex];
                    UpdateDoctor updateDoc = new UpdateDoctor();
                    updateDoc.LoadData(SelectedRow);
                    
                    updateDoc.ShowDialog();


                }

            }
            catch (Exception o)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int countOfRows = dataGridViewMain.SelectedRows.Count;
            if (countOfRows == 1)
            {
                int selectedRowIndex = dataGridViewMain.SelectedRows[0].Index;
                DataGridViewRow SelectedRow = dataGridViewMain.Rows[selectedRowIndex];
                DeleteConfirmP Del = new DeleteConfirmP();
                Del.LoadData(SelectedRow); 
                Del.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("No rows were selected");
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int countOfRows = dataGridViewMain.SelectedRows.Count;
            if (countOfRows == 1)
            {
                int selectedRowIndex = dataGridViewMain.SelectedRows[0].Index;
                DataGridViewRow SelectedRow = dataGridViewMain.Rows[selectedRowIndex];
                DeleteConfirmD Del = new DeleteConfirmD();
                Del.LoadData(SelectedRow);
                Del.ShowDialog();

            }
            else
            {
                MessageBox.Show("No rows were selected");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridViewMain.SelectedRows[0].Index;
            DataGridViewRow SelectedRow = dataGridViewMain.Rows[selectedRowIndex];

            DischargeConfirm discharge = new DischargeConfirm();
            discharge.LoadData(SelectedRow);
            discharge.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchBoxQuery = "select * from patients where patient_name like '"+txtSearch.Text+"%'";
            DataAccess access = new DataAccess();
            access.Sqlcom = new SqlCommand(searchBoxQuery, access.Sqlcon);
            access.Sda = new SqlDataAdapter(access.Sqlcom);
            DataTable table = new DataTable();
            access.Sda.Fill(table);
            dataGridViewMain.DataSource = table;
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess access = new DataAccess();
                string query = "SELECT * FROM rooms";
                access.Sqlcom = new SqlCommand(query, access.Sqlcon);
                access.Sda = new SqlDataAdapter(access.Sqlcom);
                DataTable dt = new DataTable();
                access.Sda.Fill(dt);
                dataGridViewMain.DataSource = dt;

            }

            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
    }
}
