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
        ContextService dbContext;
        public ApplyForJobService(ContextService _context)
        {
            dbContext = _context;
        }

        public string SaveResume(ApplyFormViewModel model)
        {
            //change file name
            var filename = Path.GetFileNameWithoutExtension(model.File.FileName);
           
            var extention = Path.GetExtension(model.File.FileName);

            filename = filename + DateTime.Now.ToString("yymmssfff") + extention;

            //adding the new file name to the file, file path
            string filePath = "~/Document/" + filename;

            filename = Path.Combine(HttpContext.Current.Server.MapPath("~/Document/"), filename);

            //saving the file in the folder
            model.File.SaveAs(filename);

            return filePath;
        }
        public ApplyForJob SubmitResume(ApplyFormViewModel model)
        {
            var job = dbContext.context.Jobs.FirstOrDefault(job1 => job1.Id == model.JobId);
            var userId = Current.User.Identity.GetUserId();
            var user = dbContext.context.Applicants.SingleOrDefault(a => a.User.Id == userId);

            //check if the job is null 
          

                ApplyForJob applyForJob = new ApplyForJob()
                {
                    JobRole = model.JobRole,
                    UploadResume = SaveResume(model),
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