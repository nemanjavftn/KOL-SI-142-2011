using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Faculty
    {
        private PayDesk payDesk = new PayDesk();
        private Exam exam = new Exam();

        public bool CanTakeExam(Student student, string examName)
        {
            bool result = true;

            if (!payDesk.IsExamPayed(student, examName))
            {
                result = false;
            }

            if (!exam.IsPrerequisiteExamPassed(student, examName))
            {
                result = false;
            }

            return result;
        }
    }

    class PayDesk
    {
        public bool IsExamPayed(Student student, string examName)
        {
            // ovde napisati code koji proverava da li je student platio ispit
            return true;
        }
    }

    class Exam
    {
        public bool IsPrerequisiteExamPassed(Student student, string examName)
        {
            // ovde napisati code koji proverava da li je student polozio uslovni ispit
            return true;
        }
    }
}
