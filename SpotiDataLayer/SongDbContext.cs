using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiDataLayer 
{
    public class SongDbContext : DbContext
    {

        //properties

        public SongDbContext(string Path): base(Path) {
            //Employees = ReadFromDb<Employee>(Path + typeof(Employee).Name.ToString() + ".csv");
            //MergerData();
        }
        private void MergerData()
        {
            //foreach (var employee in Employees)
            //{
            //    JobContract? jobsContracts =
            //        JobsContracts.FirstOrDefault(x => x.EmployeeId == employee.Id);

            //    employee.JobContract = jobsContracts!;

            //    if (jobsContracts is not null)
            //        jobsContracts.Employee = employee;
            //}

            //foreach (var job in Jobs)
            //{
            //    JobContract? jobsContracts =
            //        JobsContracts.FirstOrDefault(x => x.JobId == job.Id);

            //    job.JobContract = jobsContracts;
            //    if (jobsContracts is not null)
            //        jobsContracts.Jobs = job;
            //}
        }
    }
}
