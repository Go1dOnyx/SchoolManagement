using System;
using System.Collections.Generic;

namespace Management.EF.Models
{
    public partial class School
    {
        public int DistrictId { get; set; }
        public string SchoolName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Administrator { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int TotalStudents { get; set; }

        public School(int districtId, string schoolName, string location, string administrator, string phoneNumber, int totalStudents)
        {
            DistrictId=districtId;
            SchoolName=schoolName;
            Location=location;
            Administrator=administrator;
            PhoneNumber=phoneNumber;
            TotalStudents=totalStudents;
        }
        public School()
        {

        }
    }
}
