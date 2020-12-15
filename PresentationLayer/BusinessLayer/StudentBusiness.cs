using DataAccessLayer;
using Shared.Interfaces.Business;
using Shared.Interfaces.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository _studentRepository)
        {
            this.studentRepository = _studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return this.studentRepository.GetAllStudents();
        }

        public bool InsertStudent(Student s)
        {
            if (this.studentRepository.InsertStudent(s) > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetStudentsGTAvgMark(decimal averageMark)
        {
            return this.studentRepository.GetAllStudents()
                .Where(s => s.AverageMark > averageMark).ToList();
        }

        public bool CanTakeExam(Student student, string examName)
        {
            Faculty faculty = new Faculty();
            return faculty.CanTakeExam(student, examName);
        }

        public List<Student> SortStudents(List<Student> list, string sortType)
        {
            StudentSortedList studentSortedList = new StudentSortedList();
            studentSortedList.List = list;

            switch (sortType)
            {
                case "name":
                    studentSortedList.SetSortStrategy(new ByName());
                    break;
                case "indexNumber":
                    studentSortedList.SetSortStrategy(new ByIndexNumber());
                    break;
                default:
                    break;
            }

            studentSortedList.Sort();
            return studentSortedList.List;
        }
    }
}
