using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.EmployeeModule
{
    public class EmploymentHistoryService
    {

        private readonly IRepository<EmploymentHistory> _repository;
        public EmploymentHistoryService(IRepository<EmploymentHistory> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmploymentHistory>> GetEmploymentHistory()
        {
            var eeHistDbSet = await _repository.GetDbSet();
            var ee = eeHistDbSet
                .Include(x => x.Department)
                .Include(x => x.Team)
                .Include(x => x.Position)
                .Include(x => x.Employee);

            return ee;
        }

        public async Task<bool> SaveChangesAsync(Guid userId)
        {
            return await _repository.SaveChangesAsync(userId);
        }

        public async Task AddEmploymentHistory(Employee ee, Position position = null, Department dept = null, Team team = null)
        {
            EmploymentHistory employmentHistory = null;


            bool hasChanges = false;

            if (ee != null)
            {
                employmentHistory = new EmploymentHistory();

                employmentHistory.EmployeeId = ee.Id;
                employmentHistory.EffectivityDate = DateTime.Now;

                if (position != null)
                {

                    if (ee.Position != null && ee.Position.Id != position.Id)
                    {
                        hasChanges = true;

                        ee.PositionId = position.Id;
                        ee.Position = position;
                        employmentHistory.Position = position.Name;

                    }
                    else if (ee.Position == null)
                    {
                        hasChanges = true;

                        ee.PositionId = position.Id;
                        ee.Position = position;
                        employmentHistory.Position = position.Name;
                    }



                }

                if (dept != null)
                {


/*
                    if (ee.Department != null && ee.Department.Id != dept.Id)
                    {
                        hasChanges = true;
                        ee.DepartmentId = dept.Id;
                        ee.Department = dept;
                        employmentHistory.Department = dept.Name;
                    }
                    else if (ee.Department == null)
                    {
                        hasChanges = true;
                        ee.DepartmentId = dept.Id;
                        ee.Department = dept;
                        employmentHistory.Department = dept.Name;
                    }*/


                }

                if (team != null)
                {



                    /*if (ee.Team != null && ee.Team.Id != team.Id)
                    {
                        hasChanges = true;

                        ee.TeamId = team.Id;
                        ee.Team = team;

                        employmentHistory.Team = team.Name;
                    }
                    else if (ee.Team == null)
                    {

                        hasChanges = true;

                        ee.TeamId = team.Id;
                        ee.Team = team;

                        employmentHistory.Team = team.Name;
                    }
*/
                }

                if (hasChanges)
                {
                    await _repository.Add(employmentHistory);
                }


            }
            else
            {
                throw new Exception("Employee object cannot be null in adding Employment History");
            }

        }
    }
}
