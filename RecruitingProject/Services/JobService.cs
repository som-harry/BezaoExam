using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RecruitingProject.Entity;
using RecruitingProject.Infrastructure;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecruitingProject.Services
{
    public class JobService : IJob
    {
        ContextService dbContext;
        private CloudinaryInitialization _cloudinaryInitialization = new CloudinaryInitialization();
        public JobService(ContextService _context)
        {
            dbContext = _context;
        }

        public void CreateJob(JobFormViewModel model)
        {
           //setting up the image
            var cloudinary = _cloudinaryInitialization.initialize();

            var image = new ImageUploadParams()
            {
                File = new FileDescription(model.File.FileName, model.File.InputStream)
            };

            var upload = cloudinary.Upload(image);
            Job newjob = new Job()
            {
               Amount = model.Amount,
               JobDeadLine = model.JobDeadLine,
               JobName = model.JobName,
               AboutEmployer = model.AboutEmployer,
               EmployerName = model.EmployerName,
               MobileNumber = model.MobileNumber,
               Email = model.Email,
               JobDescription = model.JobDescription,
               OfficeLine = model.OfficeLine,
               Website = model.Website,
               ImageLocation = upload.SecureUrl.AbsoluteUri,
            };
            dbContext.context.Jobs.Add(newjob);
            dbContext.context.SaveChanges();
        }

        public Job Details(int id)
        {
            var job = dbContext.context.Jobs.SingleOrDefault(x => x.Id == id);

            if (job == null)
                throw new Exception("Error no job found");

            return job;
        }

        public List<Job> GetAllJobs()
        {
            return dbContext.context.Jobs.ToList();
        }
    }
}