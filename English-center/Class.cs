using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace English_center
{
    public partial class Class : Form
    {
        private string selectedID;
        private ClassController classController = new ClassController();
        public Class()
        {
            InitializeComponent();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = classController.getId();
            string CourseName = txtCourse.Text;
            string teachername = txtteachername.Text;
            string quantity = txtquantity.Text;
            string status=txtstatus.Text;
            txtInformation.Enabled = true;
            txtCourse.Text = "";
            txtquantity.Text = "";
            txtstatus.Text = "";
            txtteachername.Text = "";
            txtCourse.Focus();
            btnSave.Enabled = true;
            if (CourseName == "" || quantity == "" || status == "" || teachername=="")
            {
                MessageBox.Show("Please fill full the information");
            }
            else
            {
            
                    classController.AddClass(id, CourseName, teachername, status,quantity);

                    dataGridView1.DataSource = classController.GetClasses();
                    MessageBox.Show("Add Successfully");
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa Lop Hoc", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    classController.DeleteClass(selectedID);

                    dataGridView1.DataSource = classController.GetClasses();
                }
                else
                {
                    MessageBox.Show("Please select a account to delete.");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtCourse.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtstatus.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtstatus.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtquantity.Text= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Class_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = classController.GetClasses();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = classController.GetClasses();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
