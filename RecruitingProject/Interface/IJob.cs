using RecruitingProject.Entity;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingProject.Interface
{
    public interface IJob
    {
        void CreateJob(JobFormViewModel model);
        void UpdateJob(JobEditFormViewModel model, int id);
        JobEditFormViewModel Edit(int id);
        IEnumerable<Job> GetParticularJobs(int id);
        List<Job> GetThreeJobs();
        List<Job> GetAllJobs();
        Job Details(int id);
    }
}
