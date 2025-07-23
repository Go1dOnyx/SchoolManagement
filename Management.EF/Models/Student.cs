using System.ComponentModel.DataAnnotations;

namespace Management.EF.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        public Guid SchoolId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateofBirth { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public int Grade { get; set; }

        //Navigational Property for Courses
        public School School { get; set; }
        public List<Courses> Courses { get; set; }

        public Student(Guid id, Guid schoolId, School school, string first, string middle, string last, DateTime birth, string address, int grade, List<Courses> courses)
        {
            StudentId = id;
            SchoolId = schoolId;
            School = school;
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            DateofBirth = birth;
            Address = address;
            Grade = grade;
            Courses = courses;
        }
        public Student()
        {

        }
    }
}
