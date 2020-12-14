using RecruitingProject.Entity;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingProject.Interface
{
    public interface IApplicant
    {
        void CreateApplicant(ApplicantFormViewModel model, string userid);
        EditFormViewModel Edit();
        List<Job> UserDashboard();
        void UpdateApplicant(EditFormViewModel model);
        Applicant Accept(int id);
        Applicant Reject(int id);
    }
}
