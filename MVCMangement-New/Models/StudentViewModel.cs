using Management.EF.Context;
using Management.EF.Models;
using Management.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MVCMangement_New.Models
{
    public class StudentViewModel
    {
        private StudentRepository _repo;

        public List<Student> StudentList { get; set; }

        public Student CurrentStudent { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; } = "";

        public StudentViewModel(SchoolManagementContext context)
        {
            _repo = new StudentRepository(context);
            StudentList = GetAllStudent();
            CurrentStudent = StudentList.FirstOrDefault() !;
        }

        public StudentViewModel(SchoolManagementContext context, int studentId)
        {
            _repo = new StudentRepository(context);
            StudentList = GetAllStudent();

            if (studentId > 0)
            {
                CurrentStudent = GetStudent(studentId);
            }
            else
            {
                CurrentStudent = new Student();
            }
        }

        public void SaveStudent(Student student)
        {
            if (student.StudentId > 0)
            {
                _repo.Update(student);
            }
            else
            {
                student.StudentId = _repo.Create(student);
            }

            StudentList = GetAllStudent();
            CurrentStudent = GetStudent(student.StudentId);
        }

        public void RemoveStudent(int studentID)
        {
            _repo.Delete(studentID);
            StudentList = GetAllStudent();
            CurrentStudent = StudentList.FirstOrDefault() !;
        }

        public List<Student> GetAllStudent()
        {
            return _repo.GetAllStudents();
        }

        public Student GetStudent(int studentId)
        {
            return _repo.GetStudentByID(studentId);
        }
    }
}
