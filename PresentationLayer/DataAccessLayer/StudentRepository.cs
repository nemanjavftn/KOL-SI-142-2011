using Shared.Interfaces.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            List<Student> results = new List<Student>();

            SqlDataReader sqlDataReader = DBConnection.GetData("SELECT * FROM Students");

            while (sqlDataReader.Read())
            {
                Student s = new Student();
                s.Id = sqlDataReader.GetInt32(0);
                s.Name = sqlDataReader.GetString(1);
                s.IndexNumber = sqlDataReader.GetString(2);
                s.AverageMark = sqlDataReader.GetDecimal(3);

                results.Add(s);
            }

            DBConnection.CloseConnection();

            return results;
        }

        public int InsertStudent(Student s)
        {
            var result = DBConnection.EditData(string.Format("INSERT INTO Students VALUES ('{0}', '{1}', {2})",
                    s.Name, s.IndexNumber, s.AverageMark));
            DBConnection.CloseConnection();

            return result;
        }
    }
}
