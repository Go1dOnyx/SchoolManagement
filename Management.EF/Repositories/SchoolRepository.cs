using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.EF.Models;
using Management.EF.Context;

namespace Management.EF.Repositories
{
    public class SchoolRepository
    {
        private SchoolManagementContext _dbContext;

        public SchoolRepository(SchoolManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(School district)
        {

            _dbContext.Add(district);
            _dbContext.SaveChanges();

            return district.DistrictId;
        }

        public int Update(School district)
        {
            School existingDistrict = _dbContext.Schools.Find(district.DistrictId)!;

            existingDistrict.SchoolName = district.SchoolName;
            existingDistrict.Location = district.Location;
            existingDistrict.Administrator = district.Administrator;
            existingDistrict.PhoneNumber = district.PhoneNumber;
            existingDistrict.TotalStudents = district.TotalStudents;

            _dbContext.SaveChanges();

            return existingDistrict.DistrictId;
        }

        public bool Delete(int districtID)
        {
            School district = _dbContext.Schools.Find(districtID)!;
            _dbContext.Remove(district);
            _dbContext.SaveChanges();

            return true;
        }

        public List<School> GetAllSchools()
        {
            List<School> schoolList = _dbContext.Schools.ToList();

            return schoolList;
        }

        public School GetSchoolByID(int districtID)
        {
            School district = _dbContext.Schools.Find(districtID)!;

            return district;
        }
    }
}
