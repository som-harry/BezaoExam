using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RecruitingProject.Entity;
using RecruitingProject.Infrastructure;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            var chosenCategory = dbContext.context.Categories.FirstOrDefault(category => category.CategoryName == model.Category);
            if (chosenCategory == null)
            {
                chosenCategory = new Category()
                {
                    CategoryName = model.Category,
                    CategoryJobs = new List<Job>()
                };
                dbContext.context.Categories.Add(chosenCategory);
                dbContext.context.SaveChanges();
            }

            newjob.Category = chosenCategory;
            dbContext.context.Jobs.Add(newjob);
            chosenCategory.CategoryJobs.Add(newjob);

            //dbContext.context.Entry(chosenCategory).State = EntityState.Modified;


            dbContext.context.SaveChanges();
        }

        public Job Details(int id)
        {
            var job = dbContext.context.Jobs.SingleOrDefault(x => x.Id == id);

            if (job == null)
                throw new Exception("Error no job found");

            return job;
        }

        public JobEditFormViewModel Edit(int id)
        {
            var jobInDb = dbContext.context.Jobs.SingleOrDefault(j => j.Id == id);

            if (jobInDb == null)
                throw new Exception("No matching  job found");

            var viewModel = new JobEditFormViewModel()
            {
                AboutEmployer = jobInDb.AboutEmployer,
                Amount = jobInDb.Amount,
                Email = jobInDb.Email,
                EmployerName = jobInDb.EmployerName,
                JobDeadLine = jobInDb.JobDeadLine,
                JobDescription = jobInDb.JobDescription,
                JobName = jobInDb.JobName,
                MobileNumber = jobInDb.MobileNumber,
                OfficeLine = jobInDb.OfficeLine,
                Website = jobInDb.Website,
            };
            return viewModel;

        }

        public void UpdateJob(JobEditFormViewModel model, int id)
        {
            var jobInDb = dbContext.context.Jobs.SingleOrDefault(j => j.Id == id);

            if (jobInDb == null)
                throw new Exception("No matching  job found");

            jobInDb.JobName = model.JobName;
            jobInDb.Amount = model.Amount;
            jobInDb.EmployerName = model.Email;
            jobInDb.JobDeadLine = model.JobDeadLine;
            jobInDb.MobileNumber = model.MobileNumber;
            jobInDb.OfficeLine = model.OfficeLine;
            jobInDb.Website = model.Website;
            jobInDb.AboutEmployer = model.AboutEmployer;
            jobInDb.JobDescription = model.JobDescription;

            dbContext.context.SaveChanges();
        }

        public List<Job> GetThreeJobs()
        {
            return dbContext.context.Jobs.Take(3).ToList();
        }
        public List<Job> GetAllJobs()
        {
            return dbContext.context.Jobs.ToList();
        }
    }
}