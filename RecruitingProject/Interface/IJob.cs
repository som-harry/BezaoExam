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
        List<Job> GetAllJobs();
        Job Details(int id);
    }
}
