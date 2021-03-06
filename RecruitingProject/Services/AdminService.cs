﻿using RecruitingProject.Entity;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using static System.Web.HttpContext;

namespace RecruitingProject.Services
{
    public class AdminService:IAdmin
    {
        ContextService dbContext;

        public AdminService(ContextService _context)
        {
            dbContext = _context;
        }

        public List<ApplyForJob> GetSubmittedApplication()
        {
            return dbContext.context.ApplyForJobs.Include(a => a.Applicant).Include(j => j.Job).ToList();
        }

        public List<Job> GetAllJobs()
        {
            return dbContext.context.Jobs.ToList();
        }

        public List<Applicant> GetAllApplicantfortheJob(int id)
        {
            //get all submission where their id matches the job id
            var applyForJobs = dbContext.context.ApplyForJobs.ToList().Where(a => a.JobId == id );
            
            //find all the submission made by an applicant then save it in a new list of applicant
            List<Applicant> applicants = new List<Applicant>();
            var applicant = dbContext.context.Applicants.ToList();
            foreach (var applyforjob in applyForJobs)
            {
               var allapply = applicant.Find(a => a.id == applyforjob.ApplicantId);
                applicants.Add(allapply);
              
            }

            return applicants;

        }

        public int AcceptedRequest()
        {
            //using extension linq query
            var count = dbContext.context.Applicants
                .Where(a => a.ApplicationStatus == ApplicationStatus.accept)
                .Select(a => a)
                .Count();

            return count;
        }
        public int RejectedtedRequest()
        {
            var count = dbContext.context.Applicants
                .Where(a => a.ApplicationStatus == ApplicationStatus.reject)
                .Select(a => a)
                .Count();

            return count;
        }

        public int PendingRequest()
        {
            var count = dbContext.context.Applicants
                .Where(a => a.ApplicationStatus == ApplicationStatus.pending)
                .Select(a => a)
                .Count();

            return count;
        }
        public ReviewViewModel Details(int id)
        {

            var viewModel = new ReviewViewModel
            {
                Applicants = dbContext.context.Applicants.SingleOrDefault(a => a.id == id),
                ApplyForJobs = dbContext.context.ApplyForJobs.SingleOrDefault(a => a.Id == id),
                Jobs = dbContext.context.Jobs.SingleOrDefault(a => a.Id == id)
            };

            return viewModel;
        }
        public List<Applicant> GetAllPendingRequest()
        {
            return dbContext.context.Applicants.Where(a => a.ApplicationStatus == ApplicationStatus.pending).ToList();
        }
        public List<Applicant> GetAllAcceptedRequest()
        {
            return dbContext.context.Applicants.Where(a => a.ApplicationStatus == ApplicationStatus.accept).ToList();
        }
        public List<Applicant> GetAllRejectedRequest()
        {
            return dbContext.context.Applicants.Where(a => a.ApplicationStatus == ApplicationStatus.reject).ToList();
        }

    }
}