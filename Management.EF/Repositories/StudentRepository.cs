using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.EF.Context;
using Management.EF.Models;

namespace Management.EF.Repositories
{
    public class StudentRepository
    {
        private SchoolManagementContext _dbContext;

        public StudentRepository(SchoolManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Student student)
        {

            _dbContext.Add(student);
            _dbContext.SaveChanges();

            return student.StudentId;
        }

        public int Update(Student student)
        {
            Student existingStudent = _dbContext.Students.Find(student.StudentId)!;

            existingStudent.DistrictId = student.DistrictId;
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DateofBirth = student.DateofBirth;
            existingStudent.StreetAddress = student.StreetAddress;
            existingStudent.GradeLevel = student.GradeLevel;

            _dbContext.SaveChanges();

            return existingStudent.StudentId;
        }

        public bool Delete(int studentID)
        {
            Student student = _dbContext.Students.Find(studentID)!;
            _dbContext.Remove(student);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = _dbContext.Students.ToList();

            return studentList;
        }

        public Student GetStudentByID(int studentID)
        {
            Student student = _dbContext.Students.Find(studentID)!;

            return student;
        }
    }
}

