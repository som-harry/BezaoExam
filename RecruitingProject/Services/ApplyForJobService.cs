using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNet.Identity;
using RecruitingProject.Entity;
using RecruitingProject.Infrastructure;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using static System.Web.HttpContext;

namespace RecruitingProject.Services
{
    [Authorize(Roles ="ADMIN")]
    public class ApplyForJobService : IApplyForJob
    {
        private CloudinaryInitialization _cloudinaryInitialization = new CloudinaryInitialization();
        ContextService dbContext;
        public ApplyForJobService(ContextService _context)
        {
            dbContext = _context;
        }
        public ApplyForJob SubmitResume(ApplyFormViewModel model)
        {
            //setting up the file
            byte[] uploadedFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var job = dbContext.context.Jobs.FirstOrDefault(job1 => job1.Id == model.JobId);
            var userId = Current.User.Identity.GetUserId();
            var user = dbContext.context.Applicants.SingleOrDefault(a => a.User.Id == userId);

            //check if the job is null and throw appropriate error

            ApplyForJob applyForJob = new ApplyForJob()
            {
                JobRole = model.JobRole,
                Resume =uploadedFile,
                Job = job,
                DateApply = DateTime.Now,
                Applicant = user,
                JobId = job.Id,
                WhatYourgreatestAchieviement = model.WhatYourgreatestAchieviement
            };
            dbContext.context.ApplyForJobs.Add(applyForJob);
            dbContext.context.SaveChanges();

            return applyForJob;
        }
    }
}