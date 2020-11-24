using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly StudentBusiness studentBusiness;
        public Form1()
        {
            this.studentBusiness = new StudentBusiness();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            List<Student> students = this.studentBusiness.GetAllStudents();
            listBoxStudents.Items.Clear();

            foreach(Student s in students)
            {
                listBoxStudents.Items.Add(s.Id + ". " + s.Name + "(" + s.IndexNumber + ") - " +
                    s.AverageMark);
            }
        }

        private void buttonInsertStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Name = textBoxName.Text;
            s.IndexNumber = textBoxIndexNumber.Text;
            s.AverageMark = Convert.ToDecimal(textBoxAverageMark.Text);

            if (this.studentBusiness.InsertStudent(s))
            {
                RefreshData();
                textBoxName.Text = "";
                textBoxIndexNumber.Text = "";
                textBoxAverageMark.Text = "";
            }
            else
            {
                MessageBox.Show("Greska!");
            }
        }
    }
}
