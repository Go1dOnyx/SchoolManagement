using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.EF.Models
{
    public class School
    {
        [Key]
        public Guid SchoolId { get; set; }

        [Required]
        public string SchoolName { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        [Required]
        public string Administrator { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        //Navigational Property for students
        public List<Student> Students { get; set; }
        public List<Courses> Courses { get; set; }

        //Computed Property - Not stored in the database
        [NotMapped]
        public int TotalStudentCount => Students?.Count ?? 0;
        public School(Guid id, string name, string location, string administrator, string phone, List<Student> students, List<Courses> courses)
        {
            SchoolId = id;
            SchoolName = name;
            Location = location;
            Administrator = administrator;
            Phone = phone;
            Students = students;
            Courses = courses;
        }
        public School()
        {

        }
    }
}
