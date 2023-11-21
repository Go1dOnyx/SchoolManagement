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
        //Establising a connection to database with entities classes
        private SchoolManagementContext _dbContext; 

        public SchoolRepository(SchoolManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Creates a new district and adds to database
        public int Create(School district)
        {

            _dbContext.Add(district);
            _dbContext.SaveChanges();

            return district.DistrictId;
        }
        //Updates a specific school by district code 
        public int Update(School district)
        {
            School existingDistrict = _dbContext.Schools.Find(district.DistrictId)!;

            //Updates all the row in that column selected by its ID ^
            existingDistrict.SchoolName = district.SchoolName;
            existingDistrict.Location = district.Location;
            existingDistrict.Administrator = district.Administrator;
            existingDistrict.PhoneNumber = district.PhoneNumber;
            existingDistrict.TotalStudents = district.TotalStudents;

            _dbContext.SaveChanges();

            return existingDistrict.DistrictId;
        }
        //Removes school by district code from database
        public bool Delete(int districtID)
        {
            //Selects specific district by ID
            School district = _dbContext.Schools.Find(districtID)!;
            _dbContext.Remove(district); //removes all its data
            _dbContext.SaveChanges();

            return true;
        }
        //Gets a list all the schools
        public List<School> GetAllSchools()
        { 
            List<School> schoolList = _dbContext.Schools.ToList(); 

            return schoolList;
        }
        //Select a specific school by district code
        public School GetSchoolByID(int districtID)
        {
            School district = _dbContext.Schools.Find(districtID)!;

            return district;
        }
    }
}
