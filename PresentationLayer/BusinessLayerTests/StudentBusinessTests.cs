using System;
using System.Collections.Generic;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Interfaces.Repository;
using Shared.Models;

namespace BusinessLayerTests
{
    [TestClass]
    public class StudentBusinessTests
    {
        private Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
        private Student student = new Student
        {
            Name = "Nemanja Vicovic",
            IndexNumber = "142/2011",
            AverageMark = 8.5m
        };
        private List<Student> listOfStudents = new List<Student>();
        private StudentBusiness studentBusiness;

        public StudentBusinessTests()
        {
            listOfStudents.Add(student);
            listOfStudents.Add(new Student
            {
                Name = "Mladen Janjic",
                IndexNumber = "150/2004",
                AverageMark = 9.5m
            });
            listOfStudents.Add(new Student
            {
                Name = "Nikola Ristanovic",
                IndexNumber = "500/2017",
                AverageMark = 7.5m
            });
        }

        [TestMethod]
        public void IsStudentInserted()
        {
            // Arrange
            mockStudentRepository.Setup(x => x.InsertStudent(student)).Returns(1);
            this.studentBusiness = new StudentBusiness(mockStudentRepository.Object);

            // Act
            var result = studentBusiness.InsertStudent(student);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AreReturnedStudentsOverAvgMark()
        {
            // Arrange
            mockStudentRepository.Setup(x => x.GetAllStudents()).Returns(listOfStudents);
            this.studentBusiness = new StudentBusiness(mockStudentRepository.Object);

            // Act
            var result = studentBusiness.GetStudentsGTAvgMark(8);

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
