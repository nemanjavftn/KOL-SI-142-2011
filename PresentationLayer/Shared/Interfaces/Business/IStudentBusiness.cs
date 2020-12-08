using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Business
{
    public interface IStudentBusiness
    {
        List<Student> GetAllStudents();
        bool InsertStudent(Student s);
        List<Student> GetStudentsGTAvgMark(decimal averageMark);
    }
}
