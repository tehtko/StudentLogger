﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLoggerLibrary;
using Microsoft.EntityFrameworkCore;

namespace StudentLogger
{
    public partial class StudentLogger : Form
    {
        private readonly AgeRange range = new();
        private readonly Branches branches = new();

        public StudentLogger()
        {
            InitializeComponent();

            cmbAge.DataSource = AgeRange.ageRangeList;
            cmbBranch.DataSource = Branches.branchesList;

            using (var context = new StudentContext())
            {
                dgvStudents.DataSource = context.Students.ToList();
            }
        }

        public void RefreshBinding()
        {
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using StudentContext context = new();

            context.Add(new Student { FirstName = txtFirstName.Text, LastName = txtLastName.Text, Age = Convert.ToInt32(cmbAge.SelectedItem), Branch = cmbBranch.SelectedItem.ToString() });
            context.SaveChanges();

            dgvStudents.DataSource = context.Students.ToList();

            RefreshBinding();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }
    }
}