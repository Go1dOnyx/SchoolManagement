using System.ComponentModel.DataAnnotations;

namespace Management.EF.Models
{
    public class Courses
    {
        [Key]
        public Guid CourseId { get; set; }

        [Required]
        public Guid SchoolId { get; set; }

        [Required]
        public string? CourseName { get; set; }

        [Required]
        public string? CourseDescription { get; set; }

        [Required]
        public string? Teacher { get; set; }

        //Navigational Property
        public School School { get; set; }
        public List<Student> Students { get; set; }
        public Courses(Guid id, Guid schoolID, School school, List<Student> students, string name, string description, string teacher)
        {
            CourseId = id;
            SchoolId = schoolID;
            School = school;
            CourseName = name;
            CourseDescription = description;
            Teacher = teacher;
            Students = students;
        }

        public Courses() { }
    }
}
