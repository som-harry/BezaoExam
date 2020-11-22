using RecruitingProject.Entity;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingProject.Interface
{
    public interface IAdmin
    {
        List<ApplyForJob> GetSubmittedApplication();
        List<Job> GetAllJobs();
        List<Applicant> GetAllApplicantfortheJob(int id);
        int AcceptedRequest();
        int RejectedtedRequest();
        int PendingRequest();
        List<Applicant> GetAllApplicants();
        void display(int id);

    }
}
