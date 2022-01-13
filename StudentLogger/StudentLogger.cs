using System;
using System.Linq;
using System.Windows.Forms;
using StudentLoggerLibrary;
using Microsoft.EntityFrameworkCore;

namespace StudentLogger
{
    public partial class StudentLogger : Form
    {
        //Instatiate these classes to load their respective data
        private readonly AgeRange range = new();
        private readonly Branches branches = new();

        public StudentLogger()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (StudentContext context = new())
            {
                context.Add(new Student { FirstName = txtFirstName.Text, LastName = txtLastName.Text, Age = Convert.ToInt32(cmbAge.SelectedItem), Branch = cmbBranch.SelectedItem.ToString() });
                context.SaveChanges();

                dgvStudents.DataSource = context.Students.ToList();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = null;
            txtLastName.Text = null;
        }

        private void StudentLogger_Load(object sender, EventArgs e)
        {
            //Set the DataSource for the Gridview and ComboBoxes

            cmbAge.DataSource = AgeRange.ageRangeList;
            cmbBranch.DataSource = Branches.branchesList;

            using (StudentContext context = new())
            {
                dgvStudents.DataSource = context.Students.ToList();

                //Styling the Gridview
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStudents.Columns[0].Width = 50;
                dgvStudents.Columns[3].Width = 50;
            }
        }

        private void btnDelId_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(txtDelID.Text);

            using (StudentContext context = new())
            {
                //Finds the Student to remove by PrimaryKey(id) given by the user
                context.Remove(context.Students.Find(_id));
                context.SaveChanges();

                dgvStudents.DataSource = context.Students.ToList();
            }

            txtDelID.Text = "";
        }

        private void btnDelName_Click(object sender, EventArgs e)
        { 
            using (StudentContext context = new())
            {
                //Finds the Student to remove by matching the Student.LastName and Last Name given by the user
                context.Remove(context.Students.Where(x => x.LastName == txtDelName.Text).FirstOrDefault());
                context.SaveChanges();

                dgvStudents.DataSource = context.Students.ToList();
            }

            txtDelName.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(txtId.Text);
            int _age = Convert.ToInt32(txtUpdateAge.Text);

            using (StudentContext context = new())
            {
                //Update the Student.Age that matches the given Student.Id
                context.Students.Find(_id).Age = _age;
                context.SaveChanges();

                dgvStudents.DataSource = context.Students.ToList();
            }

            txtId.Text = "";
            txtUpdateAge.Text = "";
        }
    }
}
