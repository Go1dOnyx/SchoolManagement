using System;
using System.Collections.Generic;

namespace Management.EF.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateofBirth { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string GradeLevel { get; set; } = null!;
        public Student(int studentId, int districtId, string firstName, string lastName, DateTime dateofBirth, string streetAddress, string gradeLevel)
        {
            StudentId=studentId;
            DistrictId=districtId;
            FirstName=firstName;
            LastName=lastName;
            DateofBirth=dateofBirth;
            StreetAddress=streetAddress;
            GradeLevel=gradeLevel;
        }
        public Student()
        {

        }
    }
}
