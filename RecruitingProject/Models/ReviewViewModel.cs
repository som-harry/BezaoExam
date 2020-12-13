using RecruitingProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class ReviewViewModel
    {
        public Applicant Applicants { get; set; }
        public ApplyForJob ApplyForJobs { get; set; }
        public Job Jobs { get; set; }
    }
}