using BusinessLayer;
using Shared.Interfaces.Business;
using Shared.Models;
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

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly IStudentBusiness studentBusiness;
        private string emailRegex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public Form1(IStudentBusiness _studentBusiness)
        {
            this.studentBusiness = _studentBusiness;
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
            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                !string.IsNullOrEmpty(textBoxIndexNumber.Text) &&
                !string.IsNullOrEmpty(textBoxAverageMark.Text) &&
                textBoxName.Text.Length <= 100 &&
                Regex.Match(textBoxEmail.Text, emailRegex).Success)
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
            } else
            {
                // MessageBox.Show("Morate popuniti sva polja!");
                label4.Text = "Nesto nije validno!";
            }
                
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
           //Validation();
        }

        private void textBoxIndexNumber_TextChanged(object sender, EventArgs e)
        {
            //Validation();
        }

        private void textBoxAverageMark_TextChanged(object sender, EventArgs e)
        {
            //Validation();
        }

        private void Validation()
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                !string.IsNullOrEmpty(textBoxIndexNumber.Text) &&
                !string.IsNullOrEmpty(textBoxAverageMark.Text))
            {
                buttonInsertStudent.Enabled = true;
            } 
            else
            {
                buttonInsertStudent.Enabled = false;
            }
        }
    }
}
