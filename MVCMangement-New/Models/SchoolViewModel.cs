using Management.EF.Context;
using Management.EF.Models;
using Management.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MVCMangement_New.Models
{
    public class SchoolViewModel
    {
        private SchoolRepository _repo; 

        public List<School> SchoolList { get; set; }

        public School CurrentSchool { get; set; }// = new School();

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; } = "";

        public SchoolViewModel(SchoolManagementContext context)
        {
            _repo = new SchoolRepository(context);
            SchoolList = GetAllSchools();
            CurrentSchool = SchoolList.FirstOrDefault() !;
        }

        public SchoolViewModel(SchoolManagementContext context, int districtId)
        {
            _repo = new SchoolRepository(context);
            SchoolList = GetAllSchools();

            if (districtId > 0)
            {
                CurrentSchool = GetSchool(districtId);
            }
            else
            {
                CurrentSchool = new School();
            }
        }

        public void SaveSchool(School district)
        {
            if (district.DistrictId > 0)
            {
                _repo.Update(district);
            }
            else
            {
                district.DistrictId = _repo.Create(district);
            }

            SchoolList = GetAllSchools();
            CurrentSchool = GetSchool(district.DistrictId);
        }

        public void RemoveSchool(int districtID)
        {
            _repo.Delete(districtID);
            SchoolList = GetAllSchools();
            CurrentSchool = SchoolList.FirstOrDefault() !;
        }

        public List<School> GetAllSchools()
        {
            return _repo.GetAllSchools();
        }

        public School GetSchool(int districtId)
        {
            return _repo.GetSchoolByID(districtId);
        }
    }
}
